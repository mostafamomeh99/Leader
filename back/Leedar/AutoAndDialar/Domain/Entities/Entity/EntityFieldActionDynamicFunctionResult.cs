using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionDynamicFunctionResult
    {
        public Guid Id { get; set; }
        public Guid EntityFieldActionId { get; set; }
        public virtual EntityFieldAction? EntityFieldAction { get; set; }

        public Guid DynamicFunctionResultId { get; set; }
        public virtual  DynamicFunctionResult? DynamicFunctionResult { get; set; }

        public Guid? EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }
        public bool? IsResultToNotification { get; set; }
        public bool? IsPathResult { get; set; }
        public bool? IsPathValue { get; set; }
    }
}
