using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class OrderViewModel
    {
        public double Total { get; set; }
        public string FullName { get; set; }
        public string SKU { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public double ShippingFee { get; set; }

        public float Tax { get; set; }

        public string OrderEmail { get; set; }
        public int OrderStatus { get; set; }
        public int ShipStatus { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        //Foreign key
        //public int ApplicationUser_Id { get; set; }
        public string ApplicationUser_Id { get; set; }

        public OrderViewModel() { }
    }
}