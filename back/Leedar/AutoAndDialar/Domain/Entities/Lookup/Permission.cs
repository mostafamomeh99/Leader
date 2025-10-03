using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class Permission : LookupEntity<Guid>
    {
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
