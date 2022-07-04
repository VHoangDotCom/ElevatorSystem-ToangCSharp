using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public double Total { get; set; }
        public string FullName { get; set; }
        //SKU (Stock Keeping Unit)
        public string SKU { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description  { get; set; }
       
        public double ShippingFee { get; set; }
       
        public float Tax { get; set; }
       
        public string OrderEmail { get; set; }
        public int OrderStatus { get; set; }
        public int ShipStatus { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> OrderDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> ModifiedAt { get; set; }

        //Foreign key
        //public int ApplicationUser_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        public ICollection<Order_Items> Order_Items { get; set; }
        public ICollection<Complaint> Complaints { get; set; }

        public Order()
        {
            this.Total = 1;
            this.ShippingFee = 1;
            this.Order_Items = new HashSet<Order_Items>();
            this.Complaints = new HashSet<Complaint>();
        }
    }
}