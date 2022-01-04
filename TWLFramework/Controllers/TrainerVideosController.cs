using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TWLFramework.Models;

namespace TWLFramework.Controllers
{
    public class TrainerVideosController : Controller
    {
        private DBContext db = new DBContext();



        string GetEmbedLink(string strUrl)
        {

            

            string id = FnGetVideoID(strUrl);

            if (!string.IsNullOrEmpty(id))
            {
                strUrl = string.Format("http://youtube.com/embed/{0}", id);
            }
            else
            {
                strUrl = "";
                
            }

            return strUrl;
           
        }
        static string FnGetVideoID(string strVideoURL)
        {
            const string regExpPattern = @"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)";
            //for Vimeo: vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)
            var regEx = new Regex(regExpPattern);
            var match = regEx.Match(strVideoURL);
            return match.Success ? match.Groups[1].Value : null;
        }

        // GET: TrainerVideos
        public ActionResult Index()
        {
            return View(db.TrainerVideos.ToList());
        }

        // GET: TrainerVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            if (trainerVideo == null)
            {
                return HttpNotFound();
            }
            return View(trainerVideo);
        }

        // GET: TrainerVideos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TrainerID,URL,Tags")] TrainerVideo trainerVideo)
        {
            if (ModelState.IsValid)
            {
                trainerVideo.URL = FnGetVideoID(trainerVideo.URL);

                
                db.TrainerVideos.Add(trainerVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainerVideo);
        }

        // GET: TrainerVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            if (trainerVideo == null)
            {
                return HttpNotFound();
            }
            return View(trainerVideo);
        }

        // POST: TrainerVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrainerID,URL,Tags")] TrainerVideo trainerVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainerVideo);
        }

        // GET: TrainerVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            if (trainerVideo == null)
            {
                return HttpNotFound();
            }
            return View(trainerVideo);
        }

        // POST: TrainerVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerVideo trainerVideo = db.TrainerVideos.Find(id);
            db.TrainerVideos.Remove(trainerVideo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
