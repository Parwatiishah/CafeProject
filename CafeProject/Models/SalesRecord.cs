using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class SalesRecord
{
    public long SalesId { get; set; }

    public byte ModeId { get; set; }

    public DateTime SalseDate { get; set; }

    public string SalesTime { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public string FisicalYear { get; set; } = null!;

    public int InvoiceNo { get; set; }

    public decimal AdditionalAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal VatableAmt { get; set; }

    public decimal VatAmt { get; set; }

    public decimal NetAmount { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelledUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public int EntryUserId { get; set; }

    public string? Remarks { get; set; }

    public virtual UserList? CancelledUser { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; } = new List<CustomerOrderDetail>();

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual PaymentMode Mode { get; set; } = null!;

    public virtual ICollection<SalesDetail> SalesDetails { get; } = new List<SalesDetail>();

    public virtual ICollection<SalesPrint> SalesPrints { get; } = new List<SalesPrint>();

    public virtual ICollection<SalesReturn> SalesReturns { get; } = new List<SalesReturn>();
}
