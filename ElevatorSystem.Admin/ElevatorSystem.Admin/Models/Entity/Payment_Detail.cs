using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Payment_Detail
    {
        [Key]
        public int ID { get; set; }
        public double Amount { get; set; }
        public string Provider { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Payment_Detail()
        {
            this.Amount = 1;
            this.Provider = "";
            this.Status = 1;
        }
    }
}