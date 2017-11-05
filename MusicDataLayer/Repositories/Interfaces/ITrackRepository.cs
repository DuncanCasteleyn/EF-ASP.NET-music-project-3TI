using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDataModels;

namespace MusicDataLayer.Repositories.Interfaces
{
    public interface ITrackRepository : IDisposable
    {
        IEnumerable<Track> GetTracks();
        Track GetTrackById(int trackId);
        void InsertStudent(Track track);
        void DeleteStudent(int studentId);
        void Save();
    }
}
