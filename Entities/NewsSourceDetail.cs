using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NewsSourceDetail
{
    public long Id { get; set; }

    public long? NewsSourceId { get; set; }

    public string? SourceTitle { get; set; }

    public string? SourceUrl { get; set; }

    public long? SourceDetailId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public bool ReadBySite { get; set; }

    public virtual ICollection<NewsSourceDetail> InverseSourceDetail { get; set; } = new List<NewsSourceDetail>();

    public virtual NewsSource? NewsSource { get; set; }

    public virtual NewsSourceDetail? SourceDetail { get; set; }
}
