using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public Guid LoginTypeId { get; set; }
        public string Urlhash { get; set; }
    }
}
