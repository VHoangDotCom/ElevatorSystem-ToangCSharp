using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Complaint
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Title !")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProblemFaced { get; set; }

        //Foreign key
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Complaint()
        {
            this.Title = "";
            this.Description = "";
            this.ProblemFaced = "";
        }
    }
}