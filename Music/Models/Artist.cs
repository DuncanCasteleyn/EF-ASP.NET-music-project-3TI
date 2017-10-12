using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Artist
    {
        public Artist()
        {
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string RealName { get; set; }
        public Gender Gender { get; set; }
        public string BirthCountry { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }

    public enum Gender
    {
        Female,
        Male
    }
}