using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class EvaluatedResult
{
    public long Id { get; set; }

    public long NewsId { get; set; }

    public long EstimateId { get; set; }

    public long FieldOfUseId { get; set; }

    public long StatisticalSourceId { get; set; }

    public long UserId { get; set; }

    public virtual EstimateNews Estimate { get; set; } = null!;

    public virtual FieldOfUse FieldOfUse { get; set; } = null!;

    public virtual NewsRssReed News { get; set; } = null!;

    public virtual StatisticalSource StatisticalSource { get; set; } = null!;
}
