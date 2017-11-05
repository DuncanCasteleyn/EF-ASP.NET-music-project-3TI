using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDataLayer.Repositories.Interfaces;
using MusicDataModels;

namespace MusicDataLayer.Repositories
{
    class TrackRepository : ITrackRepository
    {
        private MusicDbContext db = new MusicDbContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Track> GetTracks()
        {
            return db.Tracks
                .Include(track => track.Artists)
                .Include(track => track.Genres)
                .ToList();
        }

        public Track GetTrackById(int trackId)
        {
            return db.Tracks
                .Include(track1 => track1.Artists)
                .Include(track1 => track1.Genres)
                .FirstOrDefault(track1 => track1.Id == trackId);
        }

        public void InsertStudent(Track track, IEnumerable<Artist> artists, IEnumerable<Genre> genres)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
