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
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        //Export Data to Excel
        public void ProjectReport()
        {
            var projects = db.Projects.Include(e => e.Order);
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Project Report");

            //Set information for order title
            ws.Cells["A1"].Value = "Manager";
            ws.Cells["B1"].Value = "Nguyen Viet Hoang";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Project report";

            ws.Cells["A3"].Value = "Datetime";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            //Set color for Status
            ws.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D3"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D5"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D6"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells["D7"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;


            ws.Cells["D1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gainsboro")));
            ws.Cells["D2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
            ws.Cells["D3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gold")));
            ws.Cells["D4"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("LightSteelBlue")));
            ws.Cells["D5"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
            ws.Cells["D6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Aquamarine")));
            ws.Cells["D7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("tomato")));


            ws.Cells["E1"].Value = "Upcoming ";
            ws.Cells["E2"].Value = "Pending ";
            ws.Cells["E3"].Value = "Overdue ";
            ws.Cells["E4"].Value = "Not Started ";
            ws.Cells["E5"].Value = "Active ";
            ws.Cells["E6"].Value = "Priority ";
            ws.Cells["E7"].Value = "Canceled ";

            //Data table
            ws.Cells["A10"].Value = "Project ID";
            ws.Cells["B10"].Value = "Name";
            ws.Cells["C10"].Value = "Title";
            ws.Cells["D10"].Value = "Status";
            ws.Cells["E10"].Value = "Started Date";
            ws.Cells["F10"].Value = "Ended Date";
            ws.Cells["G10"].Value = "Description";
            ws.Cells["H10"].Value = "Partner";
            ws.Cells["I10"].Value = "Term";
            ws.Cells["J10"].Value = "Images";
            ws.Cells["K10"].Value = "Contrast Document";
            ws.Cells["L10"].Value = "Created Date";
            ws.Cells["M10"].Value = "Updated Date";
            ws.Cells["N10"].Value = "Order SKU";
          


            int rowStart = 11;
            foreach (var item in projects)
            {
                string status = "";
                if (item.Status == 0)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gainsboro")));
                    status = "Upcoming";
                }
                else if (item.Status == 1)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightyellow")));
                    status = "Pending";
                }
                else if (item.Status == 2)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Gold")));
                    status = "Overdue";
                }
                else if (item.Status == 3)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("LightSteelBlue")));
                    status = "Not Started";
                }
                else if (item.Status == 4)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("lightgreen")));
                    status = "Active";
                }
                else if (item.Status == 5)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("Aquamarine")));
                    status = "Priority";
                }
                else if (item.Status == 6)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("tomato")));
                    status = "Canceled";
                }


                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Title;
                ws.Cells[string.Format("D{0}", rowStart)].Value = status;
                ws.Cells[string.Format("E{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.StartDate);
                ws.Cells[string.Format("F{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.EndDate);
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Partner;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Term;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.Images;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.ContractDocument;
                ws.Cells[string.Format("L{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.CreatedAt);
                ws.Cells[string.Format("M{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.UpdatedAt);
                ws.Cells[string.Format("N{0}", rowStart)].Value =  item.Order.SKU;
              
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "Projects Report.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project.Status == 0)
            {
                ViewData["projectStatus"] = "Upcoming";
            }
            else if (project.Status == 1)
            {
                ViewData["projectStatus"] = "Pending";
            }
            else if (project.Status == 2)
            {
                ViewData["projectStatus"] = "Overdue";
            }
            else if (project.Status == 3)
            {
                ViewData["projectStatus"] = "Not Started";
            }
            else if (project.Status == 4)
            {
                ViewData["projectStatus"] = "Active";
            }
            else if (project.Status == 5)
            {
                ViewData["projectStatus"] = "Priority";
            }
            else if (project.Status == 6)
            {
                ViewData["projectStatus"] = "Canceled";
            }
            else
            {
                ViewData["projectStatus"] = "Status is undefined";
            }
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //Export Contrast Document
        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult ExportDoc(string projectName, string GridHtml)
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


            //string name = nameBlog;
            //Export docx
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + projectName + ".doc");
            Response.Charset = "";
            /*Response.ContentType = "application/vnd.ms-word";*/
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml";
            Response.Output.Write(strHTML.ToString());
            Response.Flush();
            Response.End();

            return new EmptyResult();
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Title,Status,StartDate,EndDate,Description,Partner,Term,Images,ContractDocument,CreatedAt,UpdatedAt,OrderID,DeletedAt")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedAt = DateTime.Today;
                project.OrderID = Convert.ToInt32(TempData["ID"]);
              
                db.Projects.Add(project);
                db.SaveChanges();
                TempData["CreateMessage"] = "Project { #" + project.ID + "." + project.Name + " } has been added to the list !";
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Title,Status,StartDate,EndDate,Description,Partner,Term,Images,ContractDocument,CreatedAt,UpdatedAt,DeletedAt,OrderID")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.UpdatedAt = DateTime.Today;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Project { #" + project.ID + "." + project.Name + " } has been updated !";
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if(project.Status == 0)
            {
                ViewData["projectStatus"] = "Upcoming";
            }else if(project.Status == 1)
            {
                ViewData["projectStatus"] = "Pending";
            }
            else if (project.Status == 2)
            {
                ViewData["projectStatus"] = "Overdue";
            }
            else if (project.Status == 3)
            {
                ViewData["projectStatus"] = "Not Started";
            }
            else if (project.Status == 4)
            {
                ViewData["projectStatus"] = "Active";
            }
            else if (project.Status == 5)
            {
                ViewData["projectStatus"] = "Priority";
            }
            else if (project.Status == 6)
            {
                ViewData["projectStatus"] = "Canceled";
            }
            else
            {
                ViewData["projectStatus"] = "Status is undefined";
            }

            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            if (project.Status == 0)
            {
                ViewData["projectStatus"] = "Upcoming";
            }
            else if (project.Status == 1)
            {
                ViewData["projectStatus"] = "Pending";
            }
            else if (project.Status == 2)
            {
                ViewData["projectStatus"] = "Overdue";
            }
            else if (project.Status == 3)
            {
                ViewData["projectStatus"] = "Not Started";
            }
            else if (project.Status == 4)
            {
                ViewData["projectStatus"] = "Active";
            }
            else if (project.Status == 5)
            {
                ViewData["projectStatus"] = "Priority";
            }
            else if (project.Status == 6)
            {
                ViewData["projectStatus"] = "Canceled";
            }
            else
            {
                ViewData["projectStatus"] = "Status is undefined";
            }

            //Check valid deletion
            if(project.Status >= 6)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                TempData["DeleteMessage"] = "Project { #" + project.ID + "." + project.Name + " } has been removed from the list !";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["InvalidStatus"] = "You are not allowed to remove Project { #" + project.ID + "." + project.Name + " } !";
                return View(project);
            }
           
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
