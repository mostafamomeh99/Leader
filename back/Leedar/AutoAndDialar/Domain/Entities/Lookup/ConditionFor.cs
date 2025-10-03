using Domain.Common;
using Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class ConditionFor : LookupEntity<Guid>
    {
        public virtual ICollection<EntityFieldConditionGroup>? EntityFieldConditionGroups { get; set; }
        public virtual ICollection<EntityFieldOptionConditionGroup>? EntityFieldOptionConditionGroups { get; set; }

       
    }
}
