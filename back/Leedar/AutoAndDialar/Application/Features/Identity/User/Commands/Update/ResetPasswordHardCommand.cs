using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Commands.Update
{
    using Infrastructure.Interfaces;
    using Domain.Entities.Identity;
    using Localization;
    using Shared.Globalization;

    public class ResetPasswordHardCommand : IRequest<Response<string>>
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public class ResetPasswordHardCommandHandler : IRequestHandler<ResetPasswordHardCommand, Response<string>>
        {
            private readonly IApplicationDbContext _context;
            private readonly UserManager<User> _userManager;
            public ResetPasswordHardCommandHandler(IApplicationDbContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }
            public async Task<Response<string>> Handle(ResetPasswordHardCommand request, CancellationToken cancellationToken)
            {
                Response<string> result = new();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = false;
                try
                {
                    var dbUser = await _userManager.FindByIdAsync(request.UserId.ToString());
                    if (dbUser != null)
                    {
                        var removeOldPasswordresult = await _userManager.RemovePasswordAsync(dbUser);
                        if (removeOldPasswordresult != null && removeOldPasswordresult.Succeeded)
                        {
                            var AddNewPasswordresult = await _userManager.AddPasswordAsync(dbUser, request.NewPassword);
                            if (AddNewPasswordresult != null && AddNewPasswordresult.Succeeded)
                            {
                                result.Succeeded = true;
                                result.Message = new NotificationMessage
                                {
                                    Title = SharedResource.SuccessOperation,
                                    Body = SharedResource.PasswordResetSuccesMessage
                                };
                            }
                            else
                            {
                                result.Succeeded = false;
                                result.Message = new NotificationMessage
                                {
                                    Title = SharedResource.FailedOperation,
                                    Body = "حدث خطأ أثناء إضافة كلمة المرور الجديدة"
                                };

                            }
                        }
                        else
                        {
                            result.Succeeded = false;
                            result.Message = new NotificationMessage
                            {
                                Title = SharedResource.FailedOperation,
                                Body = "حدث خطأ أثناء حذف كلمة المرور القديمة"
                            };
                        }
                    }
                    else
                    {
                        result.Succeeded = false;
                        result.Message = new NotificationMessage
                        {
                            Title = SharedResource.FailedOperation,
                            Body = "لم يتم العثور على المستخدم"
                        };
                    }


                    //TODO : send emailNotification .
                }
                catch (Exception ex)
                {
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Exception = ex;
                    result.Message = new NotificationMessage
                    {
                        Title = SharedResource.FailedOperation,
                        Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.ResetPassword}" :
                         $"{SharedResource.Failed} {SharedResource.To} {SharedResource.ResetPassword}",
                    };
                }
                return result;
            }
        }
    }
}
