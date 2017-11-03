using System.Net;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;
using static MusicDataLayer.DisconnectedMusicContext.AlbumTracksManager;

namespace MusicApplication.Controllers
{
    public class AlbumTracksController : Controller
    {

        // GET: AlbumTracks
        public ActionResult Index()
        {
            return View(GetAlbumTracks());
        }

        // GET: AlbumTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = GetAlbumTrack(id.Value);
            if (albumTrack == null)
            {
                return HttpNotFound();
            }
            return View(albumTrack);
        }

        // GET: AlbumTracks/Create
        public ActionResult Create()
        {
            using (var db = new MusicDbContext())
            {
                ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
                return View();
            }
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
                AddAlbumTrack(albumTrack);
                return RedirectToAction("Index");
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
                return View(albumTrack);
            }
        }

        // GET: AlbumTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = GetAlbumTrack(id.Value);
            if (albumTrack == null)
            {
                return HttpNotFound();
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
                return View(albumTrack);
            }
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
                EditAlbumTrack(albumTrack);
                return RedirectToAction("Index");
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", albumTrack.AlbumId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", albumTrack.TrackId);
                return View(albumTrack);
            }
        }

        // GET: AlbumTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTrack albumTrack = GetAlbumTrack(id.Value);
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
            AlbumTrack albumTrack = GetAlbumTrack(id);
            DeleteAlbumTrack(albumTrack);
            return RedirectToAction("Index");
        }
    }
}
