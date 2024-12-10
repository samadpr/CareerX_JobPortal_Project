using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AuthUser : SystemUser
{
    public string Password { get; set; } = null!;

    public int? Status { get; set; }
}
