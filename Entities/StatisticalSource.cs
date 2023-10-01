using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class StatisticalSource
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EvaluatedResult> EvaluatedResults { get; set; } = new List<EvaluatedResult>();
}
