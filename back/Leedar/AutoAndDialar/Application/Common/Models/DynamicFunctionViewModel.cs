using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class DynamicFunctionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        
        public List<DynamicFunctionParameter> Parameters { get; set; }
        public List<DynamicFunctionResult> Results { get; set; }
    }
    public class DynamicFunctionParameter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class DynamicFunctionResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
