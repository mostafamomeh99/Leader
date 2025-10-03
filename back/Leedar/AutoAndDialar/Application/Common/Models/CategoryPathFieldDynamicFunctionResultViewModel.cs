using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldDynamicFunctionResultViewModel
    {
        public Guid DynamicFunctionResultId { get; set; }
        public Guid EntityFieldId { get; set; }
        public bool? IsResultToNotification { get; set; }
    }
}
