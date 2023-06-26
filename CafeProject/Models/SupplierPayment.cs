using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class SupplierPayment
{
    public long PaymentId { get; set; }

    public byte ModeId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentTime { get; set; } = null!;

    public int SuppliersId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string FiscalYear { get; set; } = null!;

    public int EntryUserId { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public string? Remarks { get; set; }

    public virtual UserList? CancelUser { get; set; }

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual PaymentMode Mode { get; set; } = null!;

    public virtual ICollection<PaymentPrint> PaymentPrints { get; } = new List<PaymentPrint>();

    public virtual Supplier Suppliers { get; set; } = null!;
}
