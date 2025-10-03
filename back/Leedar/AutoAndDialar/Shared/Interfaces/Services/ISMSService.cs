using Shared.DTOs.Email;
using Shared.DTOs.LDAB;
using Shared.DTOs.SMS;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Services
{
    public interface ISMSService
    {
        Task<string> SendSMS(SMSSendViewModel mdoel);
    }
}
