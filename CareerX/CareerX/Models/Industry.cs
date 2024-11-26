using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class Industry
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<CompanyAdmin> CompanyAdmins { get; set; } = new List<CompanyAdmin>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
