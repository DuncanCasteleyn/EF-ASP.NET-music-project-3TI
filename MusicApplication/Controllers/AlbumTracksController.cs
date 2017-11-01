using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;

namespace MusicApplication.Controllers
{
    public class AlbumTracksController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: AlbumTracks
        public ActionResult Index()
        {
            var albumTracks = db.AlbumTracks.Include(a => a.Album).Include(a => a.Track);
            return View(albumTracks.ToList());
        }

        // GET: AlbumTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = db.AlbumTracks.Find(id);
            if (albumTrack == null)
            {
                return HttpNotFound();
            }
            return View(albumTrack);
        }

        // GET: AlbumTracks/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
            return View();
        }

        // POST: AlbumTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,AlbumId,TrackNumber")] AlbumTrack albumTrack)
        {
            if (ModelState.IsValid)
            {
                db.AlbumTracks.Add(albumTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
            return View(albumTrack);
        }

        // GET: AlbumTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = db.AlbumTracks.Find(id);
            if (albumTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
            return View(albumTrack);
        }

        // POST: AlbumTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,AlbumId,TrackNumber")] AlbumTrack albumTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
            return View(albumTrack);
        }

        // GET: AlbumTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = db.AlbumTracks.Find(id);
            if (albumTrack == null)
            {
                return HttpNotFound();
            }
            return View(albumTrack);
        }

        // POST: AlbumTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumTrack albumTrack = db.AlbumTracks.Find(id);
            db.AlbumTracks.Remove(albumTrack);
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
