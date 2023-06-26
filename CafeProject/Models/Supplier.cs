using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? SupplierAddress { get; set; }

    public string? SupplierEmail { get; set; }

    public string? SupplierPhone { get; set; }

    public string? SupplierPan { get; set; }

    public bool? SupplierStatus { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    public virtual ICollection<SupplierPayment> SupplierPayments { get; } = new List<SupplierPayment>();
}
