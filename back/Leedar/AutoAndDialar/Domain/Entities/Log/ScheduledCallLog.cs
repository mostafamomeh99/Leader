using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Log
{
    public class ScheduledCallLog : AuditableEntity<Guid>
    {
        public Guid ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
        public Guid CallStatusId { get; set; }
        public virtual CallStatus? CallStatus { get; set; }
        public Guid? CallTypeId { get; set; }
        public virtual CallType? CallType { get; set; }


        public Guid? AssignToUserId { get; set; }
        public virtual User? AssignToUser { get; set; }
        public Guid AssignFromUserId { get; set; }
        public virtual User? AssignFromUser { get; set; }
        public DateTime? AssignToUserAt { get; set; }

        public Guid? ScheduledToUserId { get; set; }
        public virtual User? ScheduledToUser { get; set; }

        public Guid? ScheduledByUserId { get; set; }
        public virtual User? ScheduledByUser { get; set; }
        public DateTime? ScheduledToUserAt { get; set; }

        public DateTime? ScheduledCallDate { get; set; }

        public string? Body { get; set; }
        public string? BodyHTML { get; set; }

        public string? ScheduledToIPAddress { get; set; }

       

        public Guid CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public Guid? PriorityId { get; set; }
        public virtual Priority? Priority { get; set; }

        public Guid? LatestHistoricalCallId { get; set; }
        public virtual HistoricalCall? LatestHistoricalCall { get; set; }

        public string? ContactName { get; set; }
        public string? ContactIdentity { get; set; }
        public string? ContactMobile { get; set; }
        public string? CallStatusName { get; set; }

        public string? EmployeeName { get; set; }
        public string? CampaignName { get; set; }
        public string? CategoryName { get; set; }
        public string? PriorityName { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
