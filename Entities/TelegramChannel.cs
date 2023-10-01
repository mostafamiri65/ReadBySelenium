using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class TelegramChannel
{
    public long Id { get; set; }

    public string TelegramChannelName { get; set; } = null!;

    public long TelegramChannelId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public Guid Gid { get; set; }

    public virtual ICollection<TelegramPost> TelegramPosts { get; set; } = new List<TelegramPost>();
}
