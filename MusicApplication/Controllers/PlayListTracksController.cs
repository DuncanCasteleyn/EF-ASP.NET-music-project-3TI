using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;

namespace MusicApplication.Controllers
{
    public class PlayListTracksController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: PlayListTracks
        public ActionResult Index()
        {
            var playListTracks = db.PlayListTracks.Include(p => p.Playlist).Include(p => p.Track);
            return View(playListTracks.ToList());
        }

        // GET: PlayListTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListTrack playListTrack = db.PlayListTracks.Find(id);
            if (playListTrack == null)
            {
                return HttpNotFound();
            }
            return View(playListTrack);
        }

        // GET: PlayListTracks/Create
        public ActionResult Create()
        {
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name");
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
            return View();
        }

        // POST: PlayListTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,PlaylistId,TrackNumber")] PlayListTrack playListTrack)
        {
            if (ModelState.IsValid)
            {
                db.PlayListTracks.Add(playListTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playListTrack.PlaylistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playListTrack.TrackId);
            return View(playListTrack);
        }

        // GET: PlayListTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListTrack playListTrack = db.PlayListTracks.Find(id);
            if (playListTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playListTrack.PlaylistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playListTrack.TrackId);
            return View(playListTrack);
        }

        // POST: PlayListTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,PlaylistId,TrackNumber")] PlayListTrack playListTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playListTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playListTrack.PlaylistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playListTrack.TrackId);
            return View(playListTrack);
        }

        // GET: PlayListTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListTrack playListTrack = db.PlayListTracks.Find(id);
            if (playListTrack == null)
            {
                return HttpNotFound();
            }
            return View(playListTrack);
        }

        // POST: PlayListTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayListTrack playListTrack = db.PlayListTracks.Find(id);
            db.PlayListTracks.Remove(playListTrack);
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
