using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblFuelTypeLog
{
    public int LogId { get; set; }

    public int? FuelTypeId { get; set; }

    public string? Action { get; set; }

    public string? Description { get; set; }

    public string? PerformedBy { get; set; }

    public DateTime? PerformedOn { get; set; }
}
