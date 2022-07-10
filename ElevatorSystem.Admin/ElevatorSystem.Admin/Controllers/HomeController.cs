using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ElevatorSystem.Admin.Models.Entity;

namespace ElevatorSystem.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*[Authorize(Roles = "Admin, Mighty Admin")]*/
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Blogs = db.Blogs;
            homeModel.Categories = db.Categories;
            homeModel.Complaints = db.Complaints;
            homeModel.Elevators = db.Elevators;
            homeModel.Feedbacks = db.Feedbacks;
            homeModel.Orders = db.Orders;
            homeModel.Order_Items = db.Order_Items;
            homeModel.Projects = db.Projects;
            homeModel.Tags = db.Tags;
            return View(homeModel);
        }

        //HeaderPartialOrder
        public JsonResult OrderNotification()
        {
            // ID, SKU, FullName, Time ago
            //Return List Order which has been placed in this week
            var query = db.Database.SqlQuery<OrderHeaderViewModel>("Select Id ,OrderStatus, SKU, FullName, DAY(getdate()) - DAY(CreatedAt) as TimeAgo " +
                "from Orders  " +
                "where datepart(week, CreatedAt) = datepart(week, getdate())") ;

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrderCount()
        {
          
            var query = db.Database.SqlQuery<int>("select count(Id) as totalOrder " +
                "from Orders " +
                "where datepart(week, CreatedAt) = datepart(week, getdate()); ");

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        //Return SalesReport.cshtml
        public ActionResult SalesReport()
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Order_Items = db.Order_Items;
            homeModel.Orders = db.Orders;

            var orderListToday = homeModel.Order_Items;
         
            return PartialView(homeModel);
        }

        //Return RevenueReport.cshtml
        public ActionResult RevenueReport()
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Orders = db.Orders;

            return PartialView();
        }

        //Return CustomerReport.cshtml
        public ActionResult CustomersReport()
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.ApplicationUsers = db.Users;
            ViewData["CountCust"] = homeModel.ApplicationUsers.Count();
            return PartialView();
        }

       
        public ActionResult ReportChart()
        {
            AdminViewModel homeModel = new AdminViewModel();
            var saleMonth = db.Orders.Distinct()
                                     .OrderBy(m => m.CreatedAt)
                                     .ToList();
            ViewData["saleReport"] = saleMonth;

            return PartialView(homeModel);

        }

        public int SalesReport(int month)
        {
           
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Orders = db.Orders.ToList();
            homeModel.Order_Items = db.Order_Items.ToList();
            var orderList = homeModel.Order_Items;
            var result = from orderItem in orderList
                              //where (Convert.ToInt32(orderItem.Order.OrderDate.Value.Month) == month)
                             // where(string.Format("{0: MMMM}",orderItem.Order.CreatedAt) == month.ToString())

                         where (orderItem.OrderID == month)
                         select new { orderItem };

            int countSales = result.Count();

            return countSales;
        }

        public JsonResult SalesReport1()
        {
            //Get Count(Order) in current month
            var query = db.Database.SqlQuery<int>("select  count(Id) as totalOrder " +
                "from Orders " +
                "where datepart(month, CreatedAt) = datepart(month, getdate()) ;");

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataSale()
        {
            var data = db.Orders.Include("Order_Items").ToList();
            var query = db.Orders.Include("Order_Items")
                        .GroupBy(p => p.SKU)
                        .Select(g => new { name = g.Key, count = g.SingleOrDefault().Order_Items.Count() });
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReportCategory()
        {
            AdminViewModel homeModel = new AdminViewModel();
           
            return View(homeModel);
        }

        public int Cate1(int id)
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Elevators = db.Elevators.ToList();
            var elevatorList = homeModel.Elevators;
            var result1 = from product1 in elevatorList
                          where (product1.CategoryID == id)
                          select new { product1 };
            int cate1 = result1.Count();
            return cate1;
        }
        
        public ActionResult NewestBlog()
        {
            AdminViewModel homeModel = new AdminViewModel();
            homeModel.Blogs = db.Blogs.Include("Tag")
                .Where(p => p.PublishedAt >= DateTime.UtcNow)
                .ToList();
            var blogs = homeModel.Blogs;

            return View(blogs);
        }

        public ActionResult ListAccount()
        {
            AdminViewModel homeModel = new AdminViewModel();
            return PartialView(homeModel);
        }

        //GET : Users
        public ActionResult IndexAccount()
        {
            return View();
        }

        public JsonResult ReturnListAcc()
        {

            var query = db.Database.SqlQuery<AccountViewModel>("select Id, AddressLine1, AddressLine2, City, Country, Company, Status, Email," +
                "PhoneNumber, UserName  from AspNetUsers ");

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReturnDetailAcc(int status)
        {
            var query = db.Database.SqlQuery<AccountViewModel>("UPDATE AspNetUsers SET" +
                "Status=" + status +
                "");
            return Json(query);
        }

        public ActionResult RecentSales()
        {
            return PartialView();
        }

        public JsonResult ReturnRecentSale()
        {
            // Customer, Product, Price, Status
            var query = db.Database.SqlQuery<SaleViewModel>("select o.FullName, o.OrderStatus, ele.Name , ele.Price " +
                "from Orders as o join Order_Items as oi on o.Id = oi.OrderId " +
                "join Elevators as ele on oi.ElevatorID = ele.Id " +
                "where Day(o.CreatedAt) = Day(getdate()) ");

            return Json(query, JsonRequestBehavior.AllowGet);
        }

       

    }
}