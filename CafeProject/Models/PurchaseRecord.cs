using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PurchaseRecord
{
    public long PurchaseId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public string PurchaseTime { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public string FiscalYear { get; set; } = null!;

    public int BillNo { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal VatableAmount { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? AdditionalAmount { get; set; }

    public byte ModeId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public int EntryUserId { get; set; }

    public string? Remarks { get; set; }

    public virtual UserList? CancelUser { get; set; }

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual PaymentMode Mode { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; } = new List<PurchaseDetail>();

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();

    public virtual ICollection<PurchasePrint> PurchasePrints { get; } = new List<PurchasePrint>();

    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; } = new List<PurchaseReturn>();
}
