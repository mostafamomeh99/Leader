using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Category.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public Guid? CategoryPathId { get; set; }
       // public string CallCategoryMainName { get; set; }
      //  public Guid? CallCategoryMainId { get; set; }
        public string? CategoryPathName { get; set; }


    }
}
