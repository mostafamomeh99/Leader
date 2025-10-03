using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Entity
{

    public class EntityActionTypeRequiredFieldConfig : IEntityTypeConfiguration<EntityActionTypeRequiredField>
    {
        public void Configure(EntityTypeBuilder<EntityActionTypeRequiredField> builder)
        {
            builder.ToTable(nameof(EntityActionTypeRequiredField), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityActionFields)
               .WithOne(e => e.EntityActionTypeRequiredField)
               .HasForeignKey(e => e.EntityActionTypeRequiredFieldId);

            builder.HasData(
                new EntityActionTypeRequiredField
                {
                    Id = new Guid("17b7dc0b-afe2-4ff5-b3d7-29cb93e04b74"),
                    EntityActionTypeId = Shared.Struct.EntityActionType.ScheduleNewCall,
                    //FieldShouldRelatedToEntityId = ,
                    FieldTypeId = Shared.Struct.FieldType.DateTime,
                    FieldName = "حقل تاريخ جدولة المكالمة الجديدة",
                    StateCode = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                   
                },

                new EntityActionTypeRequiredField
                {
                    Id = new Guid("dfbd996e-4e65-4261-b4d2-d5fd584035c6"),
                    EntityActionTypeId = Shared.Struct.EntityActionType.ScheduleNewCall,
                    FieldShouldRelatedToEntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                    FieldTypeId = Shared.Struct.FieldType.DateTime,
                    FieldName = "حقل نوع المسار المراد إعادة الجدولة عليه",
                    StateCode = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                });
        }
    }
}
