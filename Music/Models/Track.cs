﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Track
    {
        public Track()
        {
            Artists = new HashSet<Artist>();
            Genres = new HashSet<Genre>();
            AlbumTracks = new HashSet<AlbumTrack>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
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
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}