using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Discount
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountPercent { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<Elevator> Elevators { get; set; }

        public Discount()
        {
            this.Name = "";
            this.CreatedAt = DateTime.Now;
            this.Description = "";
            this.DiscountPercent = 1;
            this.IsActivated = true;
            this.Elevators = new HashSet<Elevator>();
        }
    }
}