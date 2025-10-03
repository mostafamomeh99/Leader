using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class Priority : LookupEntity<Guid>
    {
        public int Number { get; set; }
        public virtual ICollection<Campaign>? Campaigns { get; set; }
       
        public virtual ICollection<Category>? Categorys { get; set; }
        public virtual ICollection<ScheduledCall>? ScheduledCalls { get; set; }
        public virtual ICollection<HistoricalCall>? HistoricalCalls { get; set; }


        public virtual ICollection<ContactUploadingLog>? ContactUploadingLogs { get; set; }
    }
}
