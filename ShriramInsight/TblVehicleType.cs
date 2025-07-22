using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblVehicleType
{
    public int VehicleTypeId { get; set; }

    public string VehicleTypeDesc { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool IsActive { get; set; }
}
