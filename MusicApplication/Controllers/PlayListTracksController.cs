using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicDataLayer;
using MusicDataModels;
using static MusicDataLayer.DisconnectedMusicContext.PlaylistTrackManager;

namespace MusicApplication.Controllers
{
    public class PlaylistTracksController : Controller
    {
        // GET: PlaylistTracks
        public ActionResult Index()
        {
            return View(GetPlaylistTracks());
        }

        // GET: PlaylistTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaylistTrack playlistTrack = GetPlaylistTrack(id.Value);
            if (playlistTrack == null)
            {
                return HttpNotFound();
            }
            return View(playlistTrack);
        }

        // GET: PlaylistTracks/Create
        public ActionResult Create()
        {
            using (var db = new MusicDbContext())
            {
                ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name");
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name");
                return View();
            }
        }

        // POST: PlaylistTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,PlaylistId,TrackNumber")] PlaylistTrack playlistTrack)
        {
            if (ModelState.IsValid)
            {
                AddPlaylistTrack(playlistTrack);
                return RedirectToAction("Index");
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playlistTrack.PlaylistId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playlistTrack.TrackId);
                return View(playlistTrack);
            }
        }

        // GET: PlaylistTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaylistTrack playlistTrack = GetPlaylistTrack(id.Value);
            if (playlistTrack == null)
            {
                return HttpNotFound();
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playlistTrack.PlaylistId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playlistTrack.TrackId);
                return View(playlistTrack);
            }
        }

        // POST: PlaylistTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,PlaylistId,TrackNumber")] PlaylistTrack playlistTrack)
        {
            if (ModelState.IsValid)
            {
                EditPlaylistTrack(playlistTrack);
                return RedirectToAction("Index");
            }
            using (var db = new MusicDbContext())
            {
                ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", playlistTrack.PlaylistId);
                ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Name", playlistTrack.TrackId);
                return View(playlistTrack);
            }
        }

        // GET: PlaylistTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaylistTrack playlistTrack = GetPlaylistTrack(id.Value);
            if (playlistTrack == null)
            {
                return HttpNotFound();
            }
            return View(playlistTrack);
        }

        // POST: PlaylistTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaylistTrack playlistTrack = GetPlaylistTrack(id);
            DeletePlaylistTrack(playlistTrack);
            return RedirectToAction("Index");
        }
    }
}
