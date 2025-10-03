using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Queries
{
    public class CurrantUserViewModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
       
        public string? IdentityNumber { get; set; }
       
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
      
        public List<Guid>? Permissions { get; set; }
        public List<Guid>? RoleIds { get; set; }

       
        
    }
   
}
