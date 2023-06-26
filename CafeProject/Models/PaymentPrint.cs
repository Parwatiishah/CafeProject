using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PaymentPrint
{
    public long PaymentId { get; set; }

    public DateTime PrintDate { get; set; }

    public string PrintTime { get; set; } = null!;

    public int PrintUserId { get; set; }

    public virtual SupplierPayment Payment { get; set; } = null!;

    public virtual UserList PrintUser { get; set; } = null!;
}
