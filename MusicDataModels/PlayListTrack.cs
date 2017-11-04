using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class PlayListTrack
    {
        public int Id { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        [Required]
        public int TrackNumber { get; set; }
    }
}
