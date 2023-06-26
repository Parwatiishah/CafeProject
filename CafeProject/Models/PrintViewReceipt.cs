using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PrintViewReceipt
{
    public long ReceiptId { get; set; }

    public DateTime PrintDate { get; set; }

    public string PrintTime { get; set; } = null!;

    public int PrintUserId { get; set; }

    public string UserName { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string? CustomerAddress { get; set; }

    public decimal Amount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? TotalAmount { get; set; }
}
