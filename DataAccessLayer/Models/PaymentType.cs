using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
