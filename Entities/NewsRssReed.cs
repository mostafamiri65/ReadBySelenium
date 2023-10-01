using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NewsRssReed
{
    public long Id { get; set; }

    public long NewsSourceDetailId { get; set; }

    public string? Title { get; set; }

    public string? LinkUrl { get; set; }

    public string? Description { get; set; }

    public string? PublishedDate { get; set; }

    public string? Enclosure { get; set; }

    public string? Author { get; set; }

    public string? Category { get; set; }

    public DateTime? RealPublishDate { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public DateTime? ProcDate { get; set; }

    public bool? IsOil { get; set; }

    public virtual ICollection<EvaluatedResult> EvaluatedResults { get; set; } = new List<EvaluatedResult>();
}
