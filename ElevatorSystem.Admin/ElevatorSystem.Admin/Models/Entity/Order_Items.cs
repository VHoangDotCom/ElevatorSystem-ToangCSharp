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
        
        //Foreign key
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }

        //Foreign key
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Order_Items()
        {
            this.NumberOfFloor = 1;
            this.Quantity = 1;
           
        }
    }
}