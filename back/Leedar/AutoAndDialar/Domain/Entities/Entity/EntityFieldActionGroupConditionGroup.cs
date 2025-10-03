using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionGroupConditionGroup : AuditableEntity<Guid>
    {
        public Guid EntityFieldActionGroupId { get; set; }
        public virtual EntityFieldActionGroup? EntityFieldActionGroup { get; set; }
        public bool? ANDorOR { get; set; }
        public int ViewOrder { get; set; }

        public virtual ICollection<EntityFieldActionGroupCondition>? EntityFieldActionConditions { get; set; }
    }
}
