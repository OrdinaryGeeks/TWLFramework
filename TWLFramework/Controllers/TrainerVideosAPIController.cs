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
using System.Web.Http.Cors;


namespace TWLFramework.Controllers
{
   // [EnableCors(origins:"http://ordinarygeeksllc.com", headers: "*", methods: "*" )]

    public class TrainerVideosAPIController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TrainerVideosAPI
        public IQueryable<TrainerVideo> GetTrainerVideos()
        {
            return db.TrainerVideos;
        }
        //[EnableCors(origins: "http://ordinarygeeksllc.com", headers: "*", methods: "*")]

        // GET: api/TrainerVideosAPI/5
        [ResponseType(typeof(TrainerVideo))]
        public IHttpActionResult GetTrainerVideo(int id)
        {
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            if (trainerVideo == null)
            {
                return NotFound();
            }

            return Ok(trainerVideo);
        }

        // PUT: api/TrainerVideosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainerVideo(int id, TrainerVideo trainerVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainerVideo.ID)
            {
                return BadRequest();
            }

            db.Entry(trainerVideo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerVideoExists(id))
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

        // POST: api/TrainerVideosAPI
        [ResponseType(typeof(TrainerVideo))]
        public IHttpActionResult PostTrainerVideo(TrainerVideo trainerVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainerVideos.Add(trainerVideo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainerVideo.ID }, trainerVideo);
        }

        // DELETE: api/TrainerVideosAPI/5
        [ResponseType(typeof(TrainerVideo))]
        public IHttpActionResult DeleteTrainerVideo(int id)
        {
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            if (trainerVideo == null)
            {
                return NotFound();
            }

            db.TrainerVideos.Remove(trainerVideo);
            db.SaveChanges();

            return Ok(trainerVideo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerVideoExists(int id)
        {
            return db.TrainerVideos.Count(e => e.ID == id) > 0;
        }
    }
}