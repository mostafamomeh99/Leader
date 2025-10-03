using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.CategoryPath.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }

        public Dictionary<Guid,string> Categorys { get; set; }
    }
}
