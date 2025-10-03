using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class CallType : LookupEntity<Guid>
    {
        public virtual ICollection<ScheduledCall>? ScheduledCalls { get; set; }
        public virtual ICollection<HistoricalCall>? HistoricalCalls { get; set; }
        public virtual ICollection<Category>? Categorys { get; set; }
        
    }
}
