using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class FeedbackViewModel
    {
        public string Description { get; set; }
        public int SatisfyingLevel { get; set; }
        public string Problem { get; set; }
        public string Improvement { get; set; }
        public string ApplicationUser_Id { get; set; }
        public int ElevatorID { get; set; }
        public FeedbackViewModel() { }
    }
}