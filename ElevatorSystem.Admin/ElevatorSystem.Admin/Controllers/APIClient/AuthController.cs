using ElevatorSystem.Admin.Authentication;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Validators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ElevatorSystem.Admin.Controllers.APIClient
{
    public class AuthController : ApiController
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> userManager;
        public AuthController()
        {
            db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        [Route("api/Register")]
        [HttpPost]
        public IHttpActionResult Register(RegisterRequest request)
        {

            var user = new ApplicationUser()
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = true
            };
            var result = userManager.Create(user, request.Password);
            return Ok(result);
        }

        [Route("api/Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {
            var result = userManager.Find(request.UserName, request.Password);
            if (result == null)
            {
                return Ok("Username or Password not match");
            }
            var jwt = new CustomJwtFormat();
            var token = jwt.CreateToken("user", result);
            return Ok(token);
        }

        [Authorize]
        [HttpPost]
        [Route("api/GetName")]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("api/GetName1")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "Username").FirstOrDefault()?.Value;
                var role = claims.Where(p => p.Type == "Email").FirstOrDefault()?.Value;
                return new
                {
                    data = name,
                    role
                };

            }
            return null;
        }
    }
}
