using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CategoryPathFieldEventGroupViewModel
    {
        public Guid Id { get; set; }
        public List<CategoryPathFieldEventViewModel> Events { get; set; } = new List<CategoryPathFieldEventViewModel>();
        public Dictionary<Guid, bool> ExecuteTrigger { get; set; } = new Dictionary<Guid, bool>();
        public List<FieldConditionGroupViewModel> ExecuteIfCondetionGroup { get; set; } = new List<FieldConditionGroupViewModel>();
        public bool? AndorOr { get; set; }
        public int ProcessOrder { get; set; }
    }
}
//public Guid ActionTypeId { get; set; }
//public Guid RelatedToCategoryPathFieldId { get; set; }
//public byte? AndorOr { get; set; }