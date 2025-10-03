using Domain.Common;
using Domain.Entities.Identity;

using Domain.Entities.Lookup;

using Shared.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Application
{
    public class PersonalInfo : AuditableEntity<Guid>
    {
        public PersonalInfo()
        {
        }
        public string? IdentityNumber { get; set; }


        public string? FullNameAr { get; set; }
        public string? FullNameEn { get; set; }

        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Email { get; set; }

       
        public string? Notes { get; set; }
       
        public virtual User? User { get; set; }
      
        public virtual Contact? Contact { get; set; }
       public Guid? CityId { get; set; }
        public virtual City? City { get; set; }

       

       
        
    }
}
