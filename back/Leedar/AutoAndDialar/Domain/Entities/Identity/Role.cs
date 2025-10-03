using Domain.Entities.Lookup;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public string? NameAr { get; set; }
        public bool IsDefualt { get; set; }
        public bool IsStatic { get; set; }
        public byte StateCode { get; set; }

        //public Guid RoleTypeId { get; set; }
        //public virtual RoleType? RoleType { get; set; }

        public virtual ICollection<IdentityUserRole<Guid>>? UserRole { get;}= new List<IdentityUserRole<Guid>>();
        public virtual ICollection<RolePermission>? RolePermissions { get; set; }
        public  Role()
        {

        }

        public Role([NotNull] string name, string nameAr, bool isDefualt, bool isStatic)
        {
            //Check.NotNull(name, nameof(name));

            //Id = Guid.NewGuid().AsSequentialGuid().ToString();
            Id = Guid.NewGuid();
            Name = name;
            NameAr = nameAr;
            IsDefualt = isDefualt;
            IsStatic = isStatic;
            //NormalizedName = name.ToUpperInvariant();
        }
    }
}
