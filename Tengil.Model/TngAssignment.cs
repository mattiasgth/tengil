using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngAssignment
{
    public int Id { get; set; }

    public string? CustomerNameNOTUSED { get; set; }

    public string? NameText { get; set; }

    public DateTime? DateIn { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? DateOut { get; set; }

    public string? Folder { get; set; }

    public string? PoText { get; set; }

    public string? InvoiceText { get; set; }

    public string? CommentText { get; set; }

    public int? ExtentApprox { get; set; }

    public string? Owner { get; set; }

    public string? ContactEmail { get; set; }

    public int? PoId { get; set; }
    public virtual TngPoIn? Po { get; set; }

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

    public int? CustomerId { get; set; }
    public virtual TngCustomer? Customer { get; set; }

    public int? Active { get; set; }
}
