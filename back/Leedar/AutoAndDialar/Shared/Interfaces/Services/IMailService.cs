//using Shared.DTOs.Email;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shared.Interfaces.Services
//{
//    public interface IMailService
//    {
//        Task<string> SendEmail(EmailRequest mdoel);
//        Task<Response<bool>> SendEmail(EmailRequest mdoel, EmailGateway emailGateway);
//    }
//}
using Shared.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Services
{
    public interface IMailService
    {
        Task<string> SendEmail(EmailRequest mdoel);
    }
}
