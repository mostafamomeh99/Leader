using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FieldOptionConditionViewModel
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }
        public Guid ConditionTypeId { get; set; }
        public string Value { get; set; }
        public bool? AndorOr { get; set; }

        public int ViewOrder { get; set; }
        public List<string> ValueList { get; set; }

        public Guid? RelatedCategoryPathFieldId { get; set; } // معرف الحقل في المسار
        public Guid? RelatedEntityId { get; set; } // معرف الكيان المربوط
        public Guid? RelatedEntityOptionId { get; set; } // معرف الخيار في الكيان المربوط


        public Guid? CategoryPathFieldRelatedEntityFieldId { get; set; }
    }
}
