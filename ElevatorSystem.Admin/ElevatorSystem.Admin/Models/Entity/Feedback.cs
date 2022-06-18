using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public int SatisfyingLevel { get; set; }
        public string Problem { get; set; }
        public string Improvement { get; set; }

        //Foreign key
        public int ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ElevatorID { get; set; }
        public virtual Elevator Elevator { get; set; }

        public Feedback()
        {
            this.Description = "";
            this.SatisfyingLevel = 1;
            this.Problem = "";
            this.Improvement = "";
        }
    }
}