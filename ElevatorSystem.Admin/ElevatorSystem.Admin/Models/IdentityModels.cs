using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ElevatorSystem.Admin.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ElevatorSystem.Admin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Order_Detail> Order_Details { get; set; }
       
        public ICollection<Project> Projects { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactDetails { get; set; }
        public string Company { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public ApplicationUser()
        {
            this.Feedbacks = new HashSet<Feedback>();
            this.Order_Details = new HashSet<Order_Detail>();
        
            this.Projects = new HashSet<Project>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
       
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Elevator> Elevators { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Payment_Detail> Payment_Details { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
      
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}