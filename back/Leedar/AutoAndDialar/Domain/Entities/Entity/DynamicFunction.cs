using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class DynamicFunction : LookupEntity<Guid>
    {
        public string? FunctionIdentifire { get; set; }

        public virtual ICollection<DynamicFunctionParameter>? DynamicFunctionParameters { get; set; }
        public virtual ICollection<DynamicFunctionResult>? DynamicFunctionResults { get; set; }

        //public virtual ICollection<EntityFieldActionDynamicFunction> EntityFieldActionDynamicFunctions { get; set; }

        public virtual ICollection<EntityFieldAction>? EntityFieldActions { get; set; }
        public virtual ICollection<EntityAction>? EntityActions { get; set; }
    }
}
