using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? ModelName { get; set; }

    public string? VehicleRegistrationPlateNumber { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ServiceDetail> ServiceDetails { get; } = new List<ServiceDetail>();

    public virtual User? User { get; set; }
}
