using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.LDAB
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string LastLogin { get; set; }
        public string LastChangePassword { get; set; }
    }
}
