using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Log
{
    public class ContactUploadingLogVM

    { 

         public Guid Id { get; set; }
         public Guid? ContactId { get; set; }
         public string? CreatedAt { get; set; }
        public string? IdentityNumber { get; set; }
        public string? ContactName { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? AgentName { get; set; }
        public string? IsUploadedSuccessfully { get; set; }
        public int FileRow { get; set; }
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public string? DescriptionOthers { get; set; }
        public string? CategoryName { get; set; }
        public string? CampaignName { get; set; }
        public string? PriorityName { get; set; }

    }

}
