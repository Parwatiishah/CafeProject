using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class CustomerOrderDetail
{
    public long OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Quatity { get; set; }

    public decimal Rate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int? ActionUserId { get; set; }

    public DateTime? ActionDate { get; set; }

    public long? SalesId { get; set; }

    public virtual UserList? ActionUser { get; set; }

    public virtual CustomerOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual SalesRecord? Sales { get; set; }
}
