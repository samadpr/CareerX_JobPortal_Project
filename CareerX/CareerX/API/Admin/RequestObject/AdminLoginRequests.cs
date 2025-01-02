using System.ComponentModel.DataAnnotations;

namespace CareerX.API.Admin.RequestObject
{
    public class AdminLoginRequests
    {
        
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        
    }
}
