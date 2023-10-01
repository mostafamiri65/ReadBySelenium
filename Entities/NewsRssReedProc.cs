using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NewsRssReedProc
{
    public long Id { get; set; }

    public long? NewsRssReedId { get; set; }

    public int? KeyWordsId { get; set; }

    public int? KeyWordsDtlId { get; set; }

    public int? KeyWordsMainId { get; set; }

    public string? KeyWordsTitle { get; set; }

    public string? KeyWordsDtlTitle { get; set; }

    public string? KeyWordsMainTitle { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }
}
