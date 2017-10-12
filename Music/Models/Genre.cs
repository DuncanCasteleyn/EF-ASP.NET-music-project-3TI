using System.Collections.Generic;

namespace Music.Models
{
    public class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}