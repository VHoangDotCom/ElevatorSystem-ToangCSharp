using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Banner
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Image { get; set; }
        public Banner()
        {
            this.Image = "";
        }
    }
}