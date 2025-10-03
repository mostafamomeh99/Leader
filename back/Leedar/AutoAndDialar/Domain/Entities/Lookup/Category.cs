using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Log;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class Category : LookupEntity<Guid>
    {
        public Guid? CallCategoryMainId { get; set; }
        public virtual Category? CallCategoryMain { get; set; }

        public Guid? CategoryPathId { get; set; }
        public virtual CategoryPath? CategoryPath { get; set; }

        public Guid? AVAYAAURACampaignPredictiveId { get; set; }
        public virtual AVAYAAURACampaignPredictive? AVAYAAURACampaignPredictive { get; set; }

        public Guid? CallTypeId { get; set; }
        public virtual CallType? CallType { get; set; }

        public Guid? PriorityId { get; set; }
        public virtual Priority? Priority { get; set; }
        //public string UserGroup { get; set; }

        public virtual ICollection<Category>? CallCategorys { get; set; }
       


        public virtual ICollection<ScheduledCall>? ScheduledCalls { get; set; }
        public virtual ICollection<HistoricalCall>? HistoricalCalls { get; set; }





        public virtual ICollection<Pim_contact_attempts_history>? Pim_contact_attempts_historys { get; set; }

        public virtual ICollection<ContactUploadingLog>? ContactUploadingLogs { get; set; }
    }
}
