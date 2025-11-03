using System;
using System.Collections.Generic;

namespace WebApplication4dg.DB;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public DateOnly? DateOfBithDay { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Info { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
