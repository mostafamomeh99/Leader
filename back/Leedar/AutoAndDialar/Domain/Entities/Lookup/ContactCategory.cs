using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class ContactCategory : LookupEntity<Guid>
    {
        public virtual ICollection<Contact>? Contacts { get; set; }
        
    }
}
