using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Queries
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }


        public Dictionary<Guid, string> RolePermissions { get; set; }
        public int RolePermissionsCount { get; set; }

        //public List<CustomSelectListItem> Users { get; set; }
        //public int CountOfUsers { get; set; }
    }
}
