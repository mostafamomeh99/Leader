using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.LDAB
{
    public class UserExistedModel
    {
        public string DomainName { get; set; }
        public string DomainUserName { get; set; }
        public string DomainPassword { get; set; }
        public string UserName { get; set; }
    }
}
