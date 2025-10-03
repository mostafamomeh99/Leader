using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldCondition : AuditableEntity<Guid>
    {
        public Guid EntityFieldConditionGroupId { get; set; }
        public virtual EntityFieldConditionGroup? EntityFieldConditionGroup { get; set; }

        public Guid FirstSideRelatedToEntityId { get; set; }
        public virtual Entity? FirstSideRelatedToEntity { get; set; }
        public Guid FirstSideFieldId { get; set; }

        public Guid ConditionTypeId { get; set; }
        public virtual ConditionType? ConditionType { get; set; }

        public Guid? SecondSideRelatedToEntityId { get; set; }
        public virtual Entity? SecondSideRelatedToEntity { get; set; }
        public string? CondetionValue { get; set; }

        public bool? ANDorOR { get; set; }
        public int ViewOrder { get; set; }
    }
}
