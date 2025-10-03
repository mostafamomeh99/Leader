using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.SMS
{
    public class SMSGateway
    {
        public string Link { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderId { get; set; }
    }
}
