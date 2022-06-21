using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;

namespace ElevatorSystem.Admin.Controllers.APIClient
{
    public class ElevatorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Elevators
        public IQueryable<Elevator> GetElevators()
        {
            return db.Elevators;
        }

        // GET: api/Elevators/5
        [ResponseType(typeof(Elevator))]
        public IHttpActionResult GetElevator(int id)
        {
            Elevator elevator = db.Elevators.Find(id);
            if (elevator == null)
            {
                return NotFound();
            }

            return Ok(elevator);
        }

        // PUT: api/Elevators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElevator(int id, Elevator elevator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elevator.ID)
            {
                return BadRequest();
            }

            db.Entry(elevator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Elevators
        [ResponseType(typeof(Elevator))]
        public IHttpActionResult PostElevator(Elevator elevator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elevators.Add(elevator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = elevator.ID }, elevator);
        }

        // DELETE: api/Elevators/5
        [ResponseType(typeof(Elevator))]
        public IHttpActionResult DeleteElevator(int id)
        {
            Elevator elevator = db.Elevators.Find(id);
            if (elevator == null)
            {
                return NotFound();
            }

            db.Elevators.Remove(elevator);
            db.SaveChanges();

            return Ok(elevator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElevatorExists(int id)
        {
            return db.Elevators.Count(e => e.ID == id) > 0;
        }
    }
}