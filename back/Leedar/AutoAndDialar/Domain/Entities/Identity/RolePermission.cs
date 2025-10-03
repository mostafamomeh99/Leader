using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }


        public virtual Role? Role { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
