using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class OrderHeaderViewModel
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public string SKU { get; set; }
        public string FullName { get; set; }
        
        public int TimeAgo { get; set; }
        public OrderHeaderViewModel()
        {

        }
    }
}