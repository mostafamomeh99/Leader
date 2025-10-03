using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionField : AuditableEntity<Guid>
    {
        public Guid EntityActionId { get; set; }
        public virtual  EntityAction? EntityAction { get; set; }
        public Guid EntityActionTypeRequiredFieldId { get; set; }
        public virtual EntityActionTypeRequiredField? EntityActionTypeRequiredField { get; set; }
        public Guid? EntityFieldId { get; set; }
        //public virtual EntityField EntityField { get; set; } // it should be known by EntityActionTypeRequiredField
        public string? Value { get; set; }
    }
}
