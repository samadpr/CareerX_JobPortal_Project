using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class JobSeekerProfile
{
    public Guid Id { get; set; }

    public Guid JobSeekerId { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    public virtual JobSeeker JobSeeker { get; set; } = null!;

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
