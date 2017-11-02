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
                new Genre() {Id = 0, Name = "Unkown"}
            };

            var artists = new List<Artist>
            {
                new Artist{Id = 0, Name = "Unkown", Gender = Gender.Other}
            };

            var tracks = new List<Track>
            {
                new Track {Artists = artists, Genres = genres, Id = 0, Name = "Example track", Length = new TimeSpan(0,0,10), Release = DateTime.Today, TrackLocation = "Unkown"}
            };

            genres[0].Tracks = tracks;
            artists[0].Tracks = tracks;

            var album = new Album {Id = 0, Name = "Example album", Release = DateTime.Today};
            var albumTracks = new List<AlbumTrack>
            {
                new AlbumTrack{Album = album, Track = tracks[0] , AlbumId = 0, TrackId = 0, TrackNumber = 0}
            };
            album.AlbumTracks = albumTracks;
            tracks[0].AlbumTracks = albumTracks;

            var playlist = new Playlist {Id = 0, Name = "Example play list"};
            var playListTracks = new List<PlayListTrack>
            {
                new PlayListTrack{Playlist = playlist, Track = tracks[0], PlaylistId = 0, TrackNumber = 0, TrackId = 0}
            };
            playlist.PlayListTracks = playListTracks;
            tracks[0].PlaylistTracks = playListTracks;

            genres.ForEach(genre => context.Genres.Add(genre));
            artists.ForEach(artist => context.Artists.Add(artist));
            tracks.ForEach(track => context.Tracks.Add(track));
            context.Albums.Add(album);
            context.Playlists.Add(playlist);
            albumTracks.ForEach(albumTrack => context.AlbumTracks.Add(albumTrack));
            playListTracks.ForEach(playListTrack => context.PlayListTracks.Add(playListTrack));
            context.SaveChanges();
        }
    }
}
