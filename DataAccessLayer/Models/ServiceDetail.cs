using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ServiceDetail
{
    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public string? IssuesMentioned { get; set; }

    public string? IssuesResolved { get; set; }

    public string FeedBack { get; set; } = null!;

    public int? AttendeeId { get; set; }

    public int VehicleId { get; set; }

    public string Status { get; set; } = null!;

    public virtual User? Attendee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    //public virtual Vehicle Vehicle { get; set; } = null!;
}
