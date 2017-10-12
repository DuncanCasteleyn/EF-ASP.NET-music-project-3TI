using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}