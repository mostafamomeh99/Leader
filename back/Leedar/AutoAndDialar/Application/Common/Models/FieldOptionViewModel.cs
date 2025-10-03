using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FieldOptionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte IsActive { get; set; }

        public Guid? RelatedCategoryPathFieldId { get; set; }
        public Guid? RelatedEntityOptionId { get; set; }
        public Guid? RelatedEntityId { get; set; }

        public int ViewOrder { get; set; }
        public List<FieldOptionConditionGroupViewModel> ShowIfCondetionGroup { get; set; }
        public List<FieldOptionConditionGroupViewModel> SelectedIfCondetionGroup { get; set; }
        public List<FieldOptionConditionGroupViewModel> DisabledIfCondetionGroup { get; set; }
        public FieldOptionViewModel()
        {
            ShowIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>();
            SelectedIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>();
            DisabledIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>();
        }
    }
}
