﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Title !")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime PublishedAt { get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public Tag()
        {
            this.Title = "";
            this.Description = "";
            this.IsPublished = true;
            this.CreatedAt = DateTime.Now;

            this.Blogs = new HashSet<Blog>();
        }
    }
}