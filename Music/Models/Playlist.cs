using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public ICollection<PlaylistTrack> AlbumTracks { get; set; }
    }
}