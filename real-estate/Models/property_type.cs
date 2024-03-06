namespace real_estate.Models
{
    public class property_type
    {
        public int Id { get; set; }
        public string type { get; set; }

       public  List<Property> properties { get; set; }
    }
}
