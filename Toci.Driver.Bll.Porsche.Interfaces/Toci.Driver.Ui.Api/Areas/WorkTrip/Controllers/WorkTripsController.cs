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
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Ui.Api.Areas.WorkTrip.Controllers
{
    public class WorkTripsController : ApiController
    {
        private DriverEntities db = new DriverEntities();

        // GET: api/WorkTrips
        public IQueryable<Dal.Invitation.Interfaces.WorkTrip> GetWorkTrip()
        {
            return db.WorkTrip;
        }

        // GET: api/WorkTrips/5
        [ResponseType(typeof(Dal.Invitation.Interfaces.WorkTrip))]
        public IHttpActionResult GetWorkTrip(long id)
        {
            Dal.Invitation.Interfaces.WorkTrip workTrip = db.WorkTrip.Find(id);
            if (workTrip == null)
            {
                return NotFound();
            }

            return Ok(workTrip);
        }

        // PUT: api/WorkTrips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkTrip(long id, Dal.Invitation.Interfaces.WorkTrip workTrip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workTrip.Id)
            {
                return BadRequest();
            }

            db.Entry(workTrip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTripExists(id))
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

        // POST: api/WorkTrips
        [ResponseType(typeof(Dal.Invitation.Interfaces.WorkTrip))]
        public IHttpActionResult PostWorkTrip(Dal.Invitation.Interfaces.WorkTrip workTrip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkTrip.Add(workTrip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workTrip.Id }, workTrip);
        }

        // DELETE: api/WorkTrips/5
        [ResponseType(typeof(Dal.Invitation.Interfaces.WorkTrip))]
        public IHttpActionResult DeleteWorkTrip(long id)
        {
            Dal.Invitation.Interfaces.WorkTrip workTrip = db.WorkTrip.Find(id);
            if (workTrip == null)
            {
                return NotFound();
            }

            db.WorkTrip.Remove(workTrip);
            db.SaveChanges();

            return Ok(workTrip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkTripExists(long id)
        {
            return db.WorkTrip.Count(e => e.Id == id) > 0;
        }
    }
}