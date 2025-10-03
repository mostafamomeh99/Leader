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
    public class AppSetting : LookupEntity<Guid>
    {
        public string? SectionName { get; set; }
        public string? KeyName { get; set; }
        public string? Value { get; set; }
    }
}
