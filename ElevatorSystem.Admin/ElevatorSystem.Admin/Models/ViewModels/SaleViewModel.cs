using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.ViewModels
{
    public class SaleViewModel
    {
   
        public string FullName { get; set; }
        public int OrderStatus { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public SaleViewModel()
        {

        }
    }
}