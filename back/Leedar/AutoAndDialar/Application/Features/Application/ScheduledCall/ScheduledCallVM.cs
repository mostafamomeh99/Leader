using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall
{
    public class ScheduledCallVM
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public Guid CallStatusId { get; set; }
        public Guid? CallTypeId { get; set; }
        public Guid? AssignToUserId { get; set; }
        public Guid AssignFromUserId { get; set; }
        public DateTime? AssignToUserAt { get; set; }
        public Guid? ScheduledToUserId { get; set; }
        public Guid? ScheduledByUserId { get; set; }
        public DateTime? ScheduledToUserAt { get; set; }
        public DateTime? ScheduledCallDate { get; set; }
        public string? Body { get; set; }
        public string? ScheduledToIPAddress { get; set; }
        public Guid? ContractId { get; set; }
        public Guid? LatestHistoricalCallId { get; set; }

        public Guid CampaignId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
