using Domain.Common;
using Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class ConditionType : LookupEntity<Guid>
    {
        public virtual ICollection<EntityActionGroupCondition>? EntityActionConditions { get; set; }
        public virtual ICollection<EntityFieldActionGroupCondition>? EntityFieldActionConditions { get; set; }
        public virtual ICollection<EntityFieldCondition>? EntityFieldConditions { get; set; }
        public virtual ICollection<EntityFieldOptionCondition>? EntityFieldOptionConditions { get; set; }
    }
}
