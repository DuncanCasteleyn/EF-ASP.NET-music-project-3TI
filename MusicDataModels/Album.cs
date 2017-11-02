using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class Album
    {
        public Album()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Release { get; set; }

        [Required]
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
    }
}
