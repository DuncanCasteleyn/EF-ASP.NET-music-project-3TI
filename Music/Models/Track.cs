using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Track
    {
        public Track()
        {
            Artists = new HashSet<Artist>();
            Genres = new HashSet<Genre>();
            AlbumTracks = new HashSet<AlbumTrack>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public DateTime Release { get; set; }
        public long NumberOfPlay { get; set; }
        public string TrackLocation { get; set; }

        public ICollection<Artist> Artists { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}