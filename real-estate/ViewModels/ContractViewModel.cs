using real_estate.Custom_Validation;
using System.ComponentModel.DataAnnotations;

namespace real_estate.ViewModels
{
    public class ContractViewModel
    {

        public int Id { get; set; }

       // [Range(1, int.MaxValue, ErrorMessage = "Please select a Property")]
        public int PropertyId { get; set; }

      //  [Range(1, int.MaxValue, ErrorMessage = "Please select a employee")]
        public int EmployeeId { get; set; }

       // [Range(1, int.MaxValue, ErrorMessage = "Please select a client")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Please enter a start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter an end date")]
        [DateGreaterThan("StartDate", ErrorMessage = "End date must be after start date")]
        public DateTime EndDate { get; set; }
    }
}
