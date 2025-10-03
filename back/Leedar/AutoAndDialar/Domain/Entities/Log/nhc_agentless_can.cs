using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Log
{
    public class nhc_agentless_can 
    {
       public Guid IdGu { get; set; }
        public long id { get; set; }
        public string? UCID { get; set; }
        public string? agentid { get; set; }
        public string? callernumber { get; set; }
        public string? evalresult1 { get; set; }

        public DateTime? submitdate { get; set; }
      


        public string? evalresult2 { get; set; }
        public string? channel { get; set; }
       

    }
}
