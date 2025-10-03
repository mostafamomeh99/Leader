using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FieldOptionConditionGroupViewModel
    {
        public Guid Id { get; set; }
        public Guid RelatedCategoryPathFieldOptionId { get; set; }
        public Guid ConditionForId { get; set; }
        public bool? AndorOr { get; set; }

        public List<FieldOptionConditionViewModel> Conditions { get; set; } = new List<FieldOptionConditionViewModel>();
    }
}
