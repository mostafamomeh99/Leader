using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Log
{
    public class Pim_contact_attempts_historyLog : AuditableEntity<Guid>
    {
        public long Pim_session_id { get; set; }
        public int Completion_Code_id { get; set; }
        public string? Completion_Code_Name { get; set; }
        public string? Completion_Code_Name_Ar { get; set; }
        public int? Sys_completion_code_id { get; set; }

        public DateTime? Contact_attempt_time { get; set; }
        public DateTime? Last_nw_disposition_time { get; set; }
        public DateTime? Call_start_time { get; set; }
        public DateTime? Call_completion_time { get; set; }

        public string? Ucid { get; set; }
        public string? Address { get; set; }
        public string? Agent_id { get; set; }
        public int? Campaign_id { get; set; }
        public int? Campaign_list_id { get; set; }
        public double CallDuration { get; set; }
        public bool IsSuccess { get; set; }


        public Guid? ContactId { get; set; }
        public virtual Contact? Contact { get; set; }

        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }

        public Guid? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public Guid? CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }


        public Guid? ScheduledCallId { get; set; }
        public Guid? HistoricalCallId { get; set; }
        public virtual HistoricalCall? HistoricalCall { get; set; }

    }
}
