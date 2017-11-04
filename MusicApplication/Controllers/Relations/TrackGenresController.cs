using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;

namespace MusicApplication.Controllers.Relations
{
    public class TrackGenresController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: TrackGenres
        public ActionResult Index()
        {
            var trackGenres = db.TrackGenres.Include(t => t.Genre).Include(t => t.Track);
            return View(trackGenres.ToList());
        }

        // GET: TrackGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackGenre trackGenre = db.TrackGenres.Find(id);
            if (trackGenre == null)
            {
                return HttpNotFound();
            }
            return View(trackGenre);
        }

        // GET: TrackGenres/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
            return View();
        }

        // POST: TrackGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,GenreId")] TrackGenre trackGenre)
        {
            if (ModelState.IsValid)
            {
                db.TrackGenres.Add(trackGenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", trackGenre.GenreId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackGenre.TrackId);
            return View(trackGenre);
        }

        // GET: TrackGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackGenre trackGenre = db.TrackGenres.Find(id);
            if (trackGenre == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", trackGenre.GenreId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackGenre.TrackId);
            return View(trackGenre);
        }

        // POST: TrackGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,GenreId")] TrackGenre trackGenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackGenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", trackGenre.GenreId);
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", trackGenre.TrackId);
            return View(trackGenre);
        }

        // GET: TrackGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackGenre trackGenre = db.TrackGenres.Find(id);
            if (trackGenre == null)
            {
                return HttpNotFound();
            }
            return View(trackGenre);
        }

        // POST: TrackGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackGenre trackGenre = db.TrackGenres.Find(id);
            db.TrackGenres.Remove(trackGenre);
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
