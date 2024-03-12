using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage ="*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="*")]
        public string LastName { get; set; }
    }
}
