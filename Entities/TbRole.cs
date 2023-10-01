using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class TbRole
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public bool HasAdminAccess { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public bool IsSecretary { get; set; }

    public virtual ICollection<TbUserRole> TbUserRoles { get; set; } = new List<TbUserRole>();
}
