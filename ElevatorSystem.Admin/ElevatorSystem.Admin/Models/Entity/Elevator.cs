using System;
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
        [Required(ErrorMessage = "Image field cannot be null !")]
        public string Image { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Please enter weight field !")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Please enter Speed field !")]
        public double Speed { get; set; }
        [Required(ErrorMessage = "Please enter min price !")]
        public double MinPrice { get; set; }
        [Required(ErrorMessage = "Please enter max price !")]
        public double MaxPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Foreign key
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
 
        public ICollection<Thumbnail> Thumbnails { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

        public Elevator()
        {
            this.Name = "";
            this.Image = "";
            this.Description = "";
            this.Status = 1;
            this.Weight = 1;
            this.Speed = 1;
            this.MinPrice = 1;
            this.MaxPrice = 1;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;

            this.Thumbnails = new HashSet<Thumbnail>();
            this.Feedbacks = new HashSet<Feedback>();
        }
    }
}