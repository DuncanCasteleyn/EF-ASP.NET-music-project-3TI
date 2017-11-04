using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDataModels
{
    public class Genre
    {
        public Genre()
        {
            TrackGenres = new HashSet<TrackGenre>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<TrackGenre> TrackGenres { get; set; }
    }
}
