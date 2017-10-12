using System.Collections.Generic;

namespace Music.Models
{
    public class Playlist
    {
        public Playlist()
        {
            AlbumTracks = new HashSet<PlaylistTrack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> AlbumTracks { get; set; }
    }
}
