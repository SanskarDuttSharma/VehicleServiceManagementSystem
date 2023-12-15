using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int MobileNumber { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public int RoleId { get; set; }

    public bool Status { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<ServiceDetail> ServiceDetails { get; } = new List<ServiceDetail>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
