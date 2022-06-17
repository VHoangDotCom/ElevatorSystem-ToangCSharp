using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class User_Payment
    {
        [Key]
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }
        public int Account_no { get; set; }
        public string ZIP { get; set; }
        public DateTime Expiry { get; set; }
        public int ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public User_Payment()
        {
            this.PaymentType = "";
            this.Provider = "";
            this.Account_no = 1;
            this.ZIP = "";
        }
    }
}