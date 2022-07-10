using ElevatorSystem.Admin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Complaint> Complaints { get; set; }
        public IEnumerable<Elevator> Elevators { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Order_Items> Order_Items { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

    }
}