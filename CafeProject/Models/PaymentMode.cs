using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PaymentMode
{
    public byte ModeId { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual ICollection<CustomerReceipt> CustomerReceipts { get; } = new List<CustomerReceipt>();

    public virtual ICollection<PurchaseRecord> PurchaseRecords { get; } = new List<PurchaseRecord>();

    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; } = new List<PurchaseReturn>();

    public virtual ICollection<SalesRecord> SalesRecords { get; } = new List<SalesRecord>();

    public virtual ICollection<SalesReturn> SalesReturns { get; } = new List<SalesReturn>();

    public virtual ICollection<SupplierPayment> SupplierPayments { get; } = new List<SupplierPayment>();
}
