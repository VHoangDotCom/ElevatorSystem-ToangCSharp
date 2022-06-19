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
        [Required(ErrorMessage = "Please enter Shipping fee !")]
        public double ShippingFee { get; set; }
        [Required(ErrorMessage = "Please enter Tax field !")]
        public float Tax { get; set; }
        [Required(ErrorMessage = "Please enter an Order email !")]
        public string OrderEmail { get; set; }
        public int OrderStatus { get; set; }
        public int ShipStatus { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> ModifiedAt { get; set; }

        //Foreign key
        //public int ApplicationUser_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int PaymentID { get; set; }
        public virtual Payment_Detail Payment_Detail { get; set; }
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