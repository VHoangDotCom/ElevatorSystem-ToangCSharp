using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;

namespace ElevatorSystem.Admin.Controllers.AdminController
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(e => e.ApplicationUser);//tu them
            TempData["orderStatus0"] = " 0 - Pending - This status means no invoice and shipments have been submitted.";
            TempData["orderStatus1"] = " 1 - Processing - In this state, the Order is being processed and prepared for packaging and shipping.";
            TempData["orderStatus2"] = " 2 - Completed - complete - This status means that the order is created, paid, and shipped to the customer.";
            TempData["orderStatus3"] = " 3 - Canceled - This status is assigned manually in the Admin or for some customers who want to cancel their order.";
            TempData["orderStatus4"] = " 4 - Refund - This status indicates that the Customer wants to return the product and wants a refund.";
            TempData["orderStatus5"] = " 5 - Complaint - This status indicates that the customer has submitted a complaint or review about the product.";
            TempData["n"] = "Status : n - Status is undefined";

            TempData["shippingStatus0"] = "0 - Packaging";
            TempData["shippingStatus1"] = "1 - Delivering";
            TempData["shippingStatus2"] = "2 - Received";

            //Message Created Order
           // int count = 0;
          /* foreach(Order order in orders)
            {
                if(order.OrderStatus == 0)
                {
                    @TempData["PendingMessage"] = "Order { #" + order.ID + ". " + order.SKU + " } has been added to the list !";
                }else if(order.OrderStatus == 2)
                {
                    TempData["CompletedMessage"] = "Order { #" + order.ID + ". " + order.SKU + " } is completed !";
                }else if(order.OrderStatus == 3)
                {
                    TempData["DeleteMessage"] = "Order { #" + order.ID + ". " + order.SKU + " } is canceled !";
                }
            }*/

            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            //Set Order Status
            if(order.OrderStatus == 0)
            {
                ViewData["orderStatus"] = "Pending";
            }else if(order.OrderStatus == 1)
            {
                ViewData["orderStatus"] = "Processing";
            }
            else if (order.OrderStatus == 2)
            {
                ViewData["orderStatus"] = "Completed";
            }
            else if (order.OrderStatus == 3)
            {
                ViewData["orderStatus"] = "Canceled";
            }
            else if (order.OrderStatus == 4)
            {
                ViewData["orderStatus"] = "Refund";
            }
            else if (order.OrderStatus == 5)
            {
                ViewData["orderStatus"] = "Complaint";
            }

            //Set Shipping Status
            if(order.ShipStatus == 0)
            {
                ViewData["shipStatus"] = "Packaging";
            }
            else if (order.ShipStatus == 1)
            {
                ViewData["shipStatus"] = "Delivering";
            }
            else if (order.ShipStatus == 2)
            {
                ViewData["shipStatus"] = "Received";
            }

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            TempData["orderStatus0"] = " 0 - Pending - This status means no invoice and shipments have been submitted.";
            TempData["orderStatus1"] = " 1 - Processing - In this state, the Order is being processed and prepared for packaging and shipping.";
            TempData["orderStatus2"] = " 2 - Completed - complete - This status means that the order is created, paid, and shipped to the customer.";
            TempData["orderStatus3"] = " 3 - Canceled - This status is assigned manually in the Admin or for some customers who want to cancel their order.";
            TempData["orderStatus4"] = " 4 - Refund - This status indicates that the Customer wants to return the product and wants a refund.";
            TempData["orderStatus5"] = " 5 - Complaint - This status indicates that the customer has submitted a complaint or review about the product.";
            TempData["n"] = "Status : n - Status is undefined";

            TempData["shippingStatus0"] = "0 - Packaging";
            TempData["shippingStatus1"] = "1 - Delivering";
            TempData["shippingStatus2"] = "2 - Received";
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Total,FullName,PhoneNumber,SKU,Address,Description,ShippingFee,Tax,OrderEmail,OrderStatus,ShipStatus,OrderDate,CreatedAt,ModifiedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.CreatedAt = DateTime.Today;
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }


        // GET: Projects/Create
        public ActionResult CreateProject(int id)
        {
           
            TempData["ID"] = id;
            return new RedirectResult("/Projects/Create");

           
        }

       


        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Total,FullName,PhoneNumber,SKU,Address,Description,ShippingFee,Tax,OrderEmail,OrderStatus,ShipStatus,OrderDate,CreatedAt,ModifiedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.ModifiedAt = DateTime.Today;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Order { #" + order.ID + "." + order.SKU + " } has been updated !";
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //GET: Orders/Details/5/Order_Items
        public  ActionResult GetListItems(int? id)
        {
            /* List<Order> orders = db.Orders.ToList();
             List<Order_Items> order_Items = db.Order_Items.ToList();
             var listItems = from e in order_Items
                             join d in orders on e.OrderID equals d.ID
                             where d.ID == id
                             select order_Items.FirstOrDefault();*/

            var listOrderItems = db.Order_Items.Where(ot => ot.OrderID == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id ?? 1);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = id;
            ViewBag.sku = order.SKU;
            //Get list Order Items by OrderID
            // Order order = db.Orders.Find(id);
            // var model = order.Order_Items;
/*
            IEnumerable<Order> listItem = await db.Orders.Where(o => o.ID == id)
               .Join(db.Order_Items, o => o.ID, ot => ot.OrderID, (o, ot) => new
               { Order_Items = o.Order_Items }).;*/
            

            return View(listOrderItems);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
