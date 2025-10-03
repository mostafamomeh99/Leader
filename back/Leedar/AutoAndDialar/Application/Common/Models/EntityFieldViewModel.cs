using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class EntityFieldViewModel
    {
        public Guid Id { get; set; }
        public Guid FieldTypeId { get; set; }
        public string Name { get; set; }
        public int ViewOrder { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsReportExportable { get; set; }
        public bool? IsForVisitReport { get; set; }
        public bool? IsForSpecialSammaryReport { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Unified { get; set; }

        public bool IsOptionRelatedToEntity { get; set; }
        public Guid? OptionsRelatedToEntityId { get; set; }

        public List<FieldOptionViewModel> FieldOption { get; set; } = new List<FieldOptionViewModel>();

        public List<FieldConditionGroupViewModel> ShowIfCondetionGroup { get; set; } = new List<FieldConditionGroupViewModel>();
        public List<FieldConditionGroupViewModel> ReadOnlyIfCondetionGroup { get; set; } = new List<FieldConditionGroupViewModel>();
        public List<FieldConditionGroupViewModel> DisabledIfCondetionGroup { get; set; } = new List<FieldConditionGroupViewModel>();
        public List<CategoryPathFieldEventGroupViewModel> EventsGroup { get; set; } = new List<CategoryPathFieldEventGroupViewModel>();
    }
}
