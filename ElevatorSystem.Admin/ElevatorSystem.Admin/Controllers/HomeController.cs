using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevatorSystem.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var view_model = new HomeViewModel();
            view_model.Order_count = context.Orders.Count();
            Console.WriteLine(view_model.Order_count);
            return View(view_model);
        }
         
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}