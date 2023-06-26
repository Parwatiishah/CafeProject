using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class CustomerReceipt: CustomerReceiptEdit
{
   
    public virtual UserList? CancelUser { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual PaymentMode Mode { get; set; } = null!;

    public virtual ICollection<ReceiptPrint> ReceiptPrints { get; } = new List<ReceiptPrint>();
}
public class CustomerReceiptEdit
{
    public long ReceiptId { get; set; }

    public byte ModeId { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string ReceiptTime { get; set; } = null!;

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string FiscalYear { get; set; } = null!;

    public int EntryUserId { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public string? Remarks { get; set; }

}
