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
    public class AVAYAAURACampaignPredictive : LookupEntity<Guid>
    {
        public string? NameInAvayaSystem { get; set; }
        public bool IsPredictive { get; set; }
        
       
        public virtual ICollection<Category>? Categorys { get; set; }
    }
}
