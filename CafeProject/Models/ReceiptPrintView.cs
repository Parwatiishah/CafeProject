using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class ReceiptPrintView
{
    public int PrintId { get; set; }

    public long ReceiptId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerAddress { get; set; }

    public string? CustomerPan { get; set; }

    public DateTime PrintDate { get; set; }

    public string PrintTime { get; set; } = null!;

    public int? PrintCount { get; set; }

    public int PrintUserId { get; set; }

    public string? PrintUser { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string ReceiptTime { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public string FiscalYear { get; set; } = null!;

    public decimal Amount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? TotalAmount { get; set; }
}
