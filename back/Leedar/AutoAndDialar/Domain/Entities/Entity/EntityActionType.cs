namespace Domain.Entities.Entity
{
    using Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EntityActionType : LookupEntity<Guid>
    {
        public Guid? EntityTypeId { get; set; }
        public virtual EntityType? EntityType { get; set; }
        public virtual ICollection<EntityAction>? EntityActions { get; set; }
        public virtual ICollection<EntityActionTypeRequiredField>? EntityActionTypeRequiredFields { get; set; }
    }
}
