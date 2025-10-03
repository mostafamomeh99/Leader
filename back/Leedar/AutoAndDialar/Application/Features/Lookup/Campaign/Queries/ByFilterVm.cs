using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Campaign.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public Guid? PriorityId { get; set; }
        public string? PriorityName { get; set; }

       
    }
}
