using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class Team : LookupEntity<Guid>
    {
        public Guid? LeaderId { get; set; }
        public virtual User? Leader { get; set; }

        public virtual ICollection<UserTeams>? UserTeams { get; set; }
    }
}
