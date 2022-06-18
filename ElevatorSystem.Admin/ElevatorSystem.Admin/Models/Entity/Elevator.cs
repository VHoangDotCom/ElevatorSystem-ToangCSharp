﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Elevator
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter elevator name !")]
        public string Name { get; set; }
        public string SKU { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Thumbnails field cannot be null !")]
        public string Thumbnails { get; set; }
     
        [Required(ErrorMessage = "Please enter capacity field !")]
        public double Capacity { get; set; }
        [Required(ErrorMessage = "Please enter Speed field !")]
        public double Speed { get; set; }
        [Required(ErrorMessage = "Please enter price !")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter Max people per Elevator !")]
        public int MaxPerson { get; set; }
        public string Location { get; set; }
        public string Slug { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
       

        //Foreign key
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        


        public ICollection<Feedback> Feedbacks { get; set; }

        public Elevator()
        {
            this.Name = "";
            this.SKU = "";
            this.Description = "";
            this.Status = 1;
            this.Capacity = 1;
            this.Speed = 1;
            this.Price = 1;
            this.Slug = "";
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;

            this.Feedbacks = new HashSet<Feedback>();
        }
    }
}