using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngJournalItem
{
    public int Id { get; set; }

    public int? RowId { get; set; }

    public decimal? Extent { get; set; }

    public int? ChoreId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? ItemDate { get; set; }

    public DateTime? ItemEnd { get; set; }

    public int? UserId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProjectId { get; set; }

    public int? AssignmentId { get; set; }

    public string? Activity { get; set; }

    public int? UnitId { get; set; }
}
