using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Lookup;

namespace Domain.Entities.Entity
{
    public class EntityType : LookupEntity<Guid>
    {
        public string? SchemaName { get; set; }
        public string? TabelName { get; set; }
        public virtual ICollection<Entity>? Entitys { get; set; }
        public virtual ICollection<EntityActionTypeRequiredField>? EntityActionTypeRequiredFields { get; set; }

        public virtual ICollection<EntityField>? EntityFields { get; set; }
        public virtual ICollection<EntityActionType>? EntityActionTypes { get; set; }
        
    }
}
