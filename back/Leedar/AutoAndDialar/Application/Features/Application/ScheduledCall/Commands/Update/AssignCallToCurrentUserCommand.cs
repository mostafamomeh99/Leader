using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;
using Application.Hubs;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Application.Features.Application.ScheduledCall.Commands.Update
{
    public class AssignCallToCurrentUserCommand : IRequest<Response<bool>>
    {
        public Guid ScheduledCallId { get; set; }
        public Guid AssignFromUserId { get; set; }
        public string Extention { get; set; }
    }
    public class AssignCallToCurrentUserCommandHandler : IRequestHandler<AssignCallToCurrentUserCommand, Response<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        private readonly INotificationHubService _hubContext;
        private readonly IMailService _mailService;
        public AssignCallToCurrentUserCommandHandler(
            IApplicationDbContext context,
            IContextCurrentUserService currentUserService,
            INotificationHubService hubContext,
            IMailService mailService,
            IGeneralOperation generalOperation)
        {
            _context = context;
            _currentUserService = currentUserService;
            _hubContext = hubContext;
            _generalOperation = generalOperation;
            _mailService = mailService;
        }
        public async Task<Response<bool>> Handle(AssignCallToCurrentUserCommand request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var scheduledCallObj = await _context.ScheduledCall.Where(x => x.Id == request.ScheduledCallId).FirstOrDefaultAsync();

                var currentUser = await _context.User.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId);

                if (scheduledCallObj != null)
                {
                    var oldCallStatusId = scheduledCallObj.CallStatusId;
                    if (_currentUserService.UserId != null)
                    {
                        scheduledCallObj.AssignToUserId = _currentUserService.UserId;
                        scheduledCallObj.AssignToUserAt = DateTime.Now;
                        scheduledCallObj.CallStatusId = Shared.Struct.CallStatus.Assigned;
                        scheduledCallObj.AssignFromUserId = request.AssignFromUserId;
                       // scheduledCallObj.ScheduledToIPAddress = HelpersMethod.GetIpAddress();
                        _context.ScheduledCall.Update(scheduledCallObj);
                        await _context.SaveChangesAsync(cancellationToken);

                        var link = "ScheduledCall/" + scheduledCallObj.Id;
                        await _hubContext.OpenLink(_generalOperation.GetRealTimeID(_currentUserService.UserId.Value), link);
                        var relatedIds = _generalOperation.GetAllRelatedRealTimeID(_currentUserService.UserId.Value);
                        await _hubContext.UpdatingOnCallsNumber(relatedIds, oldCallStatusId, scheduledCallObj.CallStatusId, 1);

                        result.Succeeded = true;
                    }
                    else
                    {
                        var user = _context.User.Where(x => x.Extension == request.Extention).FirstOrDefault();
                        if (user != null)
                        {
                            scheduledCallObj.AssignToUserId = user.Id;
                            scheduledCallObj.AssignToUserAt = DateTime.Now;
                            scheduledCallObj.CallStatusId = Shared.Struct.CallStatus.Assigned;
                            scheduledCallObj.AssignFromUserId = request.AssignFromUserId;
                           // scheduledCallObj.ScheduledToIPAddress = HelpersMethod.GetIpAddress();
                            _context.ScheduledCall.Update(scheduledCallObj);
                            await _context.SaveChangesAsync(cancellationToken);

                            var link = "ScheduledCall/" + scheduledCallObj.Id;
                            var realTimeIds = _generalOperation.GetRealTimeID(user.Id);
                            var realTimeIdsLeader = _generalOperation.GetDirectLeaderRealTimeId(user.Id);
                            var allrealTimes = realTimeIds.Concat(realTimeIdsLeader).Distinct().ToList();
                            await _hubContext.OpenLink(realTimeIds, link);
                            await _hubContext.FireNotification(
                                allrealTimes,
                                $"تمت محاولة إسناد مكالمة للموظف ({scheduledCallObj?.AssignFromUser?.PersonalInfo?.FullNameAr}) لكن الموظف غير مسجل دخول في النظام",
                                "إسناد لموظف غير مسجل دخول",
                                "success",
                                5000);
                            result.Succeeded = true;
                        }
                        else
                        {
                            await _mailService.SendEmail(new Shared.DTOs.Email.EmailRequest
                            {
                                ToEmails = new List<string> { "aeinea@smartlink.com.sa", "argoma@smartlink.com.sa" },
                                Body = "<html dir='rtl'><body>" + "يرجى التأكد من العملية : <br />" +
                                       "التحويلة المرسلة : " + request.Extention + "<br />" +
                                       "معرف المكالمة المرسل : " + request.ScheduledCallId + " غير صحيح أو غير موجود <br /></body></html>",
                                Subject = "عطل في عملية الإسناد في الاتصال التنبؤي",
                            });
                            //send Email to admin
                            result.Succeeded = false;
                        }
                    }
                }
                else
                {
                    var doneHistoricalCall = await _context.HistoricalCall.FirstOrDefaultAsync(x => x.ScheduledCallId == request.ScheduledCallId);
                    await _mailService.SendEmail(new Shared.DTOs.Email.EmailRequest
                    {
                        ToEmails = new List<string> { "aeinea@smartlink.com.sa", "argoma@smartlink.com.sa" },
                        Body = "<html dir='rtl'><body>" + "يرجى التأكد من العملية : <br />" +
                                         "التحويلة المرسلة : " + request.Extention + "<br />" +
                                         "معرف المكالمة المرسل : " + request.ScheduledCallId + " غير صحيح أو غير موجود <br />" +
                                         "هوية المستفيد : " + doneHistoricalCall?.Contact?.PersonalInfo?.IdentityNumber + "<br />" +
                                         "رقم الجوال : " + doneHistoricalCall?.Contact?.PersonalInfo?.PhoneNumber + "<br />" +
                                         "الموظف الحالي : " + currentUser?.PersonalInfo?.FullNameAr + "<br />" +
                                         "التحويلة الموظف الحالي  : " + currentUser?.Extension + "<br />" +
                                         "</body></html>",
                        Subject = "عطل في عملية الإسناد في الاتصال التنبؤي",
                    });
                    result.Succeeded = false;
                    //send Email to admin problem
                }

                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "",
                    Body = "",
                };
            }
            return result;

        }
    }
}
