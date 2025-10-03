using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldEventResultViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OutputIdentifire { get; set; }
        public Guid ResultId { get; set; }
        public Guid? CategoryPathFieldId { get; set; }
        public bool? IsNotification { get; set; }
        public bool? IsPathResult { get; set; }
        public bool? IsPathValue { get; set; }
    }
}
