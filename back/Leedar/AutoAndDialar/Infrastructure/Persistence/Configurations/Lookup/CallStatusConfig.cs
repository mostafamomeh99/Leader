using Domain.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Lookup
{

    public class CallStatusConfig : IEntityTypeConfiguration<CallStatus>
    {
        public void Configure(EntityTypeBuilder<CallStatus> builder)
        {
            builder.ToTable(nameof(CallStatus), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.ScheduledCalls)
               .WithOne(e => e.CallStatus)
               .HasForeignKey(e => e.CallStatusId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasMany(e => e.HistoricalCalls)
              .WithOne(e => e.CallStatus)
              .HasForeignKey(e => e.CallStatusId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            new CallStatus
            {
                Id = Shared.Struct.CallStatus.QueuedInSystem,
                NameAr = "مجدولة الآن",
                NameEn = "Queued In System",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
             new CallStatus
             {
                 Id = Shared.Struct.CallStatus.QueuedInDialer,
                 NameAr = "مجدولة الآن (التنبؤي)",
                 NameEn = "Queued In Dialer",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new CallStatus
             {
                 Id = Shared.Struct.CallStatus.ScheduledInSystem,
                 NameAr = "مجدولة تاريخياً",
                 NameEn = "Scheduled In System",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
            new CallStatus
            {
                Id = Shared.Struct.CallStatus.ScheduledInDialer,
                NameAr = "مجدولة تاريخياً (التنبؤي)",
                NameEn = "Scheduled In Dialer",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new CallStatus
            {
                Id = Shared.Struct.CallStatus.NotSuccessByDialer,
                NameAr = "غير ناجحة (التنبؤي)",
                NameEn = "Scheduled In Dialer",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new CallStatus
            {
                Id = Shared.Struct.CallStatus.Assigned,
                NameAr = "مسندة",
                NameEn = "Assigned",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new CallStatus
            {
                Id = Shared.Struct.CallStatus.Recall,
                NameAr = "إعادة اتصال",
                NameEn = "Recall",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
                new CallStatus
                {
                    Id = Shared.Struct.CallStatus.Success,
                    NameAr = "ناجحة",
                    NameEn = "Success",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new CallStatus
                {
                    Id = Shared.Struct.CallStatus.Notsuccess,
                    NameAr = "غير ناجحة",
                    NameEn = "Not Success",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                }
            );

        }
    }
}
