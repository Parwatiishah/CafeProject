using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class SalesReturn
{
    public long ReturnId { get; set; }

    public byte ModeId { get; set; }

    public DateTime ReturnDate { get; set; }

    public string ReturnTime { get; set; } = null!;

    public int ReturnUserId { get; set; }

    public long SalesId { get; set; }

    public string FiscalYear { get; set; } = null!;

    public DateTime? CancelledDate { get; set; }

    public int? CancelUserId { get; set; }

    public string? ReasonForCancel { get; set; }

    public string? Remarks { get; set; }

    public virtual UserList? CancelUser { get; set; }

    public virtual PaymentMode Mode { get; set; } = null!;

    public virtual UserList ReturnUser { get; set; } = null!;

    public virtual SalesRecord Sales { get; set; } = null!;

    public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; } = new List<SalesReturnDetail>();

    public virtual ICollection<SalesReturnPrint> SalesReturnPrints { get; } = new List<SalesReturnPrint>();
}
