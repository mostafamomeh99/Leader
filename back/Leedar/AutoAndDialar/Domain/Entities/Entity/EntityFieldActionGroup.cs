using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionGroup : LookupEntity<Guid>
    {
        public Guid EntityFieldId { get; set; }
        public virtual  EntityField? EntityField { get; set; }
        public bool? ANDorOR { get; set; }
        public int ProcessOrder { get; set; }

        public virtual ICollection<EntityFieldAction>? EntityFieldActions { get; set; }
        public virtual ICollection<EntityFieldActionGroupTriggerType>? EntityFieldActionGroupTriggerTypes { get; set; }
        public virtual ICollection<EntityFieldActionGroupConditionGroup>? EntityFieldActionGroupConditionGroups { get; set; }
    }
}
