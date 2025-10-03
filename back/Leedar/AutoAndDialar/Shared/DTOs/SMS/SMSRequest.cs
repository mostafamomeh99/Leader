using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.SMS
{
    public class SMSRequest
    {
        public string Number { get; set; }
        public string Body { get; set; }
    }
}
