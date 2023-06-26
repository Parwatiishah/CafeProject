using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class ReceiptPrint
{
    public int PrintId { get; set; }

    public long ReceiptId { get; set; }

    public DateTime PrintDate { get; set; }

    public string PrintTime { get; set; } = null!;

    public int PrintUserId { get; set; }

    public virtual UserList PrintUser { get; set; } = null!;

    public virtual CustomerReceipt Receipt { get; set; } = null!;
}
