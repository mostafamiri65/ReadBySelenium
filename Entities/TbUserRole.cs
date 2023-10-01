using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class TbUserRole
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long RoleId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public virtual TbRole Role { get; set; } = null!;

    public virtual TbUser User { get; set; } = null!;
}
