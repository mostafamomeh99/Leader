using Domain.Common;
using Domain.Entities.Entity;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class SettingType : LookupEntity<Guid>
    {
        public virtual ICollection<UserSetting>? UserSettings { get; set; }
    }
}
