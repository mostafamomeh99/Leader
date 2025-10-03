using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
   public class UserPermission
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual User? User { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
