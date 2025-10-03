using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PathEventGroupViewModel
    {
        public Guid Id { get; set; }
        public List<PathEventViewModel> Events { get; set; }
        public Dictionary<Guid, bool> ExecuteTrigger { get; set; }
        public List<FieldConditionGroupViewModel> ExecuteIfCondetionGroup { get; set; }
        public int ProcessOrder { get; set; }
        public bool? AndorOr { get; set; }
    }
}
