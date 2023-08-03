using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngProject
{
    public int Id { get; set; }

    public string? NameText { get; set; }

    public int? CustomerId { get; set; }

    public int? OwnerId { get; set; }

    public int? ParentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? FolderInfix { get; set; }
}
