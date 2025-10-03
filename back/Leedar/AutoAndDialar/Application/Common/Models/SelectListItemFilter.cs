using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class SelectListItemFilter
    {
        public int? PageIndex { get; set; } 
        public int? PageSize { get; set; } 
        public Guid? MainId { get; set; } 
        public string Name { get; set; }
    }
}
