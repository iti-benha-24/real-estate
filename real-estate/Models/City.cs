namespace real_estate.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List <Property> properties { get; set; } 
    }
}
