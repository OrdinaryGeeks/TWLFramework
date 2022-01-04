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
using TWLFramework.Models;

namespace TWLFramework.Controllers
{
    public class TrainersAPIController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TrainersAPI
        public IQueryable<Trainer> GetTrainers()
        {
            return db.Trainers;
        }

        // GET: api/TrainersAPI/5
        [ResponseType(typeof(Trainer))]
        public IHttpActionResult GetTrainer(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/TrainersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainer(int id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainer.ID)
            {
                return BadRequest();
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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

        // POST: api/TrainersAPI
        [ResponseType(typeof(Trainer))]
        public IHttpActionResult PostTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(trainer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainer.ID }, trainer);
        }

        // DELETE: api/TrainersAPI/5
        [ResponseType(typeof(Trainer))]
        public IHttpActionResult DeleteTrainer(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return NotFound();
            }

            db.Trainers.Remove(trainer);
            db.SaveChanges();

            return Ok(trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerExists(int id)
        {
            return db.Trainers.Count(e => e.ID == id) > 0;
        }
    }
}