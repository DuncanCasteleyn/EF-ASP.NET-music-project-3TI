using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class TrackArtist
    {
        [Key]
        [Column(Order = 0)]
        public int TrackId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ArtistId { get; set; }

        public virtual Track Track { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
