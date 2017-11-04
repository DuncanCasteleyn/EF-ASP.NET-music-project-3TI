using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class TrackArtist
    {
        [Key]
        [Column(Order = 0)]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
