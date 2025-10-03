using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.Contact.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string? IdentityNumber { get; set; }

        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
     
        public string? Notes { get; set; }
       
      
      
        public string? LatestCallCreatedOn { get; set; }
        public string? LatestCallStatus { get; set; }  
        public int HistoricalCallCount { get; set; }
        public List<ByFilterVM>? Items { get; set; }

    }
}
