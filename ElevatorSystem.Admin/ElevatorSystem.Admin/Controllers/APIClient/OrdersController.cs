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
    public class OrdersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Orders
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            var order = db.Orders.Where(o => o.ID == id);
            var dataOrder = db.Order_Items.Where(ot => ot.OrderID == id)
                            .Join(db.Elevators,
                                ot => ot.ElevatorID,
                                e => e.ID,
                                (ot, e) => new
                                {
                                    Quantity = ot.Quantity,
                                    OrderItemsId = ot.ID,
                                    NumberOfFloor = ot.NumberOfFloor,
                                    Elevator = ot.Elevator
                                }
                                ).ToArray();


            return Ok(new { order, dataOrder });
        }

        // PUT: api/Orders/5
        [System.Web.Http.Authorize(Roles = "user")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return Ok("loi");
            }

            if (id != order.ID)
            {
                return Ok("loi  ID");
            }
            Random rd = new Random();
            order.SKU = "ELEVATOR00" + rd.Next(1, 1000000).ToString();
            order.CreatedAt = DateTime.Today;
            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { success = true });
        }


        // POST: api/Orders
        [System.Web.Http.Authorize(Roles = "user")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(OrderViewModel order)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
            Random rd = new Random();
            string query = "INSERT INTO Orders(Total,FullName,SKU,PhoneNumber,Address,Description," +
                            "ShippingFee,Tax,OrderEmail,OrderStatus,ShipStatus,CreatedAt,ApplicationUser_Id) " +
                            "Values(@Total,@FullName,@SKU,@PhoneNumber,@Address,@Description,@ShippingFee,@Tax," +
                            "@OrderEmail,@OrderStatus,@ShipStatus,@CreatedAt,@ApplicationUser_Id) ";

            string SKU = "ELEVATOR00" + rd.Next(1, 1000000).ToString();
            var dbset = db.Database.SqlQuery<OrderViewModel>(query,
                            new SqlParameter("@Total", order.Total),
                            new SqlParameter("@FullName", order.FullName),
                            new SqlParameter("@SKU",SKU),
                            new SqlParameter("@PhoneNumber", order.PhoneNumber),
                            new SqlParameter("@Address", order.Address),
                            new SqlParameter("@Description", order.Description),
                            new SqlParameter("@ShippingFee", 1),
                            new SqlParameter("@Tax", 10),
                            new SqlParameter("@OrderEmail", order.OrderEmail),
                            new SqlParameter("@OrderStatus", order.OrderStatus),
                            new SqlParameter("@ShipStatus", order.ShipStatus),
                            new SqlParameter("@CreatedAt", DateTime.Today),
                            new SqlParameter("@ApplicationUser_Id", id)
                            );
            var findOrder = db.Database.SqlQuery<int>("select ID from Orders where SKU = @SKU", new SqlParameter("@SKU", SKU));

            return Ok(new { dbset, success = true, findOrder });
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}