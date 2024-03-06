namespace real_estate.Models
{
    public class property_status
    {
        public int Id { get; set; }
        public string status { get; set; }

        public List<Property> properties { get; set; }
    }
}
