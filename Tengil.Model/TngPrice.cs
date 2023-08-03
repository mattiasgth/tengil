using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngPrice
{
    public int Id { get; set; }

    public int ObjectId { get; set; }

    public int ObjectType { get; set; }

    public int? UnitId { get; set; }

    public decimal? Price { get; set; }

    public string CurrencyName { get; set; } = null!;

    public int? CurrencyId { get; set; }

    public DateTime? DateAgreed { get; set; }

    public string? CommentText { get; set; }
}
