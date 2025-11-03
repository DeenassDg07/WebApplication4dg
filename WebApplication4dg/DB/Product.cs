using System;
using System.Collections.Generic;

namespace WebApplication4dg.DB;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
