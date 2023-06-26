﻿using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class PurchaseReturnDetail
{
    public long ReturnId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
