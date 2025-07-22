using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblPolicyType
{
    public int PolicyTypeId { get; set; }

    public string PolicyTypeDesc { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool IsActive { get; set; }
}
