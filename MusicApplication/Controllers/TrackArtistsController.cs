using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;

namespace MusicApplication.Controllers
{
    public class TrackArtistsController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: TrackArtists
        public ActionResult Index()
        {
            var trackArtists = db.TrackArtists.Include(t => t.Artist).Include(t => t.Track);
            return View(trackArtists.ToList());
        }

        // GET: TrackArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackArtist trackArtist = db.TrackArtists.Find(id);
            if (trackArtist == null)
            {
                return HttpNotFound();
            }
            return View(trackArtist);
        }

        // GET: TrackArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name");
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
            return View();
        }

        // POST: TrackArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,ArtistId")] TrackArtist trackArtist)
        {
            if (ModelState.IsValid)
            {
                db.TrackArtists.Add(trackArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", trackArtist.ArtistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackArtist.TrackId);
            return View(trackArtist);
        }

        // GET: TrackArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackArtist trackArtist = db.TrackArtists.Find(id);
            if (trackArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", trackArtist.ArtistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackArtist.TrackId);
            return View(trackArtist);
        }

        // POST: TrackArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,ArtistId")] TrackArtist trackArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", trackArtist.ArtistId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackArtist.TrackId);
            return View(trackArtist);
        }

        // GET: TrackArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackArtist trackArtist = db.TrackArtists.Find(id);
            if (trackArtist == null)
            {
                return HttpNotFound();
            }
            return View(trackArtist);
        }

        // POST: TrackArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackArtist trackArtist = db.TrackArtists.Find(id);
            db.TrackArtists.Remove(trackArtist);
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
