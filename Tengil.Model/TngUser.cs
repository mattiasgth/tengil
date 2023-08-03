using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? MidName { get; set; }

    public string? LastName { get; set; }

    public string? Addr1 { get; set; }

    public string? Addr2 { get; set; }

    public string? PostalNo { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PhoneHome { get; set; }

    public string? PhoneWork { get; set; }

    public string? PhoneCell { get; set; }

    public string? Email { get; set; }

    public int? UserPrivs { get; set; }

    public bool? Active { get; set; }

    public int? Category { get; set; }

    public int? BankAccountId { get; set; }

    public sbyte? Salary { get; set; }

    public int? TaxClass { get; set; }

    public int? GroupId { get; set; }

    public string? AltEmail { get; set; }
}
