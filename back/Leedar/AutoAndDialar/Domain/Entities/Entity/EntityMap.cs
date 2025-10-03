using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities.Lookup;

namespace Domain.Entities.Entity
{
    public class EntityMap 
    {
        public Guid Id { get; set; }
        public string? RelationName { get; set; }
        public Guid EntityId { get; set; }
        public virtual required Entity Entity { get; set; }
        public Guid MappedEntityId { get; set; }
        public virtual required Entity MappedEntity { get; set; }
        public bool IsNullable { get; set; }


        public virtual ICollection<DynamicReportField>? DynamicReportFields { get; set; }
    }
}
