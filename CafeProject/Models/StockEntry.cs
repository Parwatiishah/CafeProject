using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class StockEntry
{
    public long EntryId { get; set; }

    public DateTime EntryDate { get; set; }

    public string FisicalYear { get; set; } = null!;

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public int EntryUserId { get; set; }

    public string StockStatus { get; set; } = null!;

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public string? Remarks { get; set; }

    public virtual UserList? CancelUser { get; set; }

    public virtual UserList EntryUser { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
