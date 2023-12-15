using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public int? Amount { get; set; }

    public string? PaymentStatys { get; set; }

    public int? ServiceDetailsId { get; set; }

    public int? PaymentType { get; set; }

    public virtual PaymentType? PaymentTypeNavigation { get; set; }

    public virtual ServiceDetail? ServiceDetails { get; set; }
}
