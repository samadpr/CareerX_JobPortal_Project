using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Resume
{
    public Guid Id { get; set; }

    public Guid JobSeekerProfileId { get; set; }

    public byte[] ResumeFile { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public DateTime DateUploaded { get; set; }

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;
}
