using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact), EntitySchema.Application).HasKey(x => x.Id);

            builder
            .HasMany(a => a.HistoricalCalls)
            .WithOne(b => b.Contact)
            .HasForeignKey(b => b.ContactId);

            builder
            .HasMany(a => a.ScheduledCalls)
            .WithOne(b => b.Contact)
            .HasForeignKey(b => b.ContactId);

           

            builder
            .HasMany(a => a.ContactUploadingLogs)
            .WithOne(b => b.Contact)
            .HasForeignKey(b => b.ContactId);


           
            builder
             .HasMany(e => e.Pim_contact_attempts_historys)
             .WithOne(e => e.Contact)
             .HasForeignKey(e => e.ContactId);
        }
    }
}
