using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    [ForeignKey(nameof(Location))]
    public Guid LocationId { get; set; }
    [ForeignKey(nameof(CompanyAdmin))]
    public Guid CompanyId { get; set; }

    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }

    [ForeignKey(nameof(Industry))]
    public Guid IndustryId { get; set; }
    [ForeignKey(nameof(HiringManager))]
    public Guid PostedBy { get; set; }

    public DateTime PostedDate { get; set; }
    [ForeignKey(nameof(Qualification))]
    public Guid QualificationId { get; set; }
    [ForeignKey(nameof(Skill))]
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
