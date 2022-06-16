using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Blog
    {
        [Key]
        [Display(Name ="Blog ID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter title !")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public Blog()
        {
            this.Title = "";
            this.Description = "";
            this.Content = "";
            this.Image = "";
        }
    }
}