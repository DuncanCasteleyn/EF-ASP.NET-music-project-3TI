using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicDataModels;

namespace MusicApplication.Models
{
    public class TrackViewModel
    {
        public Track Track { get; set; }
        public IEnumerable<SelectListItem> AllArtists { get; set; }

        private List<int> _selectedArtists;

        public List<int> SelectedArtists
        {
            get
            {
                if (_selectedArtists == null)
                {
                    if (Track == null)
                    {
                        _selectedArtists = new List<int>();
                    }
                    else
                    {
                        _selectedArtists = Track.Artists.Select(artist => artist.Id).ToList();
                    }
                }
                return _selectedArtists;
            }
            set => _selectedArtists = value;
        }

        public IEnumerable<SelectListItem> AllGenres { get; set; }

        private List<int> _selectedGenres;

        public List<int> SelectedGenres
        {
            get
            {
                if (_selectedGenres == null)
                {
                    if (Track == null)
                    {
                        _selectedGenres = new List<int>();
                    }
                    else
                    {
                        _selectedGenres = Track.Genres.Select(artist => artist.Id).ToList();
                    }
                }
                return _selectedArtists;
            }
            set => _selectedArtists = value;
        }
    }
}