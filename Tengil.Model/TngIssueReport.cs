using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngIssueReport
{
    public int Id { get; set; }

    public int AssignmentId { get; set; }

    public string Cause { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime DateCreated { get; set; }
}
