using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngUnit
{
    public int Id { get; set; }

    public string? NameText { get; set; }

    public string? DescriptionText { get; set; }

    public double? Weight { get; set; }
}
