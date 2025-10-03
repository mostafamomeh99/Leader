namespace Application.Features.Application.ScheduledCall.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Entities.Lookup;
    using Domain.Entities.Identity;
    using Domain.Entities.Application;



    public class ByFilterVm
    {
        public List<ByFilterVm> Items;

        public Guid Id { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Guid? CategoryPathId { get; set; }
        public string CategoryPath { get; set; }
        public Guid? CampaignId { get; set; }
        public string Campaign { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Arrears { get; set; }
        public Dictionary<string, string> ArrearsDic { get; set; }
        public Guid? PreviousCallStatusId { get; set; }

        public string PreviousCallStatus { get; set; }
        //public DateTime? ScheduledToUserAt { get; set; }

        public string AssignedToUser { get; set; }
        public string AssignedToUserAt { get; set; }
        public string AssignedFromUser { get; set; }
        public string ScheduledToUser { get; set; }
        public string ScheduledCallDate { get; set; }
        public string ScheduledByUser { get; set; }
        public string ScheduledToUserAt { get; set; }
        public string LatestCallByUser { get; set; }
        public string LatestCallAt { get; set; }
        




    }
}
