using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string AddressLine2 { get; set; }

        public UserModel() { }
    }
}