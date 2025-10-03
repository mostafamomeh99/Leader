using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class UserSetting : AuditableEntityNoID
    {
        public Guid UserId { get; set; }
        public Guid SettingTypeId { get; set; }

        public virtual required User User { get; set; }
        public virtual SettingType SettingType { get; set; }
        public string? Value { get; set; }
    }
}
