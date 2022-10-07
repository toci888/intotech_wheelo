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

namespace Toci.Driver.Ui.Api.Areas.AssociatedWall.Controllers
{
    public class AssociatedGroupWallsController : ApiController
    {
        private DriverEntities db = new DriverEntities();

        // GET: api/AssociatedGroupWalls
        public IQueryable<AssociatedGroupWall> GetAssociatedGroupWall()
        {
            return db.AssociatedGroupWall;
        }

        // GET: api/AssociatedGroupWalls/5
        [ResponseType(typeof(AssociatedGroupWall))]
        public IHttpActionResult GetAssociatedGroupWall(long id)
        {
            AssociatedGroupWall associatedGroupWall = db.AssociatedGroupWall.Find(id);
            if (associatedGroupWall == null)
            {
                return NotFound();
            }

            return Ok(associatedGroupWall);
        }

        // PUT: api/AssociatedGroupWalls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssociatedGroupWall(long id, AssociatedGroupWall associatedGroupWall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != associatedGroupWall.Id)
            {
                return BadRequest();
            }

            db.Entry(associatedGroupWall).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociatedGroupWallExists(id))
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

        // POST: api/AssociatedGroupWalls
        [ResponseType(typeof(AssociatedGroupWall))]
        public IHttpActionResult PostAssociatedGroupWall(AssociatedGroupWall associatedGroupWall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssociatedGroupWall.Add(associatedGroupWall);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = associatedGroupWall.Id }, associatedGroupWall);
        }

        // DELETE: api/AssociatedGroupWalls/5
        [ResponseType(typeof(AssociatedGroupWall))]
        public IHttpActionResult DeleteAssociatedGroupWall(long id)
        {
            AssociatedGroupWall associatedGroupWall = db.AssociatedGroupWall.Find(id);
            if (associatedGroupWall == null)
            {
                return NotFound();
            }

            db.AssociatedGroupWall.Remove(associatedGroupWall);
            db.SaveChanges();

            return Ok(associatedGroupWall);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssociatedGroupWallExists(long id)
        {
            return db.AssociatedGroupWall.Count(e => e.Id == id) > 0;
        }
    }
}