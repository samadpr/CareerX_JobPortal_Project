﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobSeekerProfile
{
    public Guid Id { get; set; }

    public Guid JobSeekerId { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    public virtual JobSeeker JobSeeker { get; set; } = null!;

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
