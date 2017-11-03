using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicDataModels;

namespace MusicDataLayer
{
    public static class DisconnectedMusicContext
    {
        public static class AlbumsManager
        {
            public static List<Album> GetAlbums()
            {
                using (var db = new MusicDbContext())
                {
                    return db.Albums.ToList();
                }
            }

            public static Album GetAlbum(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.Albums.Find(id);
                }
            }

            public static void AddAlbum(Album album)
            {
                using (var db = new MusicDbContext())
                {
                    db.Albums.Add(album);
                    db.SaveChanges();
                }
            }

            public static void EditAlbum(Album album)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(album).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeleteAlbum(Album album)
            {
                using (var db = new MusicDbContext())
                {
                    db.Albums.Remove(album);
                    db.SaveChanges();
                }
            }
        }

        public static class AlbumTracksManager
        {
            public static List<AlbumTrack> GetAlbumTracks()
            {
                using (var db = new MusicDbContext())
                {
                    return db.AlbumTracks.Include(a => a.Album).Include(a => a.Track).ToList();
                }
            }

            public static AlbumTrack GetAlbumTrack(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.AlbumTracks.Find(id);
                }
            }

            public static void AddAlbumTrack(AlbumTrack albumTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.AlbumTracks.Add(albumTrack);
                    db.SaveChanges();
                }
            }

            public static void EditAlbumTrack(AlbumTrack albumTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(albumTrack).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeleteAlbumTrack(AlbumTrack albumTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.AlbumTracks.Remove(albumTrack);
                    db.SaveChanges();
                }
            }
        }

        public static class ArtistsManager
        {
            public static List<Artist> GetArtists()
            {
                using (var db = new MusicDbContext())
                {
                    return db.Artists.ToList();
                }
            }

            public static Artist GetArtist(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.Artists.Find(id);
                }
            }

            public static void AddArtist(Artist artist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Artists.Add(artist);
                    db.SaveChanges();
                }
            }

            public static void EditArtist(Artist artist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(artist).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeleteArtist(Artist artist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Artists.Remove(artist);
                    db.SaveChanges();
                }
            }
        }

        public static class GenresManager
        {
            public static List<Genre> GetGenres()
            {
                using (var db = new MusicDbContext())
                {
                    return db.Genres.ToList();
                }
            }

            public static Genre GetGenre(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.Genres.Find(id);
                }
            }

            public static void AddGenre(Genre genre)
            {
                using (var db = new MusicDbContext())
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                }
            }

            public static void EditGenre(Genre genre)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeleteGenre(Genre genre)
            {
                using (var db = new MusicDbContext())
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
            }
        }

        public static class PlaylistTrackManager
        {
            public static List<PlaylistTrack> GetPlaylistTracks()
            {
                using (var db = new MusicDbContext())
                {
                    return db.PlaylistTracks.Include(p => p.Playlist).Include(p => p.Track).ToList();
                }
            }

            public static PlaylistTrack GetPlaylistTrack(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.PlaylistTracks.Find(id);
                }
            }

            public static void AddPlaylistTrack(PlaylistTrack playlistTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.PlaylistTracks.Add(playlistTrack);
                    db.SaveChanges();
                }
            }

            public static void EditPlaylistTrack(PlaylistTrack playlistTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(playlistTrack).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeletePlaylistTrack(PlaylistTrack playlistTrack)
            {
                using (var db = new MusicDbContext())
                {
                    db.PlaylistTracks.Remove(playlistTrack);
                    db.SaveChanges();
                }
            }
        }

        public static class PlaylistManager
        {
            public static List<Playlist> GetPlaylists()
            {
                using (var db = new MusicDbContext())
                {
                    return db.Playlists.ToList();
                }
            }

            public static Playlist GetPlaylist(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.Playlists.Find(id);
                }
            }

            public static void AddPlaylist(Playlist playlist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Playlists.Add(playlist);
                    db.SaveChanges();
                }
            }

            public static void EditPlaylist(Playlist playlist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(playlist).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeletePlaylist(Playlist playlist)
            {
                using (var db = new MusicDbContext())
                {
                    db.Playlists.Remove(playlist);
                    db.SaveChanges();
                }
            }
        }

        public static class TrackManager
        {
            public static List<Track> GetTracks()
            {
                using (var db = new MusicDbContext())
                {
                    return db.Tracks.ToList();
                }
            }

            public static Track GetTrack(int id)
            {
                using (var db = new MusicDbContext())
                {
                    return db.Tracks.Find(id);
                }
            }

            public static void AddTrack(Track track)
            {
                using (var db = new MusicDbContext())
                {
                    db.Tracks.Add(track);
                    db.SaveChanges();
                }
            }

            public static void EditTrack(Track track)
            {
                using (var db = new MusicDbContext())
                {
                    db.Entry(track).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            public static void DeleteTrack(Track track)
            {
                using (var db = new MusicDbContext())
                {
                    db.Tracks.Remove(track);
                    db.SaveChanges();
                }
            }
        }
    }
}
