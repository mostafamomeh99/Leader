using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Shared.DTOs.SMS
{
    public class SMSSendViewModel
    {
        public string To { get; set; }
        public string Message { get; set; }

       
    }
}
