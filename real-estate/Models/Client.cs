namespace real_estate.Models
{
    public class Client
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalId { get; set; }
        public string PhoneNumber { get; set; }

        


        public List<Contract>  Contracts { get; set; }
    }
}
