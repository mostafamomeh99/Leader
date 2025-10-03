using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldValue : AuditableEntity<Guid>
    {
        public Guid EntityFieldId { get; set; }
        public virtual required EntityField EntityField { get; set; }
        public Guid EntityPK { get; set; }//the id for the selected entity
        public string? Value { get; set; }
    }
}
