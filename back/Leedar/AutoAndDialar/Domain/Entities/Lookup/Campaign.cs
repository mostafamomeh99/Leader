using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Log;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class Campaign : LookupEntity<Guid>
    {
        public Guid? PriorityId { get; set; }
        public virtual Priority? Priority { get; set; }


        public virtual ICollection<ScheduledCall>? ScheduledCalls { get; set; }
        public virtual ICollection<HistoricalCall>? HistoricalCalls { get; set; }





        public virtual ICollection<Pim_contact_attempts_history> Pim_contact_attempts_historys { get; set; }

        public virtual ICollection<ContactUploadingLog> ContactUploadingLogs { get; set; }
    }
}
