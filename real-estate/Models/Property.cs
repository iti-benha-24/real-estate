namespace real_estate.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string PropertyImg { get; set; }
        public string Address { get; set; }
         public decimal Price { get; set; }
        public int cityId { get; set; }
        public int PropertyTypeId { get; set; }
        public int PropertySize { get; set; }
        public int NumBedrooms { get; set; }
        public int NumBathrooms { get; set; }
        public string Features { get; set; }

        public int PropertyStatusId { get; set; }
        public int EmployeeId { get; set; }

        public int? ContractId { get; set; }


        // Navigation properties
        public City city { get; set; }
        public property_status propertyStatus { get; set; }
        public property_type propertyType { get; set; }
        public Contract contract { get; set; }
        public Employee employee { get; set; }  



    }
}
