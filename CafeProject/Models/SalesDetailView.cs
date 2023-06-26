﻿using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class SalesDetailView
{
    public long SalesDetailId { get; set; }

    public long SalesId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string CatName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public string UnitName { get; set; } = null!;

    public string? RackNumber { get; set; }

    public decimal SellingPrice { get; set; }

    public string? PaymentMethod { get; set; }

    public int? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerPan { get; set; }

    public string? CustomerAddress { get; set; }

    public int EntryUserId { get; set; }

    public string? EntryUser { get; set; }

    public DateTime SalseDate { get; set; }

    public string SalesTime { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public string FisicalYear { get; set; } = null!;

    public int InvoiceNo { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal AdditionalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal VatableAmt { get; set; }

    public decimal VatAmt { get; set; }

    public decimal NetAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelledUserId { get; set; }

    public string? CancelledUser { get; set; }

    public string? ReasonForCancel { get; set; }
}
