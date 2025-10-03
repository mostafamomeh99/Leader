using Application.Common.Interfaces;
using Application.Hubs;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall.Commands.Create
{
    public class CustomFilter
    {
        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PriorityId { get; set; }
        public Guid? CampaignId { get; set; }
        public Guid? PreviousCallStatusId { get; set; }
        public Guid? CallStatusId { get; set; }
      
        public string? PreviousCallStatus { get; set; }

        public Guid? AssignToUserId { get; set; }
        public Guid? AssignFromUserId { get; set; }
    }
    public class DoOperationCommand : IRequest<Response<int>>
    {
        public string? OperationType { get; set; }
        public Guid CallStatusId { get; set; }
        public bool? IsCheckedAll { get; set; }
        
        public List<Guid> CustomeCallIds { get; set; }
        public CustomFilter? CustomFilter { get; set; }
        public Guid? SelectedUserId { get; set; }
        public Guid? SelectedPriority { get; set; }
        public bool IsAssignToUserByDialer { get; set; } = true;

        public class DoOperationCommandHandler : IRequestHandler<DoOperationCommand, Response<int>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IPOMService _pomService;
            private readonly INotificationHubService _hubContext;
            private readonly IContextCurrentUserService _currentUserService;
            private readonly IGeneralOperation _generalOperation;
            public DoOperationCommandHandler(IApplicationDbContext context,
                IPOMService pomService,
                INotificationHubService hubContext,
                IContextCurrentUserService currentUserService,
                IGeneralOperation generalOperation)
            {
                _context = context;
                _pomService = pomService;
                _hubContext = hubContext;
                _currentUserService = currentUserService;
                _generalOperation = generalOperation;
            }

            public async Task<Response<int>> Handle(DoOperationCommand request, CancellationToken cancellationToken)
            {
                Response<int> result = new Response<int>();
                try
                {
                    if (request.CallStatusId == Shared.Struct.CallStatus.Notsuccess || request.CallStatusId == Shared.Struct.CallStatus.Success || request.CallStatusId == Shared.Struct.CallStatus.Recall)
                    {
                        var HistoricalCalls = await _context.HistoricalCall.Where(x => request.CustomeCallIds.Contains(x.Id)).ToListAsync();

                        switch (request.OperationType)
                        {
                            case Shared.Struct.OperationTypeOnScheduledCall.AssignToPredictiveSystem:
                                {
                                    foreach (var call in HistoricalCalls)
                                    {


                                       // if (call.CallStatusId == Shared.Struct.CallStatus.Success)
                                       // {
                                      //      continue;
                                      //  }
                                        var scheduledCallObj = new Domain.Entities.Application.ScheduledCall
                                        {
                                            ContactId = call.ContactId,
                                            CallStatusId = Shared.Struct.CallStatus.QueuedInSystem,
                                            CallTypeId = call.CallTypeId,

                                            
                                            AssignFromUserId = _currentUserService.UserId ?? Shared.Struct.StaticUser.System,
                                            //AssignToUserAt
                                          
                                            ScheduledByUserId = _currentUserService.UserId ?? Shared.Struct.StaticUser.System,
                                           // ScheduledToUserAt = DateTime.Now,
                                            //ScheduledCallDate
                                            //Body
                                            //BodyHTML
                                            //ScheduledToIPAddress
                                            //ontractId = contractObj?.Id,
                                            CampaignId = call.CampaignId,
                                            CategoryId = call.CategoryId,
                                            PriorityId = Shared.Struct.Priority.Normal,
                                            LatestHistoricalCallId = call.Contact?.HistoricalCalls?.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.Id,
                                        };
                                        await _context.ScheduledCall.AddAsync(scheduledCallObj);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        var _scheduledCall = await _context.ScheduledCall.Where(x => x.Id == scheduledCallObj.Id).FirstOrDefaultAsync();
                                        if(_scheduledCall !=null)
                                        if (_scheduledCall.CallStatusId != Shared.Struct.CallStatus.QueuedInDialer && _scheduledCall.CallStatusId != Shared.Struct.CallStatus.ScheduledInDialer)
                                        {
                                            var isAdded = await _pomService.SaveContactToListAsync(
                                          _scheduledCall.Id,
                                          _scheduledCall.CampaignId ?? Guid.Empty,
                                          _scheduledCall.CategoryId ?? Guid.Empty,
                                          _scheduledCall.ContactId,
                                          _scheduledCall.Contact?.PersonalInfo?.PhoneNumber??"",
                                          _scheduledCall.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL",
                                          _scheduledCall.Priority?.Number ?? 10,
                                          ""
                                          );
                                            if (isAdded)
                                            {
                                                var oldCallStatusId = _scheduledCall.CallStatusId;
                                                if (_scheduledCall.Category?.AVAYAAURACampaignPredictive?.IsPredictive == true)
                                                {
                                                    _scheduledCall.CallStatusId = Shared.Struct.CallStatus.QueuedInDialer;
                                                    _context.ScheduledCall.Update(_scheduledCall);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                  //  await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldCallStatusId, Shared.Struct.CallStatus.QueuedInDialer, 1);
                                                }
                                                else
                                                {
                                                    _scheduledCall.CallStatusId = Shared.Struct.CallStatus.ScheduledInDialer;
                                                    _context.ScheduledCall.Update(_scheduledCall);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                  //  await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldCallStatusId, Shared.Struct.CallStatus.ScheduledInDialer, 1);
                                                }
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                                break;
                            case Shared.Struct.OperationTypeOnScheduledCall.ScheduledInSystem:
                                {
                                }
                                break;
                        }
                    }
                    else
                    {
                        var scheduledCall = _context.ScheduledCall.AsQueryable();
                        if (request.IsCheckedAll == true)
                        {
                            if (!string.IsNullOrEmpty(request.CustomFilter?.IdNumber))
                            {
                                scheduledCall = scheduledCall.Where(x => x.Contact.PersonalInfo.IdentityNumber.Contains(request.CustomFilter.IdNumber));
                            }
                            if (!string.IsNullOrEmpty(request.CustomFilter?.Name))
                            {
                                scheduledCall = scheduledCall.Where(x =>
                                                x.Contact.PersonalInfo.FullNameAr.Contains(request.CustomFilter.Name) );
                            }
                            if (!string.IsNullOrWhiteSpace(request.CustomFilter?.Mobile))
                            {
                                scheduledCall = scheduledCall.Where(x =>
                                                x.Contact.PersonalInfo.PhoneNumber.Contains(request.CustomFilter.Mobile) );
                            }
                            if (request.CustomFilter?.PreviousCallStatusId!=null)
                            {
                                scheduledCall = scheduledCall.Where(x => x.CallStatusId == (request.CustomFilter.PreviousCallStatusId));
                            }
                            if (request.CustomFilter?.CategoryId!=null)
                            {
                                scheduledCall = scheduledCall.Where(x => x.CategoryId == (request.CustomFilter.CategoryId));
                            }
                            if (request.CustomFilter?.PriorityId != null)
                            {
                                scheduledCall = scheduledCall.Where(x => x.PriorityId == (request.CustomFilter.PriorityId));
                            }
                            if (request.CustomFilter?.CampaignId != null)
                            {
                                scheduledCall = scheduledCall.Where(x => x.CampaignId == (request.CustomFilter.CampaignId));
                            }
                            if (request.CustomFilter?.CallStatusId != null)
                            {
                                scheduledCall = scheduledCall.Where(x => x.CallStatusId == request.CustomFilter.CallStatusId);
                            }
                          
                        }
                        else if (request.CustomeCallIds != null)
                        {
                            scheduledCall = _context.ScheduledCall.Where(x => request.CustomeCallIds.Contains(x.Id));
                        }
                        var IdsToDoOperation = await scheduledCall.Select(x => x.Id).ToListAsync();
                        switch (request.OperationType)
                        {
                            case Shared.Struct.OperationTypeOnScheduledCall.AssignToPredictiveSystem:
                                {
                                    for (int i = 0; i < IdsToDoOperation.Count(); i++)
                                    {
                                        var _scheduledCall = await _context.ScheduledCall.FindAsync(IdsToDoOperation[i]);

                                        if (_scheduledCall?.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer)
                                        {
                                            continue;
                                        }
                                        else if (_scheduledCall?.CallStatusId == Shared.Struct.CallStatus.ScheduledInSystem &&
                                            _scheduledCall.ScheduledCallDate > DateTime.Now)
                                        {
                                            continue;
                                        }


                                        var isAdded = await _pomService.SaveContactToListAsync(
                                        _scheduledCall.Id,
                                        _scheduledCall.CampaignId?? Guid.Empty,
                                        _scheduledCall.CategoryId ?? Guid.Empty,
                                        _scheduledCall.ContactId,
                                        _scheduledCall?.Contact?.PersonalInfo?.PhoneNumber?? "",
                                        _scheduledCall?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL",
                                        _scheduledCall?.Priority?.Number ?? 10,
                                        ""
                                        );
                                        if (isAdded)
                                        {
                                            var oldCallStatusId = _scheduledCall.CallStatusId;
                                            if (_scheduledCall.Category?.AVAYAAURACampaignPredictive?.IsPredictive == true)
                                            {
                                                _scheduledCall.CallStatusId = Shared.Struct.CallStatus.QueuedInDialer;
                                                _context.ScheduledCall.Update(_scheduledCall);
                                                await _context.SaveChangesAsync(cancellationToken);
                                             //   await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldCallStatusId, Shared.Struct.CallStatus.QueuedInDialer, 1);
                                            }
                                            else
                                            {
                                                _scheduledCall.CallStatusId = Shared.Struct.CallStatus.ScheduledInDialer;
                                                _context.ScheduledCall.Update(_scheduledCall);
                                                await _context.SaveChangesAsync(cancellationToken);
                                              //  await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldCallStatusId, Shared.Struct.CallStatus.ScheduledInDialer, 1);
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                                break;
                            case Shared.Struct.OperationTypeOnScheduledCall.ScheduledInSystem:
                                {
                                }
                                break;
                            case Shared.Struct.OperationTypeOnScheduledCall.ChangePriority:
                                {
                                    for (int i = 0; i < IdsToDoOperation.Count(); i++)
                                    {
                                        var _scheduledCall = await _context.ScheduledCall.FindAsync(IdsToDoOperation[i]);
                                        var oldStatusId = _scheduledCall.CallStatusId;
                                        if (oldStatusId == Shared.Struct.CallStatus.QueuedInDialer || oldStatusId == Shared.Struct.CallStatus.ScheduledInDialer )
                                        {
                                            var isDeletedFromDialer = true;
                                            isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(_scheduledCall.Id.ToString(), _scheduledCall.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL");
                                            if (isDeletedFromDialer)
                                            {
                                                if(oldStatusId == Shared.Struct.CallStatus.QueuedInDialer)
                                                {
                                                    _scheduledCall.CallStatusId = Shared.Struct.CallStatus.QueuedInSystem;

                                                }
                                                if (oldStatusId == Shared.Struct.CallStatus.ScheduledInDialer)
                                                {
                                                    _scheduledCall.CallStatusId = Shared.Struct.CallStatus.ScheduledInSystem;

                                                }
                                               
                                               // await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldStatusId, null, 1);
                                            }

                                        }
                                        _scheduledCall.PriorityId = request.SelectedPriority;
                                        _context.ScheduledCall.Update(_scheduledCall);
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                break;
                            case Shared.Struct.OperationTypeOnScheduledCall.DeleteCalls:
                                {
                                    for (int i = 0; i < IdsToDoOperation.Count(); i++)
                                    {
                                        var _scheduledCall = await _context.ScheduledCall.FindAsync(IdsToDoOperation[i]);
                                        var oldStatusId = _scheduledCall.CallStatusId;
                                        if (_scheduledCall != null)
                                        {
                                            var isDeletedFromDialer = true;
                                            if (_scheduledCall.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer)
                                            {
                                                isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(_scheduledCall.Id.ToString(), _scheduledCall.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPredictiveOnMapCL");
                                            }
                                            else if (_scheduledCall.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer)
                                            {
                                                isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(_scheduledCall.Id.ToString(), _scheduledCall.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "REDFPreviewCL");
                                            }
                                            if (isDeletedFromDialer)
                                            {
                                                _context.ScheduledCall.Remove(_scheduledCall);
                                                await _context.SaveChangesAsync(cancellationToken);
                                               // await _hubContext.UpdatingOnCallsNumber(new List<string>(), oldStatusId, null, 1);
                                            }
                                        }
                                    }
                                }
                                break;
                            
                            case Shared.Struct.OperationTypeOnScheduledCall.ReturnToLatestStatus:
                                break;
                            default:
                                break;
                        }

                    }

                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = true;
                }
                catch (Exception ex)
                {
                    result.Exception = ex;
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Succeeded = false;
                    result.Message = new NotificationMessage
                    {
                        Title = "عملية غير ناجحة",
                        Body = "مشكلة في العملية المطلوبة"
                    };
                }

                return result;
            }
        }
    }
}
