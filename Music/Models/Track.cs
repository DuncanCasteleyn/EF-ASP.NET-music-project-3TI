using System;

namespace Music.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public DateTime Release { get; set; }
        public long NumberOfPlay { get; set; }
        public string TrackLocation { get; set; }
    }
}
