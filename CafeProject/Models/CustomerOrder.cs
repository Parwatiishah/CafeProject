using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class CustomerOrder
{
    public long OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderTime { get; set; } = null!;

    public string FisicalYear { get; set; } = null!;

    public string CustomerReference { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public int OrderUserId { get; set; }

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; } = new List<CustomerOrderDetail>();

    public virtual UserList OrderUser { get; set; } = null!;
}
