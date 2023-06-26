using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class RoleList
{
    public short RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
