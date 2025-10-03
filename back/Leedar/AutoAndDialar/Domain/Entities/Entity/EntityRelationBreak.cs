using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities.Entity
{
    public class EntityRelationBreak
    {
        public Guid EntityId { get; set; }
        public virtual required Entity Entity { get; set; }
        public Guid EntityPK { get; set; }

        public Guid Entity2Id { get; set; }
        public virtual required Entity Entity2 { get; set; }
        public Guid Entity2PK { get; set; }
    }
}
