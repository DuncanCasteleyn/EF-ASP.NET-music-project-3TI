using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDataModels
{
    public class Playlist
    {
        public Playlist()
        {
            PlayListTracks = new HashSet<PlaylistTrack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public ICollection<PlaylistTrack> PlayListTracks { get; set; }
    }
}
