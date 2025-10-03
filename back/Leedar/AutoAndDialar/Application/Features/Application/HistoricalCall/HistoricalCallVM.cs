using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall
{
    public class HistoricalCallVM
    {
        public Guid Id { get; set; }
        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public Guid? ContactId { get; set; }
        public Guid? CallStatusId { get; set; }
        public Guid? CallTypeId { get; set; }
        public Guid? AssignToUserId { get; set; }
        public Guid? AssignFromUserId { get; set; }
        public DateTime? AssignToUserAt { get; set; }
        public Guid? ScheduledToUserId { get; set; }
        public Guid? ScheduledByUserId { get; set; }
        public DateTime? ScheduledToUserAt { get; set; }
        public DateTime? ScheduledCallDate { get; set; }
        
        public double? CallDuration { get; set; }
       
        public bool? IsLatestCall { get; set; }
        public Guid? LatestHistoricalCallId { get; set; }
       
        public Guid? CampaignId { get; set; }
        public Guid? CategoryId { get; set; }


        public string? CategoryName { get; set; }
        public string? CampaignName { get; set; }
        public string? CallStatusName { get; set; }
        public string? AssignToUserName { get; set; }
        public string? CallTypeName { get; set; }
        public string? IsBillCreated { get; set; }
        public string? IsBillPaid { get; set; }
        public string? BillPaidDate { get; set; }
        public string? CallDate { get; set; }


        public string? SubNote { get; set; }
    }
}
