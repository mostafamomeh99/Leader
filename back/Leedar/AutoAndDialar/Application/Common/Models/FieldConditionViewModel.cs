using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FieldConditionViewModel
    {
        public Guid Id { get; set; }

        public Guid? FieldConditionGroupId { get; set; }

        public Guid FieldId { get; set; }
        public Guid ConditionForId { get; set; }
        public Guid ConditionTypeId { get; set; }
        public string Value { get; set; }
        public bool? AndorOr { get; set; }

        public int ViewOrder { get; set; }
        public List<string> ValueList { get; set; }

        public Guid? ConditionRelationTypeId { get; set; }

        public Guid? CategoryPathFieldRelatedEntityFieldId { get; set; }
    }
}
