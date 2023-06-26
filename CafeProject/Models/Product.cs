using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public byte ProductCatId { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal Quantity { get; set; }

    public string? WaitingTime { get; set; }

    public bool IsVatableItem { get; set; }

    public string UnitName { get; set; } = null!;

    public bool? IsAvailable { get; set; }

    public string? RackNumber { get; set; }

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; } = new List<CustomerOrderDetail>();

    public virtual ProductCategory ProductCat { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; } = new List<PurchaseDetail>();

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();

    public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; } = new List<PurchaseReturnDetail>();

    public virtual ICollection<SalesDetail> SalesDetails { get; } = new List<SalesDetail>();

    public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; } = new List<SalesReturnDetail>();

    public virtual ICollection<StockEntry> StockEntries { get; } = new List<StockEntry>();
}
