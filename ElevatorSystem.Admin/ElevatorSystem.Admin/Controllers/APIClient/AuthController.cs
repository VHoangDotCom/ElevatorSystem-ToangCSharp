using ElevatorSystem.Admin.Authentication;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.ViewModels;
using ElevatorSystem.Admin.Validators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace ElevatorSystem.Admin.Controllers.APIClient
{
    public class AuthController : ApiController
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AuthController()
        {
            db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }

        [System.Web.Http.Route("api/Register")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Register(RegisterRequest request)
        {
            var user = new ApplicationUser()
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = true
            };
            var result = userManager.Create(user, request.Password);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id,"user");
            }
            return Ok(result);
        }

        [System.Web.Http.Route("api/Login")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {
            var result = userManager.Find(request.UserName, request.Password);
            var role = userManager.GetRoles(result.Id);
           
            if (result == null)
            {
                return Ok("Username or Password not match");
            }
            var jwt = new CustomJwtFormat();
            var token = jwt.CreateToken("user", result);
            return Ok(token);
        }


        [System.Web.Http.Authorize(Roles = "user")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Profile")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
               
                var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
                var result =  userManager.FindById(id);
                return new
                {
                    data = result,
                };

            }
            return null;
        }
       
        [System.Web.Http.Authorize(Roles = "user")]
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/updateProfile")]
        public Object UpdateProfile(ApplicationUser applicationUser)
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
                var user = userManager.FindById(id)
;
                user.AddressLine1 = applicationUser.AddressLine1;
                user.AddressLine2 = applicationUser.AddressLine2;
                user.City = applicationUser.City;
                user.Country = applicationUser.Country;
                user.Company = applicationUser.Company;
                user.PhoneNumber = applicationUser.PhoneNumber;
                user.Email = applicationUser.Email;
                user.UserName = applicationUser.UserName;
                var result = userManager.Update(user);
                return new
                {
                    data = result,
                };

            }
            return null;
        }

        [System.Web.Http.Authorize(Roles = "user")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getOrderByIdUser")]
        public IHttpActionResult getOrderByIdUser()
        {
            var identity = User.Identity as ClaimsIdentity;
        
            IEnumerable<Claim> claims = identity.Claims;
            var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;

            var queryString =
                "select o.ID, o.OrderEmail, o.Address,o.FullName, o.OrderStatus, o.Total , o.PhoneNumber, o.SKU, o.CreatedAt from AspNetUsers as au " +
                "join Orders as o on  au.Id = o.ApplicationUser_Id  where au.Id = @UserId";

            var dataOrder = db.Database.SqlQuery<OrderUserViewModel>(queryString, new SqlParameter("@UserId", id));

            return Ok(dataOrder);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getCountUser")]
        public IHttpActionResult getCountUser()
        {
            var queryString = "select COUNT(Id) from AspNetUsers";
            var dataOrder = db.Database.SqlQuery<int>(queryString);
            return Ok(dataOrder);
        }
    }
}
