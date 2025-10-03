using Domain.Common;
using Domain.Entities.Entity;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class TriggerType : LookupEntity<Guid>
    {
        public virtual ICollection<EntityActionGroupTriggerType>? EntityActionGroupTriggerTypes { get; set; }
        public virtual ICollection<EntityFieldActionGroupTriggerType>? EntityFieldActionGroupTriggerTypes { get; set; }
    }
}
