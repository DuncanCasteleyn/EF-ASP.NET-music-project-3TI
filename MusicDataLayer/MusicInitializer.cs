using System;
using System.Collections.Generic;
using System.Data.Entity;
using MusicDataModels;

namespace MusicDataLayer
{
    public class MusicInitializer : CreateDatabaseIfNotExists<MusicDbContext>
    {
        protected override void Seed(MusicDbContext context)
        {
            var genres = new List<Genre>
            {
                new Genre() {Name = "Unkown"}
            };

            var artists = new List<Artist>
            {
                new Artist{Name = "Unkown", Gender = Gender.Other}
            };

            var tracks = new List<Track>
            {
                new Track {Artists = artists, Genres = genres, Name = "Example track", Length = new TimeSpan(0,0,10), Release = DateTime.Today, TrackLocation = "Unkown"}
            };

            genres[0].Tracks = tracks;
            artists[0].Tracks = tracks;

            var album = new Album { Name = "Example album", Release = DateTime.Today };
            var albumTracks = new List<AlbumTrack>
            {
                new AlbumTrack{Album = album, Track = tracks[0], TrackNumber = 0}
            };
            album.AlbumTracks = albumTracks;
            tracks[0].AlbumTracks = albumTracks;

            var playlist = new Playlist { Name = "Example play list" };
            var playListTracks = new List<PlaylistTrack>
            {
                new PlaylistTrack{Playlist = playlist, Track = tracks[0], TrackNumber = 0}
            };
            playlist.PlayListTracks = playListTracks;
            tracks[0].PlaylistTracks = playListTracks;

            genres.ForEach(genre => context.Genres.Add(genre));
            artists.ForEach(artist => context.Artists.Add(artist));
            tracks.ForEach(track => context.Tracks.Add(track));
            context.Albums.Add(album);
            context.Playlists.Add(playlist);
            albumTracks.ForEach(albumTrack => context.AlbumTracks.Add(albumTrack));
            playListTracks.ForEach(playListTrack => context.PlaylistTracks.Add(playListTrack));
            context.SaveChanges();
        }
    }
}
