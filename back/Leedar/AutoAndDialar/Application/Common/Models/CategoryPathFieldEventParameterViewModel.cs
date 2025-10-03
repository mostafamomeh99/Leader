using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldEventParameterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ParameterIdentifire { get; set; }
        public Guid ParameterId { get; set; }
        public Guid? CategoryPathFieldId { get; set; }
        public string StaticValue { get; set; }
        public bool? IsRelatedToPathFields { get; set; }
        public Guid? FieldShouldRelatedToEntityTypeId { get; set; }
    }
}
