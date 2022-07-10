using ElevatorSystem.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevatorSystem.Admin.Controllers.AdminController
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public JsonResult Result()
        {

            var queryString_v1 = "select  CreatedAt as CreatedAt from Orders Group by CreatedAt";
            var queryString_v2 = "select Count(ID) from Orders Group by CreatedAt";
            var dataDate = db.Database.SqlQuery<DateTime>(queryString_v1);
            var dataOrder = db.Database.SqlQuery<int>(queryString_v2);

            return Json(new { dataDate, dataOrder }, JsonRequestBehavior.AllowGet);
        }
    }
}