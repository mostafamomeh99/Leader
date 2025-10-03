using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Lookup;

namespace Domain.Entities.Entity
{
    public class EntityField : LookupEntity<Guid>
    {
        public Guid EntityFieldGroupId { get; set; }
        public virtual  EntityFieldGroup ? EntityFieldGroup { get; set; }

        public Guid FieldTypeId { get; set; }
        public virtual  FieldType? FieldType { get; set; }
        public Guid? RelatedToEntityId { get; set; }
        public virtual EntityType? RelatedToEntity { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? IsReportExportable { get; set; }
        public bool? IsForVisitReport { get; set; }
        public bool? IsForSpecialSammaryReport { get; set; }
        public int Unified { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public virtual ICollection<EntityFieldActionGroup>? EntityFieldActionGroups { get; set; }
        public virtual ICollection<EntityFieldConditionGroup>? EntityFieldConditionGroups { get; set; }
        public virtual ICollection<EntityFieldOption>? EntityFieldOptions { get; set; }
        public virtual ICollection<EntityFieldValue>? EntityFieldValues { get; set; }

        public virtual ICollection<EntityFieldActionDynamicFunctionParameter>? EntityFieldActionDynamicFunctionParameters { get; set; }
        public virtual ICollection<EntityFieldActionDynamicFunctionResult>? EntityFieldActionDynamicFunctionResults { get; set; }

        public virtual ICollection<EntityActionDynamicFunctionParameter>? EntityActionDynamicFunctionParameters { get; set; }
        public virtual ICollection<EntityActionDynamicFunctionResult>? EntityActionDynamicFunctionResults { get; set; }
        public virtual ICollection<EntityActionField>? EntityActionFields { get; set; }
        public virtual ICollection<EntityFieldActionField>? EntityFieldActionFields { get; set; }

        public virtual ICollection<HistoricalCallPathResult>? HistoricalCallPathResults { get; set; }


    }
}
