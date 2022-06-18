using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Order_Items
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter number of floors !")]
        public int NumberOfFloor { get; set; }
        [Required(ErrorMessage = "Please enter quantity of elevators !")]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        //Foreign key
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }

        //Foreign key
        public int Order_DetailID { get; set; }
        public virtual Order_Detail Order_Detail { get; set; }

        public Order_Items()
        {
            this.NumberOfFloor = 1;
            this.Quantity = 1;
            this.CreatedAt = DateTime.Now;
            this.ModifiedAt = DateTime.Now;
        }
    }
}