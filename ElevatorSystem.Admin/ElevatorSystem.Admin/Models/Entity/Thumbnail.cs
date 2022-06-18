using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Thumbnail
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Image field cannot be null !")]
        public string Image { get; set; }

        //Foreign key
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }

        public Thumbnail()
        {
            this.Image = "";
        }
    }
}