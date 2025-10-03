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
    public class Entity : AuditableEntity<Guid>
    {
        public Guid EntityTypeId { get; set; }
        public virtual  EntityType? EntityType { get; set; }

        // whene Entity is for custom field in entity table
        public Guid? RelatedEntityPK { get; set; }
        //public Guid? RelatedEntityId { get; set; }
        //public virtual Entity RelatedEntity { get; set; }
        //public virtual ICollection<Entity> RelatedEntity_Entitys { get; set; }

        public Guid? CallStatusFieldId { get; set; }
        public Guid? SubCallStatusFieldId { get; set; }

        public Guid? NoteId { get; set; }
        public Guid? SubNoteId { get; set; }
        public Guid? OtherNoteId { get; set; }
       

        public virtual ICollection<SystemProgress>? SystemProgresses { get; set; }

        public virtual ICollection<EntityActionGroupCondition>? FirstSideRelatedToEntity_EntityActionConditions { get; set; }
        public virtual ICollection<EntityActionGroupCondition>? SecondSideRelatedToEntity_EntityActionConditions { get; set; }
        public virtual ICollection<EntityActionGroup>? EntityActionGroups { get; set; }
        //public virtual ICollection<EntityField> EntityFields { get; set; }



        public virtual ICollection<EntityFieldActionType>? EntityFieldActionTypes { get; set; }

        public virtual ICollection<EntityFieldActionGroupCondition>? FirstSideRelatedToEntity_EntityFieldActionConditions { get; set; }
        public virtual ICollection<EntityFieldActionGroupCondition>? SecondSideRelatedToEntity_EntityFieldActionConditions { get; set; }

        public virtual ICollection<EntityFieldCondition>? FirstSideRelatedToEntity_EntityFieldConditions { get; set; }
        public virtual ICollection<EntityFieldCondition>? SecondSideRelatedToEntity_EntityFieldConditions { get; set; }

        public virtual ICollection<EntityFieldGroup>? EntityFieldGroups { get; set; }

        public virtual ICollection<EntityFieldOptionCondition>? FirstSideRelatedToEntity_EntityFieldOptionConditions { get; set; }
        public virtual ICollection<EntityFieldOptionCondition>? SecondSideRelatedToEntity_EntityFieldOptionConditions { get; set; }


        public virtual ICollection<EntityMap>? Entity_EntityMaps { get; set; }
        public virtual ICollection<EntityMap>? MappedEntity_EntityMaps { get; set; }

        public virtual ICollection<EntityRelationBreak>? Entity_EntityRelationBreaks { get; set; }
        public virtual ICollection<EntityRelationBreak>? Entity2_EntityRelationBreaks { get; set; }


        public virtual ICollection<DynamicReport>? DynamicReports { get; set; }


        public virtual ICollection<EntityFieldActionTypeRequiredField>? EntityFieldActionTypeRequiredFields { get; set; }
    }
}
