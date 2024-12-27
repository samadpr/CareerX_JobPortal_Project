using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Company.DTOs
{
    public class CompanyDto
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
