using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerAddress { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerPan { get; set; }

    public bool? CustomerStatus { get; set; }

    public virtual ICollection<CustomerReceipt> CustomerReceipts { get; } = new List<CustomerReceipt>();

    public virtual ICollection<SalesRecord> SalesRecords { get; } = new List<SalesRecord>();
}
