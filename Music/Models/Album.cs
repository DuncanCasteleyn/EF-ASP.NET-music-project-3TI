using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album
    {
        public Album()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }

        public ICollection<AlbumTrack> AlbumTracks { get; set; }
    }
}
