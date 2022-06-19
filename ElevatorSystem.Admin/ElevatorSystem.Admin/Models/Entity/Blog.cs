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
        public string Summary { get; set; }
        public bool IsPublished { get; set; }
        public string PostContent { get; set; }
        public string Thumbnail { get; set; }
        public string Slug { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> ModifiedAt { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> PublishedAt { get; set; }

        //Foreign key
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }

        public Blog()
        {
            this.Title = "";
            this.Summary = "";
            this.PostContent = "";
            this.Thumbnail = "";
            this.Slug = "";
            this.CreatedAt = DateTime.Now;
            this.IsPublished = true;
        }
    }
}