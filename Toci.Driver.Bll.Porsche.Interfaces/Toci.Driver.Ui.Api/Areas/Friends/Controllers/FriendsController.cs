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

namespace Toci.Driver.Ui.Api.Areas.Friends.Controllers
{
    public class FriendsController : ApiController
    {
        private DriverEntities db = new DriverEntities();

        // GET: api/Friends
        public IQueryable<Dal.Invitation.Interfaces.Friends> GetFriends()
        {
            return db.Friends;
        }

        // GET: api/Friends/5
        [ResponseType(typeof(Dal.Invitation.Interfaces.Friends))]
        public IHttpActionResult GetFriends(long id)
        {
            Dal.Invitation.Interfaces.Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return NotFound();
            }

            return Ok(friends);
        }

        // PUT: api/Friends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriends(long id, Dal.Invitation.Interfaces.Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friends.Id)
            {
                return BadRequest();
            }

            db.Entry(friends).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsExists(id))
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

        // POST: api/Friends
        [ResponseType(typeof(Dal.Invitation.Interfaces.Friends))]
        public IHttpActionResult PostFriends(Dal.Invitation.Interfaces.Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Friends.Add(friends);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friends.Id }, friends);
        }

        // DELETE: api/Friends/5
        [ResponseType(typeof(Dal.Invitation.Interfaces.Friends))]
        public IHttpActionResult DeleteFriends(long id)
        {
            Dal.Invitation.Interfaces.Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return NotFound();
            }

            db.Friends.Remove(friends);
            db.SaveChanges();

            return Ok(friends);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendsExists(long id)
        {
            return db.Friends.Count(e => e.Id == id) > 0;
        }
    }
}