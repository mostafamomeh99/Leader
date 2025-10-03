using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User
{
    public class ByFilterVM
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Extension { get; set; }
        
        public List<Guid> RoleIds { get; set; }
        public List<Guid> TeamIds { get; set; }
        public List<Guid> PermissionIds { get; set; }

        public List<string> RoleNames { get; set; }
        public List<string> TeamNames { get; set; }
        public List<string> PermissionNames { get; set; }

    }
}
