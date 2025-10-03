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
    public class HistoricalCallGeneralReportSammary : AuditableEntity<Guid>
    {
        public Guid HistoricalCallId { get; set; }
        public virtual required HistoricalCall HistoricalCall { get; set; }
        public Guid ContactId { get; set; }
        public virtual required Contact Contact { get; set; }

        public Guid CallStatusId { get; set; }
        public virtual required CallStatus CallStatus { get; set; }

        public Guid CategoryId { get; set; }
        public virtual required Category Category { get; set; }

        public Guid CampaignId { get; set; }
        public virtual required Campaign Campaign { get; set; }

        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }

        public Guid? LeaderId { get; set; }
        public virtual User? Leader { get; set; }

        public string? ContactIdentity { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone1 { get; set; }
        public string? ContactPhone2 { get; set; }
    
        public Guid? CallTypeId { get; set; }
        public virtual CallType ? CallType { get; set; }
        public DateTime CallDate { get; set; }
        public double? CallDuration { get; set; }
        public string? CallDurationString { get; set; }
        public string? CallStatusName { get; set; }
        public string? SubCallStatusName { get; set; }
        public string? CallStatusResult { get; set; }
        public string? CallStatusResultSub { get; set; }
        public string? CallStatusOtherNote { get; set; }
       
        public string? CategoryName { get; set; }
        public string? CampaignName { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeNumber { get; set; }
        
        public string? LeaderName { get; set; }
       
       
        public DateTime? CallUpload { get; set; }
        public DateTime? CallStartAt { get; set; }
        public DateTime? CallEndAt { get; set; }
        public string? PriorityName { get; set; }
    }
}
