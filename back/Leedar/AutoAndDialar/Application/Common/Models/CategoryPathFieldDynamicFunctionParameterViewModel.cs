using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
  public  class CategoryPathFieldDynamicFunctionParameterViewModel
    {
        public Guid DynamicFunctionParameterId { get; set; }
        public Guid FieldId { get; set; }
        public string Value { get; set; }
    }
}
