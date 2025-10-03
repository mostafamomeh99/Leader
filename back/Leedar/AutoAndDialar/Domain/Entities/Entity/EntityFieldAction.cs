using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldAction : LookupEntity<Guid>
    {
        public Guid EntityFieldActionGroupId { get; set; }
        public virtual EntityFieldActionGroup? EntityFieldActionGroup { get; set; }

        public Guid EntityFieldActionTypeId { get; set; }
        public virtual EntityFieldActionType? EntityFieldActionType { get; set; }

        public Guid? DynamicFunctionId { get; set; }
        public virtual DynamicFunction? DynamicFunction { get; set; }

        public int ProcessOrder { get; set; }

        public virtual ICollection<EntityFieldActionField>? EntityFieldActionFields { get; set; }

        public virtual ICollection<EntityFieldActionDynamicFunctionParameter>? EntityFieldActionDynamicFunctionParameters { get; set; }
        public virtual ICollection<EntityFieldActionDynamicFunctionResult>? EntityFieldActionDynamicFunctionResults { get; set; }

    }
}
