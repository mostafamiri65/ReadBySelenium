using System;
using System.Collections.Generic;

namespace ReadBySelenium.Entities;

public partial class TbUser
{
    public long Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Mobile { get; set; }

    public string? FullName { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public virtual ICollection<TbUserRole> TbUserRoles { get; set; } = new List<TbUserRole>();
}
