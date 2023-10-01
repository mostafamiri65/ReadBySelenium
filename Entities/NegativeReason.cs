using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NegativeReason
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;
}
