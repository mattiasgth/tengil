using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngCurrency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public double Rate { get; set; }
}
