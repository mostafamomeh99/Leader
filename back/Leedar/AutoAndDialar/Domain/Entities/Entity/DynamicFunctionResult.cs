using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class DynamicFunctionResult : LookupEntity<Guid>
    {
        public Guid DynamicFunctionId { get; set; }
        public virtual required DynamicFunction DynamicFunction { get; set; }
        public string? OutputIdentifire { get; set; }

        public virtual ICollection<EntityFieldActionDynamicFunctionResult>? EntityFieldActionDynamicFunctionResults { get; set; }
        public virtual ICollection<EntityActionDynamicFunctionResult>? EntityActionDynamicFunctionResults { get; set; }
    }
}
