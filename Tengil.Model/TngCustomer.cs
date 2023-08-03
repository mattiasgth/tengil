using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngCustomer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? ShortName { get; set; }

    public string? Folder { get; set; }

    public string? Notes { get; set; }

    public string? DefaultCurrency { get; set; }

    public string? EmailInv { get; set; }

    public int? PaymentTerms { get; set; }

    public double DefaultVat { get; set; }

    public string? Vatcode { get; set; }

    public bool? Active { get; set; }

    public int NoInvoiceRounding { get; set; }

    public string? CountryCode { get; set; }

    public int? GroupId { get; set; }

    public string? Popattern { get; set; }

    public int? DefaultPosting { get; set; }
}
