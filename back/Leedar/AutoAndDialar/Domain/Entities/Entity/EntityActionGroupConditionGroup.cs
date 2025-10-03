using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionGroupConditionGroup : AuditableEntity<Guid>
    {
        public Guid EntityActionGroupId { get; set; }
        public virtual EntityActionGroup? EntityActionGroup { get; set; }
        public bool? ANDorOR { get; set; }
        public int ViewOrder { get; set; }


        public virtual ICollection<EntityActionGroupCondition>? EntityActionConditions { get; set; }
    }
}
