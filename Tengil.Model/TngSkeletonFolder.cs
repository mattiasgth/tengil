using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngSkeletonFolder
{
    public int Id { get; set; }

    public string NameText { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string Res1 { get; set; } = null!;

    public string Res2 { get; set; } = null!;
}
