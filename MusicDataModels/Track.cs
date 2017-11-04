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
            TrackArtists = new HashSet<TrackArtist>();
            TrackGenres = new HashSet<TrackGenre>();
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
        public ICollection<TrackArtist> TrackArtists { get; set; }
        [Required]
        public ICollection<TrackGenre> TrackGenres { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
        public ICollection<PlayListTrack> PlaylistTracks { get; set; }
    }
}
