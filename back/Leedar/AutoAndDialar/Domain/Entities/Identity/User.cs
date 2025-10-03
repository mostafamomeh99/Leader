using Domain.Entities.Application;
//using Domain.Entities.Log;
using Domain.Entities.Lookup;
using Microsoft.AspNetCore.Identity;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string? EmployeeNumber { get; set; }
        public bool IsStatic { get; set; } = false;
        public bool IsLoggedIn { get; set; }
        public bool IsHasSpecialPermissions { get; set; } = false;
        public DateTime? LatestLoggedInDateTime { get; set; }
        public DateTime? LatestPasswordChangedDateTime { get; set; }
        public string? PasswordHint { get; set; }
        public string? Extension { get; set; }
        public int ? WrongPassTry {  get; set; }
       

       

        public DateTime CreatedOn { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        public byte StateCode { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User? CreatedByUser { get; set; }
        [ForeignKey("LastModifiedByUserId")]
        public virtual User? LastModifiedByUser { get; set; }

        
       

        public Guid PersonalInfoId { get; set; }
        public virtual PersonalInfo? PersonalInfo { get; set; }

        public Guid? DirectLeaderId { get; set; }
        public virtual User? DirectLeader { get; set; }


        public virtual ICollection<UserPermission>? UserPermissions { get; set; }
        
        public virtual ICollection<UserSetting>? UserSettings { get; set; }

        public virtual ICollection<UserTeams> UserTeams { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>>? Roles { get; } = new List<IdentityUserRole<Guid>>();


        public virtual ICollection<UserRealTime>? UserRealTimes { get; set; }



       

        public User()
        {
        }

        public User(
            Guid? id,
            [NotNull] string userName,
           
            string extension,
            string email,
            Guid createdById,
            Guid? leaderId,
            bool isStatic = false)
        {

            Id = id ?? Guid.NewGuid().AsSequentialGuid();
            UserName = userName.ToLower();
            NormalizedUserName = userName.ToUpperInvariant();

            SecurityStamp = Guid.NewGuid().ToString();
           DirectLeaderId = leaderId;
            Extension = extension;
            IsLoggedIn = false;
            EmailConfirmed = true;
            PhoneNumberConfirmed = true;
            Email = email;
            CreatedByUserId = createdById;
            PersonalInfoId = id.Value;
            StateCode = 1;
            IsLoggedIn = false;
            CreatedOn = DateTime.Now;
            IsStatic = isStatic;
        }
    }
}
