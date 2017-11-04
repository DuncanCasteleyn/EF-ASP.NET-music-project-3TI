using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class PlayListTrack
    {
        [Key]
        [Column(Order = 0)]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        [Required]
        public int TrackNumber { get; set; }
    }
}
