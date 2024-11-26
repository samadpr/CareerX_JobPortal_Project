using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class SystemUser
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Role { get; set; }

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
