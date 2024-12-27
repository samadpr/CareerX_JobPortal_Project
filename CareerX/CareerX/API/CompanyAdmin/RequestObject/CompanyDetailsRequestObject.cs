namespace CareerX.API.CompanyAdmin.RequestObject
{
    public class CompanyDetailsRequestObject
    {
        public string AdminName { get; set; } = null!;

        public string? LegalName { get; set; }

        public string? Summary { get; set; }

        public Guid? IndustryId { get; set; } 

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        public string? Website { get; set; }

        public Guid? Location { get; set; }
    }
}
