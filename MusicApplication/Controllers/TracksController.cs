using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicApplication.Models;
using MusicDataLayer;
using MusicDataModels;

namespace MusicApplication.Controllers
{
    public class TracksController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: Tracks
        public ActionResult Index()
        {
            var tracks = db.Tracks
               .Include(track => track.Artists)
               .Include(track => track.Genres);
            return View(tracks.ToList());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Track track = db.Tracks.Find(id);

            if (track == null)
            {
                return HttpNotFound();
            }

            db.Entry(track).Collection(track1 => track1.Artists).Load();
            db.Entry(track).Collection(track1 => track1.Genres).Load();

            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            var trackArtistViewModel = new TrackViewModel();
            var allArtistsList = db.Artists.ToList();
            trackArtistViewModel.AllArtists = allArtistsList.Select(artist =>
                new SelectListItem()
                {
                    Text = artist.Name,
                    Value = artist.Id.ToString()
                }
            );

            var allGenresList = db.Genres.ToList();
            trackArtistViewModel.AllGenres = allGenresList.Select(artist =>
                new SelectListItem()
                {
                    Text = artist.Name,
                    Value = artist.Id.ToString()
                }
            );
            return View(trackArtistViewModel);
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackViewModel trackView)
        {
            if (ModelState.IsValid)
            {
                var artists = db.Artists.Include(artist => artist.Tracks).ToList().FindAll(artist => trackView.SelectedArtists.Contains(artist.Id));
                var genres = db.Genres.Include(genre => genre.Tracks).ToList().FindAll(genre => trackView.SelectedGenres.Contains(genre.Id));
                trackView.Track.Artists = artists;
                trackView.Track.Genres = genres;
                artists.ForEach(artist => artist.Tracks.Add(trackView.Track));
                genres.ForEach(genre => genre.Tracks.Add(trackView.Track));

                db.Tracks.Add(trackView.Track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackView);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trackArtistViewModel = new TrackViewModel
            {
                Track = db.Tracks.Include(track => track.Artists).Include(track => track.Genres).FirstOrDefault(i => i.Id == id),
            };

            if (trackArtistViewModel.Track == null)
            {
                return HttpNotFound();
            }

            var allArtistsList = db.Artists.ToList();
            trackArtistViewModel.AllArtists = allArtistsList.Select(artist =>
                new SelectListItem()
                {
                    Text = artist.Name,
                    Value = artist.Id.ToString()
                }
            );

            var allGenresList = db.Genres.ToList();
            trackArtistViewModel.AllGenres = allGenresList.Select(artist =>
                new SelectListItem()
                {
                    Text = artist.Name,
                    Value = artist.Id.ToString()
                }
            );


            return View(trackArtistViewModel);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrackViewModel trackView)
        {
            if (ModelState.IsValid)
            {
                /* Causes a key error due to the fact that we are creating a new collection which is untracked which will cause duplicated keys
                    Need to filter our the added keys and the find the removed keys
                
                var artists = db.Artists.Include(artist => artist.Tracks).ToList().FindAll(artist => trackView.SelectedArtists.Contains(artist.Id));
                var genres = db.Genres.Include(genre => genre.Tracks).ToList().FindAll(genre => trackView.SelectedGenres.Contains(genre.Id));
                trackView.Track.Artists = artists;
                trackView.Track.Genres = genres;
                artists.ForEach(artist => artist.Tracks.Add(trackView.Track));
                genres.ForEach(genre => genre.Tracks.Add(trackView.Track));

                db.Tracks.Attach(trackView.Track);*/
                db.Entry(trackView.Track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackView);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);

            if (track == null)
            {
                return HttpNotFound();
            }

            db.Entry(track).Collection(track1 => track1.Artists).Load();
            db.Entry(track).Collection(track1 => track1.Genres).Load();

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
