namespace real_estate.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? propertyId { get; set; }
        public int employeeId { get; set; }

        public int clientId { get; set; }

        public Property property { get; set; }

        public Client client { get; set; }  
        public Employee employee { get; set; }


    }
}
