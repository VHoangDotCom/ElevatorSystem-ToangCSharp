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
            TempData["0"] = "Status : 0 - Pending";
            TempData["1"] = "Status : 1 - Available";
            TempData["2"] = "Status : 2 - Upgrading";
            TempData["3"] = "Status : 3 - Out of date";
            TempData["n"] = "Status : n - Status is undefined";
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

        // GET: Elevators/Create
        public ActionResult Create()
        {
            
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Elevators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
        }

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
