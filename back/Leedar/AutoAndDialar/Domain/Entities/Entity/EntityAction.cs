using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityAction : LookupEntity<Guid>
    {
        public Guid EntityActionGroupId { get; set; }
        public virtual  EntityActionGroup? EntityActionGroup { get; set; }
        public Guid  EntityActionTypeId { get; set; }
        public virtual EntityActionType? EntityActionType { get; set; }
        public int ProcessOrder { get; set; }

        public Guid? DynamicFunctionId { get; set; }
        public virtual DynamicFunction? DynamicFunction { get; set; }

        //public virtual ICollection<EntityActionGroupConditionGroup> EntityActionConditionGroups { get; set; }
        public virtual ICollection<EntityActionField>? EntityActionFields { get; set; }
        public virtual ICollection<EntityActionDynamicFunctionParameter>? EntityActionDynamicFunctionParameters { get; set; }

        public virtual ICollection<EntityActionDynamicFunctionResult>? EntityActionDynamicFunctionResults { get; set; }
    }
}
