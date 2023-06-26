using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PurchaseOrderDetail
{
    public long OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Quatity { get; set; }

    public decimal Rate { get; set; }

    public long? PurchaseId { get; set; }

    public virtual PurchaseOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseRecord? Purchase { get; set; }
}
