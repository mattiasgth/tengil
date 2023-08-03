using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngCustContact
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneWork { get; set; }

    public string? PhoneCell { get; set; }

    public string? Email { get; set; }

    public string? Reserved { get; set; }

    public string? AltEmail { get; set; }

    public int? CustomerId { get; set; }
}
