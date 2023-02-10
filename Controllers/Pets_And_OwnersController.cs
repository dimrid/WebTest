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
using WebTest.Models;

namespace WebTest.Controllers
{
    public class Pets_And_OwnersController : ApiController
    {
        private PetsEntities1 db = new PetsEntities1();

        // GET: api/Pets_And_Owners
        public IQueryable<Pets_And_Owners> GetPets_And_Owners()
        {
            return db.Pets_And_Owners;
        }

        // GET: api/Pets_And_Owners/5
        [ResponseType(typeof(Pets_And_Owners))]
        public IHttpActionResult GetPets_And_Owners(string id)
        {
            Pets_And_Owners pets_And_Owners = db.Pets_And_Owners.Find(id);
            if (pets_And_Owners == null)
            {
                return NotFound();
            }

            return Ok(pets_And_Owners);
        }

        // PUT: api/Pets_And_Owners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPets_And_Owners(string id, Pets_And_Owners pets_And_Owners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pets_And_Owners.Порода)
            {
                return BadRequest();
            }

            db.Entry(pets_And_Owners).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pets_And_OwnersExists(id))
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

        // POST: api/Pets_And_Owners
        [ResponseType(typeof(Pets_And_Owners))]
        public IHttpActionResult PostPets_And_Owners(Pets_And_Owners pets_And_Owners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets_And_Owners.Add(pets_And_Owners);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Pets_And_OwnersExists(pets_And_Owners.Порода))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pets_And_Owners.Порода }, pets_And_Owners);
        }

        // DELETE: api/Pets_And_Owners/5
        [ResponseType(typeof(Pets_And_Owners))]
        public IHttpActionResult DeletePets_And_Owners(string id)
        {
            Pets_And_Owners pets_And_Owners = db.Pets_And_Owners.Find(id);
            if (pets_And_Owners == null)
            {
                return NotFound();
            }

            db.Pets_And_Owners.Remove(pets_And_Owners);
            db.SaveChanges();

            return Ok(pets_And_Owners);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pets_And_OwnersExists(string id)
        {
            return db.Pets_And_Owners.Count(e => e.Порода == id) > 0;
        }
    }
}