using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;
using OfficeOpenXml;

namespace ElevatorSystem.Admin.Controllers.AdminController
{
    public class ElevatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Elevators
        public ActionResult Index()
        {
            var elevators = db.Elevators.Include(e => e.Category);
            TempData["0"] = "Status : 0 - Pending";
            TempData["1"] = "Status : 1 - Available";
            TempData["2"] = "Status : 2 - Upgrading";
            TempData["3"] = "Status : 3 - Out of date";
            TempData["n"] = "Status : n - Status is undefined";
            return View(elevators.ToList());
        }

        //Export Data to Excel
        public void ElevatorReport()
        {
            var elevators = db.Elevators.Include(e => e.Category);
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Manager";
            ws.Cells["B1"].Value = "Nguyen Viet Hoang";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Elevator information";

            ws.Cells["A3"].Value = "Datetime";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["C1"].Value = "Pending";
            ws.Cells["C2"].Value = "Available";
            ws.Cells["C3"].Value = "Upgrading";
            ws.Cells["C4"].Value = "Out of date";

            ws.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D3"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

            ws.Cells["D1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
            ws.Cells["D2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
            ws.Cells["D3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightblue")));
            ws.Cells["D4"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("CadetBlue")));

            ws.Cells["A6"].Value = "Blog ID";
            ws.Cells["B6"].Value = "Name";
            ws.Cells["C6"].Value = "SKU (Stock Keeping Unit)";
            ws.Cells["D6"].Value = "Status";
            ws.Cells["E6"].Value = "Description";
            ws.Cells["F6"].Value = "Thumbnails";
            ws.Cells["G6"].Value = "Capacity (lbs)";
            ws.Cells["H6"].Value = "Speed (m/s)";
            ws.Cells["I6"].Value = "Price ($)";
            ws.Cells["J6"].Value = "Maximum people";
            ws.Cells["K6"].Value = "Location";
            ws.Cells["L6"].Value = "Slug";
            ws.Cells["M6"].Value = "Tag";
            ws.Cells["N6"].Value = "Created Date";
            ws.Cells["O6"].Value = "Updated Date";
            ws.Cells["P6"].Value = "Category";
           
