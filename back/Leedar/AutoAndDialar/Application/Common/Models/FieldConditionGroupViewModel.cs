using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FieldConditionGroupViewModel
    {
        public Guid Id { get; set; }
        public Guid RelatedToCategoryPathFieldId { get; set; }
        public Guid CategoryPathFieldEventGroupId { get; set; }
        public Guid ConditionForId { get; set; }
        public bool? AndorOr { get; set; }
        public int ViewOrder { get; set; }
        public List<FieldConditionViewModel> Conditions { get; set; } = new List<FieldConditionViewModel>();
    }
}
