using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PathEventViewModel
    {
        public Guid Id { get; set; }
        public Guid ActionTypeId { get; set; }
        public Guid? DynamicFunctionId { get; set; }
        public List<CategoryPathFieldEventParameterViewModel> Parameters { get; set; }
        public List<CategoryPathFieldEventResultViewModel> Results { get; set; }
        //public List<PathEventFieldLinks> FiledLinks { get; set; }
        public int ProcessOrder { get; set; }
    }
    //public class PathEventFieldLinks
    //{
    //    public Guid Id { get; set; }
    //    public Guid ParameterId { get; set; }
    //    public Guid? CategoryPathField { get; set; }
    //    public string StaticValue { get; set; }
    //}
}
