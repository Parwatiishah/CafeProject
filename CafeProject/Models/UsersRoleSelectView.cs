using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class UsersRoleSelectView
{
    public short RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int UserId { get; set; }

    public int HasRole { get; set; }
}
