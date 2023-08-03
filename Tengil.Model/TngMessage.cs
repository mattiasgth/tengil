using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngMessage
{
    public int Id { get; set; }

    public int TargetUser { get; set; }

    public DateTime Created { get; set; }

    public string Text { get; set; } = null!;

    public int Origin { get; set; }

    public int Status { get; set; }
}
