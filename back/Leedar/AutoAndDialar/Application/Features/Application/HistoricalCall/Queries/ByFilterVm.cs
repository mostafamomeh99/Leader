namespace Application.Features.Application.HistoricalCall.Queries
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
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public Guid CallStatusId { get; set; }
        public string  CallStatus { get; set; }
        public Guid? CallTypeId { get; set; }
        public string  CallType { get; set; }


        public Guid? AssignToUserId { get; set; }
        public  string AssignToUser { get; set; }
        public Guid AssignFromUserId { get; set; }
        public  string AssignFromUser { get; set; }
        //public DateTime? AssignToUserAt { get; set; }

        public Guid? ScheduledToUserId { get; set; }
        public  string ScheduledToUser { get; set; }

        public Guid? ScheduledByUserId { get; set; }
        public  string ScheduledByUser { get; set; }
        //public DateTime? ScheduledToUserAt { get; set; }

    }
}
