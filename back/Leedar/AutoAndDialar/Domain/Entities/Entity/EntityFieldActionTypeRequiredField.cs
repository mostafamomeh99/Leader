using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionTypeRequiredField : AuditableEntity<Guid>
    {
        public Guid EntityFieldActionTypeId { get; set; }
        public virtual required EntityFieldActionType EntityFieldActionType { get; set; }

        public string? FieldName { get; set; }
        public Guid FieldTypeId { get; set; }
        public virtual required FieldType FieldType { get; set; }
        public Guid? FieldShouldRelatedToEntityId { get; set; }
        public virtual Entity? FieldShouldRelatedToEntity { get; set; }

        public virtual ICollection<EntityFieldActionField>? EntityFieldActionFields { get; set; }
    }
}
