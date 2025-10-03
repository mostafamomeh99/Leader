using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldActionViewModel
    {
        public Guid Id { get; set; }
        public Guid ActionTypeId { get; set; }

        // هون في شغل الداينمك فنكشن
        public Guid? DynamicFunctionId { get; set; }
        public List<CategoryPathFieldDynamicFunctionParameterViewModel> DynamicFunctionParameters { get; set; }
        public List<CategoryPathFieldDynamicFunctionResultViewModel> DynamicFunctionResults { get; set; }
    }
}
