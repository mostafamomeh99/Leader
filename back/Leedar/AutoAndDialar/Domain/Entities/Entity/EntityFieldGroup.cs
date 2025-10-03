using Domain.Common;

namespace Domain.Entities.Entity
{
    public class EntityFieldGroup : LookupEntity<Guid>
    {
        public Guid EntityId { get; set; }
        public virtual Entity? Entity { get; set; }

        public virtual ICollection<EntityField>? EntityFields { get; set; }
    }
}
