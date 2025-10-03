using Application.Common.Interfaces;
using AutoMapper;
using Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Application.Contact.Commands;

namespace Application.Features.Application.HistoricalCall.Commands.Create
{
    using Domain.Entities.Application;
    using Domain.Entities.Log;
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;
   
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
    using Shared.Extensions;
    using System.Globalization;

    public class SubmitCallResultCommand : IRequest<Response<string>>
    {
        public string ScheduledCallId { get; set; }
        public Dictionary<Guid, string> Result { get; set; }
        public List<Common.Models.PathEventGroupViewModel> EventsGroup { get; set; }

        public EditContactCommand ContactDetails { get; set; }
    }
    public class SubmitCallResultCommandHandler : IRequestHandler<SubmitCallResultCommand, Response<string>>
    {
        //private DateTime dateTimeNow = DateTime.Now;
        HistoricalCall newHistoricalCall;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        private readonly INotificationHubService _hubContext;
    //    private readonly IREDFWS _redfWS;
        private readonly IPOMService _pomService;

        public SubmitCallResultCommandHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IContextCurrentUserService currentUserService,
            IGeneralOperation generalOperation,
            INotificationHubService hubContext,
           // IREDFWS redfWS,
            IPOMService pOMService
            )
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _generalOperation = generalOperation;
            _hubContext = hubContext;
         //   _redfWS = redfWS;
            _pomService = pOMService;
            newHistoricalCall = new HistoricalCall();
        }
        public async Task<Response<string>> Handle(SubmitCallResultCommand request, CancellationToken cancellationToken)
        {
            Response<string> result = new();
            try
            {
                var scheduledCallObj = _context.ScheduledCall.FirstOrDefault(x => x.Id == Guid.Parse(request.ScheduledCallId));
               
           
                var entitytOfCategoryPath = await _context.Entity.FirstOrDefaultAsync(x =>
                  x.EntityTypeId == Shared.Struct.Entities.Lookup.CategoryPath &&
                  x.RelatedEntityPK == scheduledCallObj.Category.CategoryPathId);
              

                if (scheduledCallObj != null)
                {
                    var contactObj = await _context.Contact.FirstOrDefaultAsync(x => x.Id == scheduledCallObj.ContactId);

                    if (_currentUserService.UserId == scheduledCallObj.AssignToUserId)
                    {
                        var allHistoricalCallIdsToUpdate = _context.HistoricalCall.Where(x => x.ContactId == scheduledCallObj.ContactId)
                            .OrderByDescending(x => x.CreatedOn).Select(x => x.Id).ToList();
                        var latestHistoricalCall = allHistoricalCallIdsToUpdate.FirstOrDefault();

                        if (latestHistoricalCall != Guid.Empty)
                        {
                            newHistoricalCall.LatestHistoricalCallId = latestHistoricalCall;
                        }

                        ////var latestHistoricalCall = Guid.Empty;
                        //foreach (var item in allHistoricalCallIdsToUpdate)
                        //{
                        //    var historicalCallObj = _context.HistoricalCall.Where(x => x.Id == item)
                        //    .Include(x => x.Contact)
                        //    .Include(x => x.AssignToUser)
                        //    .Include(x => x.CallStatus)
                        //    .Include(x => x.Campaign)
                        //    .Include(x => x.CallBill)
                        //    .Include(x => x.Category)
                        //    .FirstOrDefault();
                        //    historicalCallObj.IsLatestCall = false;
                        //    _context.HistoricalCall.Update(historicalCallObj);
                        //  //  await _context.SaveChangesAsync(cancellationToken);
                        //}



                        //if (allHistoricalCallIdsToUpdate.Any())
                        //{
                        //    await _context.SaveChangesAsync(cancellationToken);
                        //}
                        //var newHistoricalCall = new Domain.Entities.Application.HistoricalCall();
                        newHistoricalCall.Id = Guid.NewGuid();
                        newHistoricalCall.ContactId = scheduledCallObj.ContactId;
                        newHistoricalCall.CallTypeId = scheduledCallObj.CallTypeId;
                        newHistoricalCall.AssignToUserId = scheduledCallObj.AssignToUserId;
                        newHistoricalCall.AssignFromUserId = scheduledCallObj.AssignFromUserId;
                        newHistoricalCall.AssignToUserAt = scheduledCallObj.AssignToUserAt;
                        newHistoricalCall.ScheduledToUserId = scheduledCallObj.ScheduledToUserId;
                        newHistoricalCall.ScheduledByUserId = scheduledCallObj.ScheduledByUserId;
                        newHistoricalCall.ScheduledToUserAt = scheduledCallObj.ScheduledToUserAt;
                        newHistoricalCall.ScheduledCallDate = scheduledCallObj.ScheduledCallDate;
                       

                        newHistoricalCall.CampaignId = scheduledCallObj.CampaignId;
                        newHistoricalCall.CategoryId = scheduledCallObj.CategoryId;
                        newHistoricalCall.CallStatusId = scheduledCallObj.CallStatusId;
                        newHistoricalCall.IsLatestCall = true;
                        newHistoricalCall.PriorityId = scheduledCallObj.PriorityId;




                      
                        newHistoricalCall.ScheduledCallId = Guid.Parse(request.ScheduledCallId);
                        newHistoricalCall.CallDate = DateTime.Now;
                      


                     

                            _context.HistoricalCall.Add(newHistoricalCall);
                            await _context.SaveChangesAsync(cancellationToken);
                       

                        var allEventgroupOnSubmit = request.EventsGroup.Where(x => x.ExecuteTrigger.Any(x => x.Key == Shared.Struct.TriggerType.OnSubmit));
                        foreach (var eventGroup in allEventgroupOnSubmit.OrderBy(x => x.ProcessOrder))
                        {
                            var eventGroupIsCanExicuted = false;

                            foreach (var conditionGroup in eventGroup.ExecuteIfCondetionGroup)
                            {
                                var conditionGroupResult = true;
                                foreach (var condition in conditionGroup.Conditions)
                                {
                                    var field = request.Result.Where(x => x.Key == condition.FieldId).FirstOrDefault();
                                    bool conditionResult = true;
                                    if (request.Result.ContainsKey(condition.FieldId))
                                    {
                                        conditionResult = _generalOperation.CalculateCondition(field.Value, condition.Value, condition.ConditionTypeId);
                                        if (condition.AndorOr == null)
                                            conditionGroupResult = conditionResult;
                                        else if (condition.AndorOr == true)
                                            conditionGroupResult = conditionGroupResult && conditionResult;
                                        else if (condition.AndorOr == false)
                                            conditionGroupResult = conditionGroupResult || conditionResult;
                                    }
                                    else
                                    {
                                        conditionResult = false;
                                    }
                                }
                                if (conditionGroup.AndorOr == null)
                                    eventGroupIsCanExicuted = conditionGroupResult;
                                else if (conditionGroup.AndorOr == true)
                                    eventGroupIsCanExicuted = eventGroupIsCanExicuted && conditionGroupResult;
                                else if (conditionGroup.AndorOr == false)
                                    eventGroupIsCanExicuted = eventGroupIsCanExicuted || conditionGroupResult;
                            }
                            if (eventGroupIsCanExicuted)
                            {
                                foreach (var eventItem in eventGroup.Events.OrderBy(x => x.ProcessOrder))
                                {
                                    if (eventItem.ActionTypeId == Shared.Struct.EntityActionType.SaveCallInSuccessStatus)
                                    {
                                        newHistoricalCall.CallStatusId = Shared.Struct.CallStatus.Success;
                                        _context.HistoricalCall.Update(newHistoricalCall);
                                        await _context.SaveChangesAsync(cancellationToken);

                                        //if (newHistoricalCall.AssignToUserId != null)
                                        //{
                                        //    var relatedIds = _generalOperation.GetAllRelatedRealTimeID(newHistoricalCall.AssignToUserId.Value);
                                        //   // await _hubContext.UpdatingOnCallsNumberToday(relatedIds, "SuccessCall", 1);
                                        //   // await _hubContext.UpdatingOnCallsNumber(relatedIds, scheduledCallObj.CallStatusId, null, 1);
                                        //}
                                    }
                                    else if (eventItem.ActionTypeId == Shared.Struct.EntityActionType.SaveCallInNotSuccessStatus)
                                    {
                                        newHistoricalCall.CallStatusId = Shared.Struct.CallStatus.Notsuccess;
                                        _context.HistoricalCall.Update(newHistoricalCall);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        //if (newHistoricalCall.AssignToUserId != null)
                                        //{
                                        //    var relatedIds = _generalOperation.GetAllRelatedRealTimeID(newHistoricalCall.AssignToUserId.Value);
                                        //    await _hubContext.UpdatingOnCallsNumberToday(relatedIds, "NotSuccessCall", 1);
                                        //    await _hubContext.UpdatingOnCallsNumber(relatedIds, scheduledCallObj.CallStatusId, null, 1);
                                        //}

                                    }
                                    else if (eventItem.ActionTypeId == Shared.Struct.EntityActionType.SaveCallInRecallStatus)
                                    {
                                        newHistoricalCall.CallStatusId = Shared.Struct.CallStatus.Recall;
                                        _context.HistoricalCall.Update(newHistoricalCall);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        //if (newHistoricalCall.AssignToUserId != null)
                                        //{
                                        //    var relatedIds = _generalOperation.GetAllRelatedRealTimeID(newHistoricalCall.AssignToUserId.Value);
                                        //    await _hubContext.UpdatingOnCallsNumberToday(relatedIds, "ReCall", 1);
                                        //    await _hubContext.UpdatingOnCallsNumber(relatedIds, scheduledCallObj.CallStatusId, null, 1);
                                        //}

                                    }
                                  
                                    else if (eventItem.ActionTypeId == Shared.Struct.EntityActionType.SaveCallInNewSubStatus)
                                    {
                                        var SubStatusFieldParameterId = Guid.Parse("93b2758b-1de0-441a-8896-336ba1b4681c");
                                        try
                                        {
                                            var subStatusfieldId = eventItem.Parameters.Where(x => x.ParameterId == SubStatusFieldParameterId).FirstOrDefault().CategoryPathFieldId;
                                            if (subStatusfieldId != null)
                                            {
                                                var subStatusValueString = request.Result[subStatusfieldId.Value];
                                                if (subStatusValueString != null)
                                                {
                                                    var subStatusValue = Guid.Parse(subStatusValueString);
                                                    var subStatusId = _context.EntityFieldOption.Where(x => x.Id == subStatusValue).Select(x => x.RelatedEntityOptionId).FirstOrDefault();

                                                    newHistoricalCall.SubCallStatusId = subStatusId;
                                                    _context.HistoricalCall.Update(newHistoricalCall);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                }
                                               
                                                
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                            }
                        }


                       
                        foreach (var resultItem in request.Result)
                        {
                            var type = _context.EntityField.Where(x=>x.Id == resultItem.Key).Select(x=>x.FieldTypeId).FirstOrDefault();
                            if (type == Shared.Struct.FieldType.DateTime || type == Shared.Struct.FieldType.SDateTime)
                            {
                                if (resultItem.Value != null)
                                {
                                    var date = DateTime.Parse(resultItem.Value);
                                    await _context.HistoricalCallPathResult.AddAsync(new Domain.Entities.Application.HistoricalCallPathResult
                                    {
                                        Id = Guid.NewGuid(),
                                        EntityFieldId = resultItem.Key,
                                        Value = date.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-GB")),
                                        HistoricalCallId = newHistoricalCall.Id,
                                        ValueString = date.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-GB")),
                                    });
                                }
                                else
                                {
                                    await _context.HistoricalCallPathResult.AddAsync(new Domain.Entities.Application.HistoricalCallPathResult
                                    {
                                        Id = Guid.NewGuid(),
                                        EntityFieldId = resultItem.Key,
                                        Value = resultItem.Value,
                                        HistoricalCallId = newHistoricalCall.Id
                                    });
                                }
                            }
                            else if (type == Shared.Struct.FieldType.CheckBox || type == Shared.Struct.FieldType.OneSelect || type == Shared.Struct.FieldType.RadioButton)
                            {
                                if (resultItem.Value != null)
                                {
                                    var optionValue = _generalOperation.GetStringValueForGuidOption(resultItem.Key, resultItem.Value);
                                    await _context.HistoricalCallPathResult.AddAsync(new Domain.Entities.Application.HistoricalCallPathResult
                                    {
                                        Id = Guid.NewGuid(),
                                        EntityFieldId = resultItem.Key,
                                        Value = resultItem.Value,
                                        HistoricalCallId = newHistoricalCall.Id,
                                        ValueString = optionValue.ToString()
                                    });
                                }
                                else
                                {
                                    await _context.HistoricalCallPathResult.AddAsync(new Domain.Entities.Application.HistoricalCallPathResult
                                    {
                                        Id = Guid.NewGuid(),
                                        EntityFieldId = resultItem.Key,
                                        Value = resultItem.Value,
                                        HistoricalCallId = newHistoricalCall.Id,
                                        ValueString = ""
                                    });
                                }
                            }
                            else
                            {
                                await _context.HistoricalCallPathResult.AddAsync(new Domain.Entities.Application.HistoricalCallPathResult
                                {
                                    Id = Guid.NewGuid(),
                                    EntityFieldId = resultItem.Key,
                                    Value = resultItem.Value,
                                    HistoricalCallId = newHistoricalCall.Id
                                });
                            }
                            
                            await _context.SaveChangesAsync(cancellationToken);
                        }

                        // Delete Call From Dialer ContactList
                        var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), scheduledCallObj?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                        if (!isDeletedFromDialer)
                        {
                            isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPredictiveOnMapCL");
                            if (!isDeletedFromDialer)
                            {
                                isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPreviewCL");
                            }
                        }

                        _context.ScheduledCall.Remove(scheduledCallObj);
                        await _context.SaveChangesAsync(cancellationToken);

                        //remove all schedule off call center
                        var callcenterCategoryId = Guid.Parse("14843860-4C0B-4D42-A637-B13E00FB66A8");
                        if (newHistoricalCall.CategoryId == callcenterCategoryId)
                        {
                            var allScheduled = await _context.ScheduledCall.Where(x => x.CategoryId == callcenterCategoryId && x.ContactId == newHistoricalCall.ContactId).ToListAsync();
                            if (allScheduled.Any())
                            {
                                foreach (var item in allScheduled)
                                {
                                    _context.ScheduledCall.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }
                        }
                        // Send Call Result To REDF 
                      
                               

                        bool isThereAnyUpdate = false;
                        if (contactObj.PersonalInfo.FullNameAr != request.ContactDetails.FullNameAr)
                        {
                            contactObj.PersonalInfo.FullNameAr = request.ContactDetails.FullNameAr;
                            isThereAnyUpdate = true;
                        }
                        if (contactObj.PersonalInfo.IdentityNumber != request.ContactDetails.IdentityNumber)
                        {
                            contactObj.PersonalInfo.IdentityNumber = request.ContactDetails.IdentityNumber;
                            isThereAnyUpdate = true;
                        }
                        if (contactObj.PersonalInfo.PhoneNumber != request.ContactDetails.PhoneNumber)
                        {
                            contactObj.PersonalInfo.PhoneNumber = request.ContactDetails.PhoneNumber;
                            isThereAnyUpdate = true;
                        }
                      

                        if (isThereAnyUpdate)
                        {
                            _context.PersonalInfo.Update(contactObj.PersonalInfo);
                            await _context.SaveChangesAsync(cancellationToken);


                          
                        }


                        result.Succeeded = true;
                        result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        result.Message = new NotificationMessage
                        {
                            Title = SharedResource.SuccessOperation,
                            Body = "تم إرسال نتيجة المكالمة بنجاح",
                        };
                    }
                    else
                    {
                        result.Succeeded = false;
                        result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        result.Message = new NotificationMessage
                        {
                            Title = SharedResource.FieldOptions,
                            Body = "عذراً المكالمة غير مسندة لك في النظام ، لا يمكنك إرسال النتيجة ",
                        };
                    }
                }
                else
                {
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Message = new NotificationMessage
                    {
                        Title = SharedResource.FieldOptions,
                        Body = "عذراً المكالمة المجدولة غير موجودة في النظام أو قد تم إرسال النتيجة مسبقاً",
                    };
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "يوجد مشكلة أثناء إرسال الاستبيان",
                    Body = "exception : " + ex.Message,
                };
            }
            return result;
        }
    }
}
