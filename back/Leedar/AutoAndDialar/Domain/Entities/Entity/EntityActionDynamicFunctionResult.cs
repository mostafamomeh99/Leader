using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionDynamicFunctionResult
    {
        public Guid Id { get; set; }
        public Guid EntityActionId { get; set; }
        public virtual  EntityAction? EntityAction { get; set; }

        public Guid DynamicFunctionResultId { get; set; }
        public virtual DynamicFunctionResult? DynamicFunctionResult { get; set; }

        public Guid EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }
        public bool? IsResultToNotification { get; set; }
    }
}
