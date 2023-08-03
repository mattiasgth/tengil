using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngJournalRow
{
    public ulong Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Weekstart { get; set; }

    public int? CustomerId { get; set; }

    public int? ProjectId { get; set; }

    public int? AssignmentId { get; set; }

    public string? Activity { get; set; }

    public decimal? ExtMonday { get; set; }

    public decimal? ExtTuesday { get; set; }

    public decimal? ExtWednesday { get; set; }

    public decimal? ExtThursday { get; set; }

    public decimal? ExtFriday { get; set; }

    public decimal? ExtSaturday { get; set; }

    public decimal? ExtSunday { get; set; }

    public int? UnitId { get; set; }

    public string? CommentText { get; set; }

    public int? ChoreId { get; set; }
}
