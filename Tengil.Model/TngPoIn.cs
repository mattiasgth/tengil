using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngPoIn
{
    public int Id { get; set; }

    public string? Reserved { get; set; }

    public DateTime? DateIn { get; set; }

    public string? InvoiceName { get; set; }

    public string? Filename { get; set; }

    public string? Location { get; set; }

    public string? NameText { get; set; }

    public decimal? Amount { get; set; }

    public string? CurrencyName { get; set; }

    public int? InvoiceId { get; set; }
    public virtual TngInvoice? Invoice { get; set; }

    public string? Comment { get; set; }

    public int? CustomerId { get; set; }
    public virtual TngCustomer? Customer { get; set; }

    public int? AddedById { get; set; }
    public virtual TngUser? AddedBy { get; set; }
    public virtual IEnumerable<TngInvoiceRow> Rows { get; set; } = new List<TngInvoiceRow>();
}
