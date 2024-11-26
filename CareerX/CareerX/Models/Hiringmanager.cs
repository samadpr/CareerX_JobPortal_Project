using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class Hiringmanager
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public Guid? CompanyId { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public byte[]? Image { get; set; }

    public int Role { get; set; }

    public virtual CompanyAdmin? Company { get; set; }
}
