using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngEvent
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public int? TargetId { get; set; }

    public int? UserId { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Reserved { get; set; }

    public int? TableId { get; set; }
}
