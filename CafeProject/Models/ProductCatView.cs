using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class ProductCatView
{
    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public decimal SellingPrice { get; set; }

    public decimal Quantity { get; set; }

    public string? WaitingTime { get; set; }

    public bool IsVatableItem { get; set; }

    public string UnitName { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public string? RackNumber { get; set; }

    public int ProductId { get; set; }

    public string CatName { get; set; } = null!;

    public byte CatId { get; set; }
}
