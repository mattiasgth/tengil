using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngCustomerGroup
{
    public int Id { get; set; }

    public string? NameText { get; set; }

    public string? CommentText { get; set; }

    public string? ReservedText { get; set; }
}
