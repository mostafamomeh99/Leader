using Domain.Common;
using Domain.Entities.Log;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Application
{
    public class AutoContact : AuditableEntity<Guid>
    {
       

      
        public string? Notes { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdentityNumber { get; set; }
        public bool ? IsSendToAvaya { get; set; }
        public Guid CategoryId { get; set; }
        public virtual required Category Category { get; set; }
        public Guid CampaignId { get; set; }

        public virtual required Campaign Campaign { get; set; }
        public Guid? ScheduledCallId {  get; set; }
        public virtual ScheduledCall? ScheduledCall { get; set; }



        public bool? IsDesable { get; set; }

        public bool IsUploadedSuccessfully { get; set; }
        public int FileRow { get; set; }
        public required string FileName { get; set; }
        public string? Description { get; set; }
        public string? DescriptionOthers { get; set; }
        public virtual ICollection<Pim_contact_attempts_history>? Pim_contact_attempts_historys { get; set; }
      
       

    }
}

