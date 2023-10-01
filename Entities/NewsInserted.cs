using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class NewsInserted
{
    public long Id { get; set; }

    public string NewsTitle { get; set; } = null!;

    public string? NewsDescription { get; set; }

    public string NewsUrl { get; set; } = null!;

    public string NewsPublishedDate { get; set; } = null!;

    public long? EstimateId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UserCreatedId { get; set; }

    public string? UserCreatedIp { get; set; }

    public long? ModifiedUserId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedIp { get; set; }

    public bool IsDelete { get; set; }

    public Guid Gid { get; set; }

    public int? ManagementSourceId { get; set; }

    public string? EstimateDscp { get; set; }

    public long? NegativeReasonId { get; set; }
}
