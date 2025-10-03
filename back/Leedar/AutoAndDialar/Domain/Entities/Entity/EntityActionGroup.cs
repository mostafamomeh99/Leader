using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionGroup : LookupEntity<Guid>
    {
        public Guid EntityId { get; set; }
        public virtual Entity? Entity { get; set; }
        //public Guid EntityBK { get; set; }
        public bool? ANDorOR { get; set; }
        public int ProcessOrder { get; set; }

        public virtual ICollection<EntityAction>? EntityActions { get; set; }
        public virtual ICollection<EntityActionGroupTriggerType>? EntityActionGroupTriggerTypes { get; set; }
        public virtual ICollection<EntityActionGroupConditionGroup>? EntityActionGroupConditionGroups { get; set; }
    }
}
