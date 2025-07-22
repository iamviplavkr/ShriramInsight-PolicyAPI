using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblProposedInsurer
{
    public int InsurerId { get; set; }

    public string InsurerName { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool IsActive { get; set; }
}
