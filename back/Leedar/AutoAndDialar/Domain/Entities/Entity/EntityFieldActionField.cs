using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionField : AuditableEntity<Guid>
    {
        public Guid EntityFieldActionId { get; set; }
        public virtual  EntityFieldAction? EntityFieldAction { get; set; }
        public Guid  EntityFieldActionTypeRequiredFieldId { get; set; }
        public virtual EntityFieldActionTypeRequiredField? EntityFieldActionTypeRequiredField { get; set; }
        public Guid? EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }
        public string? Value { get; set; }
    }
}
