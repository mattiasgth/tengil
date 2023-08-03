using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngBankAccount
{
    public int Id { get; set; }

    public string? Iban { get; set; }

    public string? Bic { get; set; }

    public string? Clearing { get; set; }

    public string? AccountNr { get; set; }

    public string? BankName { get; set; }

    public string? AccountHolder { get; set; }

    public string? BankAddr1 { get; set; }

    public string? BankAddr2 { get; set; }

    public string? BankAddr3 { get; set; }

    public string BankSortCode { get; set; } = null!;
}
