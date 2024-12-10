using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public Guid LocationId { get; set; }

    public Guid CompanyId { get; set; }

    public Guid CategoryId { get; set; }

    public Guid IndustryId { get; set; }

    public Guid PostedBy { get; set; }

    public DateTime PostedDate { get; set; }

    public Guid QualificationId { get; set; }

    public Guid SkillId { get; set; }

    public virtual JobCategory Category { get; set; } = null!;

    public virtual CompanyAdmin Company { get; set; } = null!;

    public virtual Industry Industry { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual Location Location { get; set; } = null!;

    public virtual HiringManager PostedByNavigation { get; set; } = null!;

    public virtual Qualification Qualification { get; set; } = null!;

    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();

    public virtual Skill Skill { get; set; } = null!;
}
