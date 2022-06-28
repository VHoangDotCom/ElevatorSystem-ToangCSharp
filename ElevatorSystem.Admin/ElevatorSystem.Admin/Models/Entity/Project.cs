using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Partner { get; set; }
        public string Term { get; set; }
        public string Images { get; set; }
        public string ContractDocument { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> DeletedAt { get; set; }

        //Foreign key
        public int Order_DetailID { get; set; }
        public virtual Order Order { get; set; }
        //public int ApplicationUser_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Project()
        {
            this.Status = 1;
            //this.CreatedAt = DateTime.Now;
            //this.UpdatedAt = DateTime.Now;
        }
    }
}