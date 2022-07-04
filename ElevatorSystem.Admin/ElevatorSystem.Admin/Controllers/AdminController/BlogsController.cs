using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;
using ElevatorSystem.Admin.Models.ViewModels;
using ElevatorSystem.Admin.Repositories;
using Microsoft.TeamFoundation.WorkItemTracking.Internals;
using OfficeOpenXml;

namespace ElevatorSystem.Admin.Controllers.AdminController
{
    
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Tag);
           /* List<BlogViewModel> blogViewModels = blogs.Select(item => new BlogViewModel()
            {
                ID = item.ID,
                Title = item.Title,
                Summary = item.Summary,
                IsPublished = item.IsPublished,
                PostContent = item.PostContent,
                Thumbnail = item.Thumbnail,
                Slug = item.Slug,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                PublishedAt = item.PublishedAt,
                Tag = item.Tag,
                TagID = item.TagID,
            }).ToList();*/
            return View(blogs.ToList());
            //return View(blogViewModels);
        }


       
        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
           
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public EmptyResult ExportDoc(string blogTitle, string GridHtml)
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
            Response.AddHeader("content-disposition", "attachment;filename="+blogTitle+".doc");
            Response.Charset = "";
            /*Response.ContentType = "application/vnd.ms-word";*/
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml";
            Response.Output.Write(strHTML.ToString());
            Response.Flush();
            Response.End();

            return new EmptyResult();
        }

        public void ExportToExcel()
        {
            var blogs = db.Blogs.Include(b => b.Tag);
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Communication";
            ws.Cells["B1"].Value = "Com1";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Report1";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}",DateTimeOffset.Now);

            ws.Cells["A6"].Value = "BlogID";
            ws.Cells["B6"].Value = "Blog Title";
            ws.Cells["C6"].Value = "Published Status";
            ws.Cells["D6"].Value = "Thumbnail";
            ws.Cells["E6"].Value = "Published date";

            int rowStart = 7;
            foreach(var item in blogs)
            {
                if(item.IsPublished == true)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                }

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Title;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.IsPublished;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Thumbnail;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.PublishedAt;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.TagID = new SelectList(db.Tags, "ID", "Title");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Summary,IsPublished,PostContent,Thumbnail,Slug,CreatedAt,ModifiedAt,PublishedAt,TagID")] Blog blog )
        {
            if (ModelState.IsValid)
            {
              
                TempData["Content"] = blog.PostContent;
                blog.CreatedAt = DateTime.Today;
                if (blog.PublishedAt <= DateTime.Today)
                {
                    blog.IsPublished = true;
                }
                else
                {
                    blog.IsPublished = false;
                }

                //Insert thumbnail
               /* if(blog.Thumbnail != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(blog.ThumbnailFile.FileName);
                    string extension = Path.GetExtension(blog.ThumbnailFile.FileName);
                    fileName = fileName *//*+ DateTime.Now.ToString("yymmssfff")*//* + extension;//ko can datetine
                    blog.Thumbnail = "~/Image/Blogs/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/Blogs/"), fileName);
                    blog.ThumbnailFile.SaveAs(fileName);
                }*/
                    
                //Save data
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Show Success message
                TempData["CreateMessage"] = "Blog { #" + blog.ID + "." + blog.Title + " } has been added to the list !";      
                
                return RedirectToAction("Index");
            }
            ViewBag.TagID = new SelectList(db.Tags, "ID", "Title", blog.TagID);
            ModelState.Clear();
            return View(blog);
        }

        [HttpPost]
        public string UploadImages(HttpPostedFileBase file)
        {
            Random r = new Random();
            int num = r.Next();

            file.SaveAs(Server.MapPath("~/Content/Blogs/") + num + "_" + file.FileName);
            return "/Content/Blogs/" + num + "_" + file.FileName;
        }

      

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagID = new SelectList(db.Tags, "ID", "Title", blog.TagID);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Summary,IsPublished,PostContent,Thumbnail,Slug,CreatedAt,ModifiedAt,PublishedAt,TagID")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.ModifiedAt = DateTime.Today;
                if (blog.PublishedAt <= DateTime.Today)
                {
                    blog.IsPublished = true;
                }
                else
                {
                    blog.IsPublished = false;
                }
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Blog { #" + blog.ID + "." + blog.Title + " } has been updated !";
                return RedirectToAction("Index");
            }
            ViewBag.TagID = new SelectList(db.Tags, "ID", "Title", blog.TagID);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            TempData["DeleteMessage"] = "Blog { #" + blog.ID + "." + blog.Title + " } has been removed from the list !";
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

       

       /* [HttpPost]
        [ValidateInput(false)]
        public EmptyResult ExportDoc(string GridHtml)
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

            //Export docx
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Grid.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            Response.Output.Write(strHTML.ToString());
            Response.Flush();
            Response.End();
            return new EmptyResult();


        }*/
        
    }
}
