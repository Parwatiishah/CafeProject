using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class Cafe
{
    public short CafeId { get; set; }

    public string CafeName { get; set; } = null!;

    public string CafePhone { get; set; } = null!;

    public string CafeAddress { get; set; } = null!;

    public string CafeMoto { get; set; } = null!;

    public string CurrentFiscalYear { get; set; } = null!;

    public bool IsFixedSalesPriceSystem { get; set; }

    public string? Website { get; set; }

    public bool IsVatRegistered { get; set; }

    public DateTime CurrentDate { get; set; }
}
