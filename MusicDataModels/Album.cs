using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public DateTime Release { get; set; }

        [Required]
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
    }
}
