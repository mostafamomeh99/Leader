using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionDynamicFunctionParameter
    {
        public Guid Id { get; set; }
        public Guid EntityFieldActionId { get; set; }
        public virtual  EntityFieldAction? EntityFieldAction { get; set; }

        public Guid DynamicFunctionParameterId { get; set; }
        public virtual DynamicFunctionParameter? DynamicFunctionParameter { get; set; }

        public Guid? EntityFieldId { get; set; }
        public virtual EntityField? EntityField { get; set; }

        public string? Value { get; set; }
    }
}
