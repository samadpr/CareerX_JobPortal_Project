using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Location
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CompanyAdmin> CompanyAdmins { get; set; } = new List<CompanyAdmin>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
