using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class CompanyAdmin
{
    public Guid Id { get; set; }

    public string LegalName { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public Guid IndustryId { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public string Address { get; set; } = null!;

    public string Website { get; set; } = null!;

    public Guid Location { get; set; }

    public virtual ICollection<Hiringmanager> Hiringmanagers { get; set; } = new List<Hiringmanager>();

    public virtual Industry Industry { get; set; } = null!;

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();

    public virtual Location LocationNavigation { get; set; } = null!;
}
