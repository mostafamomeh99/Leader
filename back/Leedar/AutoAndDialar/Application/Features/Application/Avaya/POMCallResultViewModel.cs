using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.Avaya
{
    public class POMCallResultViewModel

    { 

         public Guid Id { get; set; }
         public Guid? ContactId { get; set; }
         public DateTime? Contact_attempt_time { get; set; }
        public string? IdentityNumber { get; set; }
        public string? BeneficiryName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AgentName { get; set; }
        public string? CallStatus { get; set; }
        public string? CallCompletionCode { get; set; }
        public string? CallCompletionName { get; set; }
        public string? AttemtCallDateTime { get; set; }
        public string? RingbackDateTime { get; set; }
        public string? CallStartDateTime { get; set; }
        public string? CallCompletionDateTime { get; set; }
        public string? Contact_attempt_timeString { get; internal set; }
        public string? Last_nw_disposition_timeString { get; internal set; }
        public string? Call_start_timeString { get; internal set; }
        public string? Call_completion_timeString { get; internal set; }
        public string? CategoryName { get; set; }
        public string? CampaignName { get; set; }

    }

}
