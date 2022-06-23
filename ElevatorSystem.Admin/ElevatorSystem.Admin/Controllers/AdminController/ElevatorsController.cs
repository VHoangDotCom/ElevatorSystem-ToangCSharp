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
    public class ElevatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Elevators
        public ActionResult Index()
        {
            var elevators = db.Elevators.Include(e => e.Category);
            return View(elevators.ToList());
        }

        // GET: Elevators/Details/5
        public ActionResult Details(int? id)
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
            return View(elevator);
        }

        // GET: Elevators/Create
        public ActionResult Create()
        {
           // ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View("Create");
        }

        [HttpPost]
        public string UploadImages(HttpPostedFileBase file)
        {
            Random r = new Random();
            int num = r.Next();

            file.SaveAs(Server.MapPath("~/Content/Elevator/") + num + "_" + file.FileName);
            return "/Content/Elevator/" + num + "_" + file.FileName;
        }

        // POST: Elevators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create( Elevator elevator)
        {
            if (ModelState.IsValid)
            {
                db.Elevators.Add(elevator);
                db.SaveChanges();
            }

           // ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
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

        // POST: Elevators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Elevator elevator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elevator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
            return View(elevator);
        }

        // GET: Elevators/Delete/5
        public ActionResult Delete(int? id)
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
            return View(elevator);
        }

        // POST: Elevators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elevator elevator = db.Elevators.Find(id);
            db.Elevators.Remove(elevator);
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
