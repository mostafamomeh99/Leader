using Domain.Entities.Application;
using Domain.Entities.Identity;
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
    public class PersonalInfoConfig : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.ToTable(nameof(PersonalInfo), EntitySchema.Application).HasKey(x => x.Id);
           

            builder.HasData(
                  new PersonalInfo
                  {
                      Id = Shared.Struct.StaticUser.System,
                      Email = "System@System",
                    
                      FullNameAr = "النظام",
                    
                      StateCode = 1,
                      CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                  },
                  new PersonalInfo
                  {
                      Id = Shared.Struct.StaticUser.POMApplicationUser,
                      Email = "POMApplicationUser@System",
                    
                      FullNameAr = "نظام الاتصال التنبؤي",
                     
                      StateCode = 1,
                      CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                  }
                  );
            
            builder
            .HasOne(a => a.Contact)
            .WithOne(b => b.PersonalInfo)
            .HasForeignKey<Contact>(x => x.Id);

            builder
           .HasOne(a => a.User)
           .WithOne(b => b.PersonalInfo)
           .HasForeignKey<User>(x => x.Id);

          
            
        }
    }
}
