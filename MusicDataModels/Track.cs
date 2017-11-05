using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDataModels
{
    public class Track
    {
        public Track()
        {
            Artists = new HashSet<Artist>();
            Genres = new HashSet<Genre>();
            AlbumTracks = new HashSet<AlbumTrack>();
            PlaylistTracks = new HashSet<PlayListTrack>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Length { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Release { get; set; }
        [Required]
        public long NumberOfPlay { get; set; }
        [Required]
        public string TrackLocation { get; set; }

        [Required]
        public ICollection<Artist> Artists { get; set; }
        [Required]
        public ICollection<Genre> Genres { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
        public ICollection<PlayListTrack> PlaylistTracks { get; set; }
    }
}
