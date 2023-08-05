using System;
using System.Collections.Generic;

namespace tngcmd.Data;

/// <summary>
/// This is problematic -- the rows are actually bound to a purchase order.
/// </summary>
public partial class TngInvoiceRow
{
    public int Id { get; set; }

    public int? ChoreId { get; set; }

    public string? RowText { get; set; }

    public int? UnitId { get; set; }

    public decimal? Extent { get; set; }

    public decimal? PricePerUnit { get; set; }

    public double? Vat { get; set; }

    public double? Discount { get; set; }

    public int? TemplateId { get; set; }

    public int? InvoiceId { get; set; } // TODO: Seriously confusing, InvoiceId is foreign key to a tngPOIn :-)
}
