using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CompanyAdmin
{
    public Guid Id { get; set; } 

    public string AdminName { get; set; } = null!;

    public string? LegalName { get; set; }

    public string? Summary { get; set; }

    public Guid? IndustryId { get; set; } // Nullable Guid.

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string? Website { get; set; }

    public Guid? Location { get; set; } // Nullable Guid.

    public virtual ICollection<HiringManager>? HiringManagers { get; set; } = new List<HiringManager>();

    public virtual Industry? Industry { get; set; }

    public virtual ICollection<Interview>? Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobPost>? JobPosts { get; set; } = new List<JobPost>();

    public virtual Location? LocationNavigation { get; set; }
}
