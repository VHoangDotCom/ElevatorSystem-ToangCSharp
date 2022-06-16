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
        //Order number la ma tu sinh
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "Please enter order name !")]
        public string OrderName { get; set; }
        [Required(ErrorMessage = "Please enter cost !")]
        public double Cost { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Please enter payment method !")]
        public int Payment { get; set; }
        [Required(ErrorMessage = "Please enter number of floor !")]
        public int NumOfFloor { get; set; }
        [Required(ErrorMessage = "Please enter Amount of elevators !")]
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Foreign key
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }
        public int ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<Complaint> Complaints { get; set; }

        public Order()
        {
            this.OrderName = "";
            this.OrderName = "";
            this.Cost = 1;
            this.Status = 1;
            this.Payment = 1;
            this.NumOfFloor = 1;
            this.Amount = 1;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;

            this.Complaints = new HashSet<Complaint>();
        }
    }
}