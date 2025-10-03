namespace Domain.Entities.Entity
{
    using Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EntityFieldActionType : LookupEntity<Guid>
    {
        public Guid? EntityId { get; set; }
        public virtual Entity? Entity { get; set; }
        public virtual ICollection<EntityFieldAction>? EntityFieldActions { get; set; }
        public virtual ICollection<EntityFieldActionTypeRequiredField>? EntityFieldActionTypeRequiredFields { get; set; }
    }
}
