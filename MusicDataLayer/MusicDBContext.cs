using System.Data.Entity;
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

        public DbSet<AlbumTrack> AlbumTracks { get; set; }

        public DbSet<PlayListTrack> PlayListTracks { get; set; }

        public DbSet<TrackGenre> TrackGenres { get; set; }

        public DbSet<TrackArtist> TrackArtists { get; set; }
    }
}
