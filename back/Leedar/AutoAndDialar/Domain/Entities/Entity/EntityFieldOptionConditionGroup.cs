using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldOptionConditionGroup : AuditableEntity<Guid>
    {
        public Guid EntityFieldOptionId { get; set; }
        public virtual EntityFieldOption? EntityFieldOption { get; set; }

        public Guid ConditionForId { get; set; }
        public virtual ConditionFor? ConditionFor { get; set; }
        public bool? ANDorOR { get; set; }

        public virtual ICollection<EntityFieldOptionCondition>? EntityFieldOptionConditions { get; set; }
    }
}
