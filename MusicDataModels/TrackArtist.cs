using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class TrackArtist
    {
        [Column(Order = 0)]
        public int Id;

        [Key]
        [Column(Order = 1)]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
