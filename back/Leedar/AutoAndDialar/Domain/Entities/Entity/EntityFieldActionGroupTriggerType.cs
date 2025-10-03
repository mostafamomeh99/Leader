using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityFieldActionGroupTriggerType
    {
        public Guid EntityFieldActionGroupId { get; set; }
        public virtual  EntityFieldActionGroup? EntityFieldActionGroup { get; set; }
        public Guid TriggerTypeId { get; set; }
        public virtual TriggerType? TriggerType { get; set; }
    }
}
