using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldOption : LookupEntity<Guid>
    {
        public Guid EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }

        public byte IsActive { get; set; }
        public Guid? RelatedEntityOptionId { get; set; }


        //public bool? isEqualToEntityFieldId { get; set; }
        //public Guid? EqualToEntityFieldId { get; set; }
        //public Guid? EntityId_EqualToEntityFieldId { get; set; }


        public virtual ICollection<EntityFieldOptionConditionGroup> ?EntityFieldOptionConditionGroups { get; set; }
    }
}
