using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngInvoice
{
    public int Id { get; set; }

    public string InvoiceText { get; set; } = null!;

    public int? CustomerId { get; set; }
    public virtual TngCustomer? Customer { get; set; }

    public DateTime? DateIssued { get; set; }

    public DateTime? DatePaid { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Vat { get; set; }

    public string? CurrencyName { get; set; }

    public int? CreatedById { get; set; }
    public virtual TngUser? CreatedBy { get; set; }

    public DateTime? DateDue { get; set; }

    public double Rate { get; set; }

    public int? TemplateId { get; set; }

    public decimal Discount { get; set; }

    public decimal Rounding { get; set; }

    public string? Recipient { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Vatcode { get; set; }

    public string? RefOurs { get; set; }

    public string? RefYours { get; set; }
}
