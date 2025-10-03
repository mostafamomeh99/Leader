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
    public class Contact : AuditableEntity<Guid>
    {
        public Guid PersonalInfoId { get; set; }
        public virtual  PersonalInfo? PersonalInfo { get; set; }

      
        public string? Notes { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdentityNumber { get; set; }

        public Guid? ContactCategoryId { get; set; }
        public virtual ContactCategory? ContactCategory { get; set; }



        public bool? IsDesable { get; set; }
       
        


       

        public virtual ICollection<ScheduledCall>? ScheduledCalls { get; set; }
        public virtual ICollection<HistoricalCall>? HistoricalCalls { get; set; }

       
        public virtual ICollection<ContactUploadingLog>? ContactUploadingLogs { get; set; }

       

        public virtual ICollection<Pim_contact_attempts_history>? Pim_contact_attempts_historys { get; set; }
      
       

    }
}

