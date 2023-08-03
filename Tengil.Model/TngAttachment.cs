using System;
using System.Collections.Generic;

namespace tngcmd.Data;

public partial class TngAttachment
{
    public int Id { get; set; }

    public string ObjectTable { get; set; } = null!;

    public int? ObjectId { get; set; }

    public string? Type { get; set; }

    public byte[]? DataBytes { get; set; }
}
