using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class ReceiptPayView
{
    public long ReceiptId { get; set; }

    public byte ModeId { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string ReceiptTime { get; set; } = null!;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerPhone { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string FiscalYear { get; set; } = null!;

    public int EntryUserId { get; set; }

    public string? EntryUser { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? CancelUser { get; set; }

    public string? ReasonForCancel { get; set; }

    public string? Remarks { get; set; }
}
