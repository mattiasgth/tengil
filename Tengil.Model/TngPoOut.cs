using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngPoOut
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? NameText { get; set; }

    public decimal? Amount { get; set; }

    public string? CurrencyName { get; set; }

    public DateTime? DateIssued { get; set; }

    public DateTime? DateInvoiced { get; set; }

    public int? IssuedById { get; set; }

    public string? CommentText { get; set; }
}
