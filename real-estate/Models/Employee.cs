namespace real_estate.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Role { get; set; }
        public string Password { get; set; }



        public List<Property> properties { get; set; }
        public List<Contract> contracts { get; set; }

    }
}
