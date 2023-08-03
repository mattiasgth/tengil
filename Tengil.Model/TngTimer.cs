using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngTimer
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public string? AssignmentId { get; set; }

    public int Running { get; set; }

    public string? CommentText { get; set; }
}
