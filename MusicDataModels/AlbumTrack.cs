using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class AlbumTrack
    {
        [Key]
        [Column(Order = 0)]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        [Key]
        [Column(Order = 1)]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [Required]
        public int TrackNumber { get; set; }
    }
}
