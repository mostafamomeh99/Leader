using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionTypeRequiredField : AuditableEntity<Guid>
    {
        public Guid EntityActionTypeId { get; set; }
        public virtual  EntityActionType? EntityActionType { get; set; }

        public string? FieldName { get; set; }
        public Guid FieldTypeId { get; set; }
        public virtual  FieldType? FieldType { get; set; }
        public Guid? FieldShouldRelatedToEntityTypeId { get; set; }
        public virtual EntityType? FieldShouldRelatedToEntityType { get; set; }

        //public Guid FieldTypeIdasd { get; set; }

        public virtual ICollection<EntityActionField>? EntityActionFields { get; set; }
    }
}
