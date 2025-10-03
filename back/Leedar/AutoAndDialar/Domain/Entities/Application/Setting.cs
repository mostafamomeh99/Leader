using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Application
{
    public class Setting : LookupEntity<Guid>
    {
        public string? NameForSystem { get; set; }
        public string? Value { get; set; }
    }
}
