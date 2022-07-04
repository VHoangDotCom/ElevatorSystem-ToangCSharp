using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.Entity;
using ElevatorSystem.Admin.Models.ViewModels;

namespace ElevatorSystem.Admin.Controllers.APIClient
{
    public class FeedbacksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/GetFeedbackByElevatorID/{elevatorID}")]
        [HttpGet]
        public IHttpActionResult GetFeedbackByElevatorID(int elevatorID)
        {
            var data = db.Elevators.Where(e => e.ID == elevatorID)
                .Join(db.Feedbacks, e => e.ID, f => f.ElevatorID,
                    (e, f) => new { Elevator_ID = e.ID, Feedback = e.Feedbacks }).FirstOrDefault();
            return Ok(new { success = true, data });
        }

        // api/SatisfyingLevel

        // POST: api/Feedbacks
        [System.Web.Http.Authorize(Roles = "user")]
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult PostFeedback(FeedbackViewModel feedback)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
            string queryString = "INSERT INTO Feedbacks(Description,SatisfyingLevel,Problem,Improvement,ApplicationUser_Id,ElevatorID)" +
                                 " VALUES(@Description,@SatisfyingLevel, @Problem,@Improvement,@ApplicationUser_Id,@ElevatorID)";
            var dbset = db.Database.SqlQuery<FeedbackViewModel>(queryString,
                                                    new SqlParameter("@Description", feedback.Description),
                                                    new SqlParameter("@SatisfyingLevel", feedback.SatisfyingLevel),
                                                    new SqlParameter("@Problem", feedback.Problem),
                                                    new SqlParameter("@Improvement", feedback.Improvement),
                                                    new SqlParameter("@ApplicationUser_Id", id),
                                                    new SqlParameter("@ElevatorID", feedback.ElevatorID)
                                                    );
            return Ok(new { dbset, success = true });
        }
    }
}