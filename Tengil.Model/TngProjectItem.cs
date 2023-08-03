using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngProjectItem
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Description { get; set; } = null!;

    public int CurrencyId { get; set; }

    public int ApprovedById { get; set; }

    public DateTime? DateCreated { get; set; }

    public int Extent { get; set; }

    public int UnitId { get; set; }

    public decimal PricePerUnit { get; set; }
}
