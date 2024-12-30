using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Models;

public partial class HiringManager
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;
    [ForeignKey(nameof(CompanyAdmin))]
    public Guid? CompanyId { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int Role { get; set; }

    public virtual CompanyAdmin? Company { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
