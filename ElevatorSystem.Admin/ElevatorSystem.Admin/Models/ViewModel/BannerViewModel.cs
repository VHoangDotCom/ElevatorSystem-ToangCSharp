using ElevatorSystem.Admin.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModel
{
    public class BannerViewModel
    {
        [Display(Name = "Banner ID")]
        public int ID { get; set; }

        [Required(ErrorMessage ="Image field cannot be null !")]
        public string Image { get; set; }

        public BannerViewModel(Banner bn )
        {
            this.Image = bn.Image;
        }
    }
}