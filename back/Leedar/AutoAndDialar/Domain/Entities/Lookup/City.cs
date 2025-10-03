using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class City : LookupEntity<Guid>
    {
      

        public virtual ICollection<PersonalInfo>? PersonalInfos { get; set; }
    }
}
