using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class SalesDetail
{
    public long SalesDetailId { get; set; }

    public long SalesId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalesRecord Sales { get; set; } = null!;
}
