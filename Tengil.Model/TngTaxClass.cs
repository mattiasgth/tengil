using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngTaxClass
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public double Rate { get; set; }

    public string Comment { get; set; } = null!;
}
