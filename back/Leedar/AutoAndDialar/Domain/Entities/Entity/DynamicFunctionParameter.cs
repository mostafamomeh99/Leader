using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class DynamicFunctionParameter : LookupEntity<Guid>
    {
        public Guid DynamicFunctionId { get; set; }
        public virtual required DynamicFunction DynamicFunction { get; set; }
        public string? FunctionIdentifire { get; set; }

        public virtual ICollection<EntityFieldActionDynamicFunctionParameter>? EntityFieldActionDynamicFunctionParameters { get; set; }
        public virtual ICollection<EntityActionDynamicFunctionParameter>? EntityActionDynamicFunctionParameters { get; set; }
    }
}
