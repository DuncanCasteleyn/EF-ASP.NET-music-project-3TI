using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDataModels
{
    public class Playlist
    {
        public Playlist()
        {
            AlbumTracks = new HashSet<PlayListTrack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public ICollection<PlayListTrack> AlbumTracks { get; set; }
    }
}
