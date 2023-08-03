using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngProperty
{
    public int Id { get; set; }

    public string? ObjectTable { get; set; }

    public int? ObjectId { get; set; }

    public string? PropertyName { get; set; }

    public byte[]? DataBytes { get; set; }
}
