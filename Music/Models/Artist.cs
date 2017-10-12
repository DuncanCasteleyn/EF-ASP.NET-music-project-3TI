namespace Music.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public Gender Gender { get; set; }
        public string BirthCountry { get; set; }
    }

    public enum Gender
    {
        Female,
        Male
    }
}
