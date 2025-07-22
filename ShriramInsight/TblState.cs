using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblState
{
    public int StateId { get; set; }

    public string StateDesc { get; set; } = null!;

    public byte? Zone { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool IsActive { get; set; }
}
