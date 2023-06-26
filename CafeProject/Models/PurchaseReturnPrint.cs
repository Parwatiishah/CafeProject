using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PurchaseReturnPrint
{
    public long ReturnId { get; set; }

    public DateTime PrintDate { get; set; }

    public string PrintTime { get; set; } = null!;

    public int PrintUserId { get; set; }

    public virtual UserList PrintUser { get; set; } = null!;

    public virtual PurchaseReturn Return { get; set; } = null!;
}
