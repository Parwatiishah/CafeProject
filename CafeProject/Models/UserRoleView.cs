using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class UserRoleView
{
    public int UserId { get; set; }

    public string RoleName { get; set; } = null!;
}
