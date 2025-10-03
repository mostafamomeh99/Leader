using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldConditionGroup : AuditableEntity<Guid>
    {
        public Guid EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }


        public Guid ConditionForId { get; set; }
        public virtual ConditionFor? ConditionFor { get; set; }
        public bool? ANDorOR { get; set; }

        public int ViewOrder { get; set; }
        public virtual ICollection<EntityFieldCondition>? EntityFieldConditions { get; set; }
    }
}
