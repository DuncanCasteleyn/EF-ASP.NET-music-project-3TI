﻿using System.Data.Entity;
using MusicDataModels;

namespace MusicDataLayer
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public System.Data.Entity.DbSet<MusicDataModels.AlbumTrack> AlbumTracks { get; set; }

        public System.Data.Entity.DbSet<MusicDataModels.PlayListTrack> PlayListTracks { get; set; }
    }
}
