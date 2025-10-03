using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionDynamicFunction
    {
        public Guid Id { get; set; }
        public Guid EntityFieldActionId { get; set; }
        public virtual required EntityFieldAction EntityFieldAction { get; set; }
        public Guid DynamicFunctionId { get; set; }
        public virtual required DynamicFunction DynamicFunction { get; set; }

        public virtual ICollection<EntityFieldActionDynamicFunctionParameter>? EntityFieldActionDynamicFunctionParameters { get; set; }
        public virtual ICollection<EntityFieldActionDynamicFunctionResult>? EntityFieldActionDynamicFunctionResults { get; set; }

    }
}
