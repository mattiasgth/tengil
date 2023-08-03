using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngResourceGroup
{
    public int Id { get; set; }

    public string NameText { get; set; } = null!;

    public string CommentText { get; set; } = null!;

    public string ReservedText { get; set; } = null!;
}
