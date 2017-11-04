using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDataModels
{
    public class Artist
    {
        public Artist()
        {
            TrackArtists = new HashSet<TrackArtist>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string RealName { get; set; }
        public Gender Gender { get; set; }
        public string BirthCountry { get; set; }

        public ICollection<TrackArtist> TrackArtists { get; set; }
    }

    public enum Gender
    {
        Female,
        Male,
        Other
    }
}
