using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngWorkorderRow
{
    public int Id { get; set; }

    public int? Reserved { get; set; }

    public string? RowText { get; set; }

    public int? UnitId { get; set; }

    public decimal? Extent { get; set; }

    public decimal? PricePerUnit { get; set; }

    public double? Vat { get; set; }

    public double? Discount { get; set; }

    public int? TemplateId { get; set; }

    public int? PooutId { get; set; }
}
