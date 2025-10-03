using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class DateFilterViewModel
    {
        public Guid? DateStartConditionType { get; set; }
        public DateTime? DateStart { get; set; }
        public Guid? DateEndConditionType { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
