using System.ComponentModel.DataAnnotations;

namespace CareerX.API.CompanyAdmin.RequestObject
{
    public class CompanyAdminLoginRequestObject
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
