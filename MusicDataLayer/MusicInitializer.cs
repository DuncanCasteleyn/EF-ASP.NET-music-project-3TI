using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicDataModels;

namespace MusicDataLayer
{
    public class MusicInitializer : CreateDatabaseIfNotExists<MusicDbContext>
    {
        protected override void Seed(MusicDbContext context)
        {
            //Base classes
            var genre = new Genre { Name = "Unkown" };

            var artist = new Artist { Name = "Unkown", Gender = Gender.Other };

            var track = new Track
            {
                Name = "Example track",
                Length = new TimeSpan(0, 0, 10),
                Release = DateTime.Today,
                TrackLocation = "Unkown"
            };


            var album = new Album { Name = "Example album", Release = DateTime.Today };


            //Relations
            var trackArtists =new List<TrackArtist>
            {
                new TrackArtist{Artist = artist, Track = track}
            };
            track.TrackArtists = trackArtists;
            artist.TrackArtists = trackArtists;

            var trackGenres = new List<TrackGenre>
            {
                new TrackGenre(){Genre = genre, Track = track}
            };
            track.TrackGenres = trackGenres;
            genre.TrackGenres = trackGenres;

            var albumTracks = new HashSet<AlbumTrack>
            {
                new AlbumTrack {Album = album, Track = track, TrackNumber = 0}
            };
            album.AlbumTracks = albumTracks;
            track.AlbumTracks = albumTracks;

            var playlist = new Playlist { Name = "Example play list" };
            var playListTracks = new HashSet<PlayListTrack>
            {
                new PlayListTrack{Playlist = playlist, Track = track, TrackNumber = 0}
            };
            playlist.PlayListTracks = playListTracks;
            track.PlaylistTracks = playListTracks;

            //Add base classes to database
            context.Genres.Add(genre);
            context.Artists.Add(artist);
            context.Tracks.Add(track);
            context.Albums.Add(album);
            context.Playlists.Add(playlist);
            //Add relations to database
            albumTracks.ToList().ForEach(albumTrack => context.AlbumTracks.Add(albumTrack));
            playListTracks.ToList().ForEach(playListTrack => context.PlayListTracks.Add(playListTrack));
            trackArtists.ToList().ForEach(trackArtist => context.TrackArtists.Add(trackArtist));
            trackGenres.ToList().ForEach(trackGenre => context.TrackGenres.Add(trackGenre));
            //Save to database
            context.SaveChanges();
        }
    }
}
