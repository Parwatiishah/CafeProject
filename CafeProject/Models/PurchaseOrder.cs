using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PurchaseOrder
{
    public long OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderTime { get; set; } = null!;

    public int SupplierId { get; set; }

    public decimal TotalAmount { get; set; }

    public int EntryUserId { get; set; }

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
