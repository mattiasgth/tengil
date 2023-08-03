using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngChore
{
    public int Id { get; set; }

    public int? AssignmentId { get; set; }

    public int? UserId { get; set; }

    public string? CommentText { get; set; }

    public double? Extent { get; set; }

    public int? WorkorderRowId { get; set; }

    public int? UnitId { get; set; }

    public decimal? PricePerUnit { get; set; }

    public int Progress { get; set; }

    public int CurrencyId { get; set; }
}
