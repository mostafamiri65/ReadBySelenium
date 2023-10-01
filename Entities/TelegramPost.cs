using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class TelegramPost
{
    public long Id { get; set; }

    public long TelegramChannelId { get; set; }

    public long PostId { get; set; }

    public string PostContent { get; set; } = null!;

    public string PostDate { get; set; } = null!;

    public string? PostUsername { get; set; }

    public string? PostMedia { get; set; }

    public int? PostForwards { get; set; }

    public string? PostEditedDate { get; set; }

    public int? PostViews { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual TelegramChannel TelegramChannel { get; set; } = null!;
}
