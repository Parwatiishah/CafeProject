using System;
using System.Collections.Generic;

namespace CafeProject.Models;

public partial class ProductCategory
{
    public byte CatId { get; set; }

    public string CatName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
