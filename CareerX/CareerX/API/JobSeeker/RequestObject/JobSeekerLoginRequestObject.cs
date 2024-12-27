using System.ComponentModel.DataAnnotations;

namespace CareerX.API.JobSeeker.RequestObject
{
    public class JobSeekerLoginRequestObject

    { 
          [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
}
