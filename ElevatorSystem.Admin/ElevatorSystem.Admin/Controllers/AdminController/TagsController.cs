using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;

namespace ElevatorSystem.Admin.Controllers.AdminController
{
    public class TagsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tags
        public ActionResult Index()
        {
            return View(db.Tags.ToList());
        }

        // GET: Tags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,IsPublished,CreatedAt,ModifiedAt,PublishedAt")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                tag.CreatedAt = DateTime.Today;
                if(tag.PublishedAt <= DateTime.Today)
                {
                    tag.IsPublished = true;
                }
                else
                {
                    tag.IsPublished = false;
                }
                db.Tags.Add(tag);
                db.SaveChanges();
                TempData["success"] = "Tag #"+tag.ID+" '"+tag.Title + "' has been added to the list !";
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckStatus = tag.IsPublished;

            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,IsPublished,CreatedAt,ModifiedAt,PublishedAt")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                tag.ModifiedAt = DateTime.Today;
                if (tag.PublishedAt <= DateTime.Today)
                {
                    tag.IsPublished = true;
                }
                else
                {
                    tag.IsPublished = false;
                }
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Tag #" + tag.ID + " '" + tag.Title + "' has been updated !";
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckStatus = tag.IsPublished;
           
            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
           
                db.Tags.Remove(tag);
                db.SaveChanges();
            TempData["success"] = "Tag #" + tag.ID + " '" + tag.Title + "' has been removed from the list !";
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
