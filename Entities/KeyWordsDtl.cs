using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class KeyWordsDtl
{
    public long Id { get; set; }

    public long KeyWordsId { get; set; }

    public int? Ser { get; set; }

    public string Title { get; set; } = null!;

    public string? Par01 { get; set; }

    public string? Par02 { get; set; }

    public string? Par03 { get; set; }

    public string? Par04 { get; set; }

    public string? Par05 { get; set; }

    public string? Par06 { get; set; }

    public string? Par07 { get; set; }

    public string? Par08 { get; set; }

    public string? Par09 { get; set; }

    public string? Par10 { get; set; }

    public string? Par11 { get; set; }

    public string? Par12 { get; set; }

    public string? Par13 { get; set; }

    public string? Par14 { get; set; }

    public string? Par15 { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }
}
