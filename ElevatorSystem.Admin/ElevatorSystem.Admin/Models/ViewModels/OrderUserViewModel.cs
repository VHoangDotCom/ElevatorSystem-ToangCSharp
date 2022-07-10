using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class OrderUserViewModel
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OrderEmail { get; set; }
        public int OrderStatus { get; set; }
        public string SKU { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public OrderUserViewModel()
        {

        }
    }
}