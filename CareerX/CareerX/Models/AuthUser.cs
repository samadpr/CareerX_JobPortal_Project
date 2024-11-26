using System;
using System.Collections.Generic;

namespace CareerX.Models;

public partial class AuthUser
{
    public Guid Id { get; set; }

    public string? Password { get; set; }

    public int? Status { get; set; }
}