            int rowStart = 7;
            foreach (var item in elevators)
            {
                string status = "";
                if (item.Status == 0)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
                    status = "Pending";
                }else if(item.Status == 1)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
                    status = "Available";
                }
                else if(item.Status == 2)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightblue")));
                    status = "Upgrading";
                }
                else if(item.Status == 3)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("CadetBlue")));
                    status = "Out of date";
                }

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.SKU;
                ws.Cells[string.Format("D{0}", rowStart)].Value = status;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Thumbnails;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Capacity;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Speed;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Price;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.MaxPerson;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.Location;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.Slug;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.Tag;
                ws.Cells[string.Format("N{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.CreatedAt);
                ws.Cells[string.Format("O{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.UpdatedAt);
                ws.Cells[string.Format("P{0}", rowStart)].Value = item.Category.Name;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "ElevatorReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        // GET: Elevators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elevator elevator = db.Elevators.Find(id);
            if (elevator.Status == 0)
            {
                ViewData["elevatorStatus"] = "Pending";
            }
            else if (elevator.Status == 1)
            {
                ViewData["elevatorStatus"] = "Available";
            }
            else if (elevator.Status == 2)
            {
                ViewData["elevatorStatus"] = "Upgrading";
            }
            else if (elevator.Status == 3)
            {
                ViewData["elevatorStatus"] = "Out of date";
            }
            else
            {
                ViewData["elevatorStatus"] = "Status is undefined";
            }

            if (elevator == null)
            {
                return HttpNotFound();
            }
            return View(elevator);
        }

        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult ExportDoc(string elevatorName, string GridHtml)
        {

            //Conver Html Source to Docx Content
            StringBuilder strHTML = new StringBuilder();
            strHTML.Append("<html " +
                " xmlns:o='urn:schemas-microsoft-com:office:office'" +
                " xmlns:w='urn:schemas-microsoft-com:office:word'" +
                " xmlns='http://www.w3.org/TR/REC-html40'>" +
                "<head><title>Invoice Sample</title>");

            strHTML.Append("<xml><w:WordDocument>" +
                " <w:View>Print</w:View>" +
                " <w:Zoom>100</w:Zoom>" +
                " <w:DoNotOptimizeForBrowser/>" +
                " </w:WordDocument>" +
                " </xml>");

            strHTML.Append("<body><div class='page-settings'>" + GridHtml + "</div></body></html>");

            //Export Elevator Detail (html in Scripts)
            //Export docx
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + elevatorName + ".doc");
            Response.Charset = "";
            /*Response.ContentType = "application/vnd.ms-word";*/
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml";
            Response.Output.Write(strHTML.ToString());
            Response.Flush();
            Response.End();

            return new EmptyResult();
        }

        public JsonResult getById(int? id)
        {
            Elevator elevator = db.Elevators.Find(id);
            return Json(elevator, JsonRequestBehavior.AllowGet);
        }

        // GET: Elevators/Create
        public ActionResult Create()
        {
            
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Elevators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "ID,Name,SKU,Status,Description,Thumbnails,Capacity,Speed,Price,MaxPerson,Location,Slug,Tag,CreatedAt,UpdatedAt,DeletedAt,CategoryID")] Elevator elevator)
         {

             if (ModelState.IsValid)
             {
                 Random rd = new Random();
                 elevator.SKU = "ELEVATOR00" + rd.Next(1,1000).ToString();
                 elevator.CreatedAt = DateTime.Today;
                 db.Elevators.Add(elevator);
                 db.SaveChanges();
                 TempData["CreateMessage"] = "Elevator { #" + elevator.ID + "." + elevator.Name + " } has been added to the list !";
                 return RedirectToAction("Index");
             }

             ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
             return View(elevator);
         }*/
        
        [HttpPost]
        public JsonResult Create(Elevator elevator)
        {

            if (ModelState.IsValid)
            {
                Random rd = new Random();
                elevator.SKU = "ELEVATOR00" + rd.Next(1, 1000).ToString();
                elevator.CreatedAt = DateTime.Now;
                db.Elevators.Add(elevator);
                db.SaveChanges();
                TempData["CreateMessage"] = "Elevator { #" + elevator.ID + "." + elevator.Name + " } has been added to the list !";
                return Json(elevator, JsonRequestBehavior.AllowGet);
            }
           
            return Json(elevator, JsonRequestBehavior.AllowGet);
        }

        // GET: Elevators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elevator elevator = db.Elevators.Find(id);
            if (elevator == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
            return View(elevator);
        }

        [HttpPost]
        public JsonResult Edit(Elevator elevator)
        {

            if (ModelState.IsValid)
            {
                elevator.UpdatedAt = DateTime.Today;
                db.Entry(elevator).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Elevator { #" + elevator.ID + "." + elevator.Name + " } has been updated !";
                return Json(elevator, JsonRequestBehavior.AllowGet);
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
            return Json(elevator, JsonRequestBehavior.AllowGet);
        }

        // POST: Elevators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SKU,Status,Description,Thumbnails,Capacity,Speed,Price,MaxPerson,Location,Slug,Tag,CreatedAt,UpdatedAt,DeletedAt,CategoryID")] Elevator elevator)
        {
            if (ModelState.IsValid)
            {
                elevator.UpdatedAt = DateTime.Today;
                
                db.Entry(elevator).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Elevator { #" + elevator.ID + "." + elevator.Name + " } has been updated !";
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
            return View(elevator);
        }*/

        // GET: Elevators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elevator elevator = db.Elevators.Find(id);
            if (elevator.Status == 0)
            {
                ViewData["elevatorStatus"] = "Pending";
            }
            else if (elevator.Status == 1)
            {
                ViewData["elevatorStatus"] = "Available";
            }
            else if (elevator.Status == 2)
            {
                ViewData["elevatorStatus"] = "Upgrading";
            }
            else if (elevator.Status == 3)
            {
                ViewData["elevatorStatus"] = "Out of date";
            }
            else
            {
                ViewData["elevatorStatus"] = "Status is undefined";
            }


            if (elevator == null)
            {
                return HttpNotFound();
            }
           
            return View(elevator);
        }

        // POST: Elevators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elevator elevator = db.Elevators.Find(id);
            //Check Status
            if (elevator.Status == 0)
            {
                ViewData["elevatorStatus"] = "Pending";
            }
            else if (elevator.Status == 1)
            {
                ViewData["elevatorStatus"] = "Available";
            }
            else if (elevator.Status == 2)
            {
                ViewData["elevatorStatus"] = "Upgrading";
            }
            else if (elevator.Status == 3)
            {
                ViewData["elevatorStatus"] = "Out of date";
            }
            else
            {
                ViewData["elevatorStatus"] = "Status is undefined";
            }

            //Check Valid Delete
            if (elevator.Status >= 3)
            {
                db.Elevators.Remove(elevator);
                db.SaveChanges();
                TempData["DeleteMessage"] = "Elevator { #" + elevator.ID + "." + elevator.Name + " } has been removed from the list !";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["InvalidStatus"] = "You are not allowed to remove Elevator { #" + elevator.ID + "." + elevator.Name + " } !";
                return View(elevator);
            }
          
        }
        [HttpPost]
        public string UploadImages(HttpPostedFileBase file)
        {
            Random r = new Random();
            int num = r.Next();

            file.SaveAs(Server.MapPath("~/Content/Elevator/") + num + "_" + file.FileName);
            return "/Content/Elevator/" + num + "_" + file.FileName;
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
