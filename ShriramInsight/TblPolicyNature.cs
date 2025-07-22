using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblPolicyNature
{
    public int PolicyNatureId { get; set; }

    public string PolicyNatureDesc { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool? IsActive { get; set; }
}
