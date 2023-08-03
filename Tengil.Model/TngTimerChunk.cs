using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngTimerChunk
{
    public int Id { get; set; }

    public int? Running { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? Stop { get; set; }

    public string? Description { get; set; }

    public int AssignmentId { get; set; }

    public int ProjectId { get; set; }

    public int? UserId { get; set; }
}
