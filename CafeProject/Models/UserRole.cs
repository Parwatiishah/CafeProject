using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class UserRole
{
    public long Rn { get; set; }

    public int UserId { get; set; }

    public short RoleId { get; set; }

    public virtual RoleList Role { get; set; } = null!;

    public virtual UserList User { get; set; } = null!;
}
