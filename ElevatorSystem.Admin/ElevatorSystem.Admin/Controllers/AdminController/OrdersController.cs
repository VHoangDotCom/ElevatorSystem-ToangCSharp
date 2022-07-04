using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;
using OfficeOpenXml;

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

            return View(orders.ToList());
        }

        //Export Data to Excel
        public void OrderReport()
        {
            var orders = db.Orders.Include(e => e.ApplicationUser);
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            //Set information for order title
            ws.Cells["A1"].Value = "Manager";
            ws.Cells["B1"].Value = "Nguyen Viet Hoang";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Order report";

            ws.Cells["A3"].Value = "Datetime";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            //Set color for Status
            ws.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D3"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D5"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D6"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;


            ws.Cells["D1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
            ws.Cells["D2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gold")));
            ws.Cells["D3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
            ws.Cells["D4"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Tomato")));
            ws.Cells["D5"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Teal")));
            ws.Cells["D6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Sienna")));


            ws.Cells["E1"].Value = "Pending - This status means no invoice and shipments have been submitted.";
            ws.Cells["E2"].Value = "Processing - In this state, the Order is being processed and prepared for packaging and shipping.";
            ws.Cells["E3"].Value = "Completed - complete - This status means that the order is created, paid, and shipped to the customer.";
            ws.Cells["E4"].Value = "Canceled - This status is assigned manually in the Admin or for some customers who want to cancel their order.";
            ws.Cells["E5"].Value = "Refund - This status indicates that the Customer wants to return the product and wants a refund.";
            ws.Cells["E6"].Value = "Complaint - This status indicates that the customer has submitted a complaint or review about the product.";

            //Data table
            ws.Cells["A8"].Value = "Order ID";
            ws.Cells["B8"].Value = "Total ($)";
            ws.Cells["C8"].Value = "Full Name";
            ws.Cells["D8"].Value = "SKU (Stock Keeping Unit)";
            ws.Cells["E8"].Value = "Phonenumber";
            ws.Cells["F8"].Value = "Address";
            ws.Cells["G8"].Value = "Description";
            ws.Cells["H8"].Value = "Shipping Fee ($)";
            ws.Cells["I8"].Value = "Tax ($)";
            ws.Cells["J8"].Value = "Order Email";
            ws.Cells["K8"].Value = "Order Status";
            ws.Cells["L8"].Value = "Ship Status";
            ws.Cells["M8"].Value = "Order Date";
            ws.Cells["N8"].Value = "Created Date";
            ws.Cells["O8"].Value = "Modified Date";
           

            int rowStart = 9;
            foreach (var item in orders)
            {
                string status = "";
                if (item.OrderStatus == 0)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
                    status = "Pending";
                }
                else if (item.OrderStatus == 1)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gold")));
                    status = "Processing";
                }
                else if (item.OrderStatus == 2)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
                    status = "Completed";
                }
                else if (item.OrderStatus == 3)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Tomato")));
                    status = "Canceled";
                }
                else if (item.OrderStatus == 4)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Teal")));
                    status = "Refund";
                }
                else if (item.OrderStatus == 5)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Sienna")));
                    status = "Complaint";
                }
               

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Total;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.FullName;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.SKU;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.PhoneNumber;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Address;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.ShippingFee;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Tax;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.OrderEmail;
                ws.Cells[string.Format("K{0}", rowStart)].Value = status;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.ShipStatus;
                ws.Cells[string.Format("M{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.OrderDate);
                ws.Cells[string.Format("N{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.CreatedAt);
                ws.Cells[string.Format("O{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.ModifiedAt);
               

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "Orders Report.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
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

            Order order = db.Orders.Find(id);
            TempData["ID"] = order.ID;
            TempData["OrderSKU"] = Convert.ToString(order.SKU);
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
