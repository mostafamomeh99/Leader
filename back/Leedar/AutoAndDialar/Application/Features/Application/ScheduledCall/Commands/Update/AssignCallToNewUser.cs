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
using Shared.Extensions;
using Infrastructure.Interfaces;

namespace Application.Features.Application.ScheduledCall.Commands.Update
{
    public class AssignCallToNewUser : IRequest<Response<bool>>
    {
        public Guid CallId { get; set; }
        public Guid UserId { get; set; }
        public DateTime NewScheduledCallDate { get; set; }

    }
    public class AssignCallToNewUserHandler : IRequestHandler<AssignCallToNewUser, Response<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        private readonly INotificationHubService _hubContext;
        private readonly IMailService _mailService;
        private readonly IPOMService _pomService;

        public AssignCallToNewUserHandler(
            IApplicationDbContext context,
            IContextCurrentUserService currentUserService,
            INotificationHubService hubContext,
            IMailService mailService,
            IGeneralOperation generalOperation,
            IPOMService pomService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _hubContext = hubContext;
            _generalOperation = generalOperation;
            _mailService = mailService;
            _pomService = pomService;
        }
        public async Task<Response<bool>> Handle(AssignCallToNewUser request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var scheduledCallObj = await _context.ScheduledCall.Where(x => x.Id == request.CallId).FirstOrDefaultAsync();

                //  var currentUser = await _context.User.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId);

                if (scheduledCallObj != null)
                {
                    if(!request.UserId.IsNullOrDefault<Guid>())
                    {
                        scheduledCallObj.ScheduledToUserId = request.UserId;
                    }
                    if (!request.NewScheduledCallDate.IsNullOrDefault<DateTime>())
                    {
                        scheduledCallObj.ScheduledCallDate = request.NewScheduledCallDate.AddHours(3);
                    }





                    _context.ScheduledCall.Update(scheduledCallObj);
                    await _context.SaveChangesAsync(cancellationToken);

                    if (scheduledCallObj.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer || scheduledCallObj.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer)
                           
                    {
                        var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), scheduledCallObj?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                        if (!isDeletedFromDialer)
                        {
                            isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPredictiveOnMapCL");
                            if (!isDeletedFromDialer)
                            {
                                isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPreviewCL");
                            }
                        }

                        await _pomService.SaveContactToListAsync(
                        scheduledCallObj.Id,
                                  (Guid)scheduledCallObj.CampaignId,
                                  (Guid)scheduledCallObj.CategoryId,
                                  scheduledCallObj.ContactId,
                                  scheduledCallObj.Contact.PersonalInfo.PhoneNumber,
                                  scheduledCallObj.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL",
                                  scheduledCallObj.Priority?.Number ?? 3,
                                  scheduledCallObj.ScheduledToUser?.Extension ?? "");
                    }


                    result.Succeeded = true;




                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {

                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;

                    result.Message = new NotificationMessage
                    {
                        Title = "معرف المكالمة غير موجود",
                        Body = "معرف المكالمة غير موجود",
                    };
                }
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
