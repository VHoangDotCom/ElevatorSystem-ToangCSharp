using ElevatorSystem.Admin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.ViewModels
{
    public class HomeViewModel
    {
        public Order order { get; set; }
      
        public int Order_count { get; set; }

        public double Total_money { get; set; }

        public int Total_customer { get; set; }
    }
}