using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class User_Address
    {
        [Key]
        public int ID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        //public int ApplicationUser_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public User_Address()
        {
            this.AddressLine1 = "";
            this.AddressLine2 = "";
            this.City = "";
            this.Country = "";
            this.Telephone = "";
            this.Mobile = "";
        }
    }
}