using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter number of floor !")]
        public int NumberOfFloor { get; set; }

        [Required(ErrorMessage = "Please enter amount of elevator !")]
        public int Amount { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter address !")]
        public string Address { get; set; }
       
        public int Status { get; set; }
        [Required(ErrorMessage = "Please enter payment method !")]
        public int Payment { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Foreign key
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }
    }
}