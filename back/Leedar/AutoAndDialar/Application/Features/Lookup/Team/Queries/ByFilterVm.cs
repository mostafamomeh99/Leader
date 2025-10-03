using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Team.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public Guid LeaderId { get; set; }
        public string LeaderName { get; set; }

        public Dictionary<Guid,string> TeamUsers { get; set; }
        public int TeamUsersCount { get; set; }
    }
}
