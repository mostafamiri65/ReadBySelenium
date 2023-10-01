using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NewsSource
{
    public long Id { get; set; }

    public string SourceTitle { get; set; } = null!;

    public string SourceDescription { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? SiteUri { get; set; }

    public virtual ICollection<NewsSourceDetail> NewsSourceDetails { get; set; } = new List<NewsSourceDetail>();
}
