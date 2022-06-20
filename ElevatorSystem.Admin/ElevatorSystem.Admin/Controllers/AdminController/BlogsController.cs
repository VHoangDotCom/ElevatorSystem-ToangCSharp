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
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Tag);
            return View(blogs.ToList());
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
        public ActionResult Create([Bind(Include = "ID,Title,Summary,IsPublished,PostContent,Thumbnail,Slug,CreatedAt,ModifiedAt,PublishedAt,TagID")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.CreatedAt = DateTime.Today;
                if (blog.PublishedAt <= DateTime.Today)
                {
                    blog.IsPublished = true;
                }
                else
                {
                    blog.IsPublished = false;
                }
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagID = new SelectList(db.Tags, "ID", "Title", blog.TagID);
            return View(blog);
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
