using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;
}
