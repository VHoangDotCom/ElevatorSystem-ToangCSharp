using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.AuthModel
{
    public class Credentials
    {
        public string access_token { get; set; }
        public DateTime expires { get; set; }
    }
}