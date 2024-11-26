using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class Qualification
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
