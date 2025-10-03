using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldEventViewModel
    {
        public Guid Id { get; set; }
        public Guid ActionTypeId { get; set; }
        public Guid? DynamicFunctionId { get; set; }
        public string DynamicFunctionIdentifire { get; set; }
        public List<CategoryPathFieldEventParameterViewModel> Parameters { get; set; }
        public List<CategoryPathFieldEventResultViewModel> Results { get; set; }
        public int ProcessOrder { get; set; }
    }
}
