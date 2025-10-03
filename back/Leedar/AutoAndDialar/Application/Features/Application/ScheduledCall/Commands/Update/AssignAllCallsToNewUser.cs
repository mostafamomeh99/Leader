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
    public class AssignAllCallsToNewUser : IRequest<Response<bool>>
    {
        public List<Guid> CallIds { get; set; }
        public Guid UserId { get; set; }

    }
    public class AssignAllCallsToNewUserHandler : IRequestHandler<AssignAllCallsToNewUser, Response<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        private readonly INotificationHubService _hubContext;
        private readonly IMailService _mailService;
        private readonly IPOMService _pomService;
        public AssignAllCallsToNewUserHandler(
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
        public async Task<Response<bool>> Handle(AssignAllCallsToNewUser request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var scheduledCallObj = await _context.ScheduledCall.Where(x =>  request.CallIds.Contains(x.Id)).ToListAsync();

                //  var currentUser = await _context.User.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId);

                if (scheduledCallObj != null)
                {
                    foreach(var call in scheduledCallObj)
                    {
                        call.ScheduledToUserId = request.UserId;


                        _context.ScheduledCall.Update(call);
                        await _context.SaveChangesAsync(cancellationToken);


                        if (call.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer || call.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer)

                        {
                            var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(call.Id.ToString(), call?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                            if (!isDeletedFromDialer)
                            {
                                isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(call.Id.ToString(), "REDFPredictiveOnMapCL");
                                if (!isDeletedFromDialer)
                                {
                                    isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(call.Id.ToString(), "REDFPreviewCL");
                                }
                            }

                            await _pomService.SaveContactToListAsync(
                            call.Id,
                                      (Guid)call.CampaignId,
                                      (Guid)call.CategoryId,
                                      call.ContactId,
                                      call.Contact.PersonalInfo.PhoneNumber,
                                      call.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL",
                                      call.Priority?.Number ?? 3,
                                      call.ScheduledToUser?.Extension ?? "");
                        }
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
