using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class FeedbackViewModel_2
    {
        public string Description { get; set; }
        public int SatisfyingLevel { get; set; }
        public string Problem { get; set; }
        public string Improvement { get; set; }
        public string Username { get; set; }
        public string AddressLine2 { get; set; }
        public string Email { get; set; }
        public int ElevatorID { get; set; }
        public FeedbackViewModel_2() { }
    }
}