using Application.Common.Interfaces;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs.SMS;
using Shared.Helpers;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Commands.Update
{
    public class SendOtpForChangePassword : IRequest<Response<string>>
    {
        public string PhoneNumber { get; set; }
    }
    public class SendOtpForChangePasswordHandler : IRequestHandler<SendOtpForChangePassword, Response<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISMSService _smsService;

        public SendOtpForChangePasswordHandler(
            IApplicationDbContext context,
            ISMSService smsService)
        {
            _context = context;
            _smsService = smsService;
        }
        public async Task<Response<string>> Handle(SendOtpForChangePassword request, CancellationToken cancellationToken)
        {
            Response<string> result = new();
            try
            {
                var userMobile = request.PhoneNumber.TrimStart('0');
                userMobile = "966" + userMobile; 
                string otp = (BetterRandom.NextInt() % 1000000).ToString("000000");

                SMSSendViewModel SmsMessage = new SMSSendViewModel
                {

                     To = "966558333735",
                  //  To = userMobile,
                    Message = "رمز التحقق : " + "\n"  + otp 
                };
                await _smsService.SendSMS(SmsMessage);
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Data = otp;
                return result;

            }
            catch (Exception ex)
            {
                return new Response<string> { Data = "0", HttpStatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }
    }
}
