using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public Guid? LocationId { get; set; }
    public Guid? CompanyId { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? IndustryId { get; set; }
    public Guid? PostedBy { get; set; }

    public DateTime? PostedDate { get; set; }
    public Guid? QualificationId { get; set; } 
    public Guid? SkillId { get; set; }

    public virtual JobCategory? Category { get; set; } 

    public virtual CompanyAdmin? Company { get; set; } 

    public virtual Industry? Industry { get; set; } 

    public virtual ICollection<Interview>? Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobApplication>? JobApplications { get; set; } = new List<JobApplication>();

    public virtual Location? Location { get; set; }

    public virtual HiringManager? PostedByNavigation { get; set; } 

    public virtual Qualification? Qualification { get; set; } 

    public virtual ICollection<SavedJob>? SavedJobs { get; set; } = new List<SavedJob>();

    public virtual Skill? Skill { get; set; } 
}
