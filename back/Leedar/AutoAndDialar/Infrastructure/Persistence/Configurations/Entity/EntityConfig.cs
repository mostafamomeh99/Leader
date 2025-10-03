namespace Infrastructure.Persistence.Configurations.Entity
{
    using Domain.Entities.Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Shared.Constants;

    public class EntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable(nameof(Entity), EntitySchema.Entity).HasKey(x => x.Id);



            builder
              .HasMany(e => e.SystemProgresses)
              .WithOne(e => e.Entity)
              .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.FirstSideRelatedToEntity_EntityActionConditions)
             .WithOne(e => e.FirstSideRelatedToEntity)
             .HasForeignKey(e => e.FirstSideRelatedToEntityId);

            builder
             .HasMany(e => e.SecondSideRelatedToEntity_EntityActionConditions)
             .WithOne(e => e.SecondSideRelatedToEntity)
             .HasForeignKey(e => e.SecondSideRelatedToEntityId);

            builder
             .HasMany(e => e.EntityActionGroups)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);

            //builder
            // .HasMany(e => e.EntityFields)
            // .WithOne(e => e.RelatedToEntity)
            // .HasForeignKey(e => e.RelatedToEntityId);

                //builder
                // .HasMany(e => e.EntityActionTypes)
                // .WithOne(e => e.Entity)
                // .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.EntityFieldActionTypes)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);
            


            builder
             .HasMany(e => e.FirstSideRelatedToEntity_EntityFieldActionConditions)
             .WithOne(e => e.FirstSideRelatedToEntity)
             .HasForeignKey(e => e.FirstSideRelatedToEntityId);

            builder
             .HasMany(e => e.SecondSideRelatedToEntity_EntityFieldActionConditions)
             .WithOne(e => e.SecondSideRelatedToEntity)
             .HasForeignKey(e => e.SecondSideRelatedToEntityId);

            builder
             .HasMany(e => e.FirstSideRelatedToEntity_EntityFieldConditions)
             .WithOne(e => e.FirstSideRelatedToEntity)
             .HasForeignKey(e => e.FirstSideRelatedToEntityId);

            builder
             .HasMany(e => e.SecondSideRelatedToEntity_EntityFieldConditions)
             .WithOne(e => e.SecondSideRelatedToEntity)
             .HasForeignKey(e => e.SecondSideRelatedToEntityId);


            builder
             .HasMany(e => e.EntityFieldGroups)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.FirstSideRelatedToEntity_EntityFieldOptionConditions)
             .WithOne(e => e.FirstSideRelatedToEntity)
             .HasForeignKey(e => e.FirstSideRelatedToEntityId);

            builder
             .HasMany(e => e.SecondSideRelatedToEntity_EntityFieldOptionConditions)
             .WithOne(e => e.SecondSideRelatedToEntity)
             .HasForeignKey(e => e.SecondSideRelatedToEntityId);

            builder
             .HasMany(e => e.Entity_EntityMaps)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.MappedEntity_EntityMaps)
             .WithOne(e => e.MappedEntity)
             .HasForeignKey(e => e.MappedEntityId);

            builder
             .HasMany(e => e.Entity_EntityRelationBreaks)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.Entity2_EntityRelationBreaks)
             .WithOne(e => e.Entity2)
             .HasForeignKey(e => e.Entity2Id);


            builder
             .HasMany(e => e.DynamicReports)
             .WithOne(e => e.Entity)
             .HasForeignKey(e => e.EntityId);

            builder
             .HasMany(e => e.EntityFieldActionTypeRequiredFields)
             .WithOne(e => e.FieldShouldRelatedToEntity)
             .HasForeignKey(e => e.FieldShouldRelatedToEntityId);
            

        }
    }
}
