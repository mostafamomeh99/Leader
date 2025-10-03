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

    public class EntityFieldActionTypeConfig : IEntityTypeConfiguration<EntityFieldActionType>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionType> builder)
        {
            builder.ToTable(nameof(EntityFieldActionType), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldActions)
               .WithOne(e => e.EntityFieldActionType)
               .HasForeignKey(e => e.EntityFieldActionTypeId);

            builder
               .HasMany(e => e.EntityFieldActionTypeRequiredFields)
               .WithOne(e => e.EntityFieldActionType)
               .HasForeignKey(e => e.EntityFieldActionTypeId);

            

            builder.HasData(
            new EntityFieldActionType
            {
                Id = Shared.Struct.EntityFieldActionType.ExecuteDynamicFunction,
                NameAr = "تنفيذ إجراء ديناميكي",
                NameEn = "Execute Dynamic Function",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            });

        }
    }
}
