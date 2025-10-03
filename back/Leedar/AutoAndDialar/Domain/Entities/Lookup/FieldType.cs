using Domain.Common;
using Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class FieldType : LookupEntity<Guid>
    {
        public virtual ICollection<EntityField>? EntityFields { get; set; }
        public virtual ICollection<EntityActionTypeRequiredField>? EntityActionTypeRequiredFields { get; set; }
        public virtual ICollection<EntityFieldActionTypeRequiredField>? EntityFieldActionTypeRequiredFields { get; set; }
    }
}
