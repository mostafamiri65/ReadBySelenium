using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class KeyWordsMain
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }
}
