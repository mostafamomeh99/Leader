using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class EntityActionGroupTriggerType
    {
        public Guid EntityActionGroupId { get; set; }
        public virtual EntityActionGroup? EntityActionGroup { get; set; }
        public Guid TriggerTypeId { get; set; }
        public virtual TriggerType? TriggerType { get; set; }
    }
}
