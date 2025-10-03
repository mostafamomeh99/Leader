using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall
{
    public class ScheduledCallForStaticsExcelVM
    {
        public Guid Id { get; set; }
      
        public string ContactName { get; set; }
        public string ContactIdentity { get; set; }
        public string ContactPhone { get; set; }
        public string CallStatusName { get; set; }
        public string CallTypeName { get; set; }
        public string AssignToUserName { get; set; }
        public string AssignFromUserName { get; set; }
        public string AssignToUserAt { get; set; }
        public string ScheduledToUserName { get; set; }
        public string ScheduledByUserName { get; set; }
        public string ScheduledToUserAt { get; set; }
        public string ScheduledCallDate { get; set; }
       
        

        public string CampaignName{ get; set; }
        public string CategoryName { get; set; }
    }
}
