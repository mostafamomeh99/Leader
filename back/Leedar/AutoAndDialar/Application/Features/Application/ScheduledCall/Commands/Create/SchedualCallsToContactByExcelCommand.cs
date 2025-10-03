using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Application.Hubs;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using Shared.Extensions;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Shared.DTOs.SMS;
using Infrastructure.Interfaces;
using Domain.Entities.Application;

namespace Application.Features.Application.ScheduledCall.Commands.Create
{
    public class SchedualCallsToContactByExcelCommand : IRequest<Response<int>>
    {
        //done n
      
        public Guid? CallTypeId { get; set; }
        public Guid CampaignId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? PriorityId { get; set; }
        public bool IsNeedToLoadInPredictiveDialer { get; set; }
        public DateTime? ScheduledCallDate { get; set; }

        public required IFormFile ExcelFile { get; set; }
    }
    public class SchedualCallsToContactByExcelCommandHandler : IRequestHandler<SchedualCallsToContactByExcelCommand, Response<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGeneralOperation _generalOperation;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IPOMService _pomService;
        private readonly INotificationHubService _hubContext;
        private readonly ISMSService _smsService;
        private DateTime startOfCurrantMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public SchedualCallsToContactByExcelCommandHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IGeneralOperation generalOperation,
            IContextCurrentUserService currentUserService,
            IPOMService pomService,
            INotificationHubService hubContext,
            ISMSService smsService)
        {
            _context = context;
            _mapper = mapper;
            _generalOperation = generalOperation;
            _currentUserService = currentUserService;
            _pomService = pomService;
            _hubContext = hubContext;
            _smsService = smsService;
        }
        class ExcelInfo
        {
            public string IdentityNumber { get; set; } = "";
            public string FullName { get; set; } = "";
            public string PhoneNumber1 { get; set; } = "";
           
           // public string Priority { get; set; }
            public int Row { get; set; }
        }
        public async Task<Response<int>> Handle(SchedualCallsToContactByExcelCommand request, CancellationToken cancellationToken)
        {
            Response<int> result = new();
            try
            {
               


                var systemProgress = new Domain.Entities.Application.SystemProgress
                {
                    Id = Guid.NewGuid(),
                    Currant = 0,
                    
                    Max = 0,
                    Title = "تحميل حملة عن طريق ملف إكسل",
                    Description = "",
                    FilePath = ""
                };
               // Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-SA");
                var selectedDate = request.ScheduledCallDate?.ToLocalTime(); ;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                var startTime = DateTime.Now;
                var fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" + request.ExcelFile.FileName;
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"UploadedFile\UploadCalls\");

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }
                var path = Path.Combine(@"UploadedFile\UploadCalls\", fileName);
                systemProgress.FilePath = path;
                List<ExcelInfo> excelInfoList = new List<ExcelInfo>();
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.ExcelFile.CopyToAsync(stream);

                    ExcelPackage package = new ExcelPackage(stream);
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                    for (int row = workSheet.Dimension.Start.Row + 1; row <= workSheet.Dimension.End.Row; row++)
                    {
                        var j = 1;
                        ExcelInfo excelInfo = new ExcelInfo();
                        excelInfo.Row = row;
                        excelInfo.IdentityNumber = _generalOperation.GetWorkSheetDataByCellAndColumn(workSheet, row, j); j++;
                        excelInfo.FullName = _generalOperation.GetWorkSheetDataByCellAndColumn(workSheet, row, j); j++;
                        excelInfo.PhoneNumber1 = _generalOperation.GetWorkSheetDataByCellAndColumn(workSheet, row, j); j++;
                       
                        excelInfoList.Add(excelInfo);
                    }
                }
                var Category = (await _context.Category.FindAsync(request.CategoryId))?.NameAr;
                var Campaign = (await _context.Campaign.FindAsync(request.CampaignId))?.NameAr;
                Domain.Entities.Lookup.Priority Priority = null;
                var MainCategory = await _context.Category.FindAsync(request.CategoryId);
                var CallsType = "";
               
                if (request.PriorityId != null)
                {
                    
                        Priority = await _context.Priority.FindAsync(request.PriorityId);
                    
                }
                if (request.CallTypeId != null)
                {
                    CallsType = (await _context.CallType.FindAsync(request.CallTypeId))?.NameAr;
                }

                systemProgress.Max = excelInfoList.Count();
                systemProgress.Description = "اسم التصنيف : " + Category + "\n" +
                    "اسم الحملة : " + Campaign + "\n" +
                    "";
                systemProgress.Type = CallsType;
                systemProgress.PriorityId = request.PriorityId;
                systemProgress.CampaignId = request.CampaignId;
                systemProgress.CategoryId = request.CategoryId;
                systemProgress.CallTypeId = request.CallTypeId;

                await _context.SystemProgress.AddAsync(systemProgress);
                await _context.SaveChangesAsync(cancellationToken);
                int added = 0;
                int notAdded = 0;
               
               
               
                bool IsUploadedSuccessfully = false;
                foreach (var item in excelInfoList)
                {

                    IsUploadedSuccessfully = false;

                    
                    //PriorityObj = null;
                   
                   

                    //if (string.IsNullOrEmpty(item.IdentityNumber) || string.IsNullOrWhiteSpace(item.IdentityNumber))
                    //{
                    //    await _context.ContactUploadingLog.AddAsync(new Domain.Entities.Log.ContactUploadingLog
                    //    {
                    //        ContactId = null,
                    //        CampaignId = request.CampaignId,
                    //        CategoryId = request.CategoryId,
                    //        IsUploadedSuccessfully = false,
                    //        FileRow = item.Row,
                    //        FileName = fileName,
                    //        Description = "لم تتم الإضافة بسبب مشكلة في رقم الهوية",
                    //        DescriptionOthers = "رقم الهوية الخاطئ : " + item.IdentityNumber,
                    //    });
                    //    systemProgress.Currant++;
                    //    _context.SystemProgress.Update(systemProgress);
                    //    await _context.SaveChangesAsync(cancellationToken);
                    //    continue;
                    //}
                    var allCallsToDelete = await _context.ScheduledCall
                        .Where(x => x.Contact!.PersonalInfo!.PhoneNumber == item.PhoneNumber1 && x.CategoryId==request.CategoryId &&
                                    (x.CallStatusId == Shared.Struct.CallStatus.NotSuccessByDialer ||
                                    x.CallStatusId == Shared.Struct.CallStatus.QueuedInSystem 
                                    )
                                    )
                        .Select(x => x.Id).ToListAsync();

                    foreach (var callIdToDelete in allCallsToDelete)
                    {
                        var callToDeleteItem = await _context.ScheduledCall.FindAsync(callIdToDelete);
                        if (callToDeleteItem != null)
                        {
                            var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(callToDeleteItem.Id.ToString(), callToDeleteItem?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                            if (isDeletedFromDialer)
                            {
                            _context.ScheduledCall.Remove(callToDeleteItem);
                            await _context.SaveChangesAsync(cancellationToken);
                            }
                        }
                    }
                    var contactObj = await _context.Contact.Where(x => x.PersonalInfo!.PhoneNumber == item.PhoneNumber1).FirstOrDefaultAsync();
                    if (contactObj != null)
                    {


                        if (contactObj.StateCode == 0)
                        {
                            await _context.ContactUploadingLog.AddAsync(new Domain.Entities.Log.ContactUploadingLog
                            {
                                SystemProgressId = systemProgress.Id,
                                ContactId = contactObj.Id,
                                CampaignId = request.CampaignId,
                                CategoryId = request.CategoryId,
                                IsUploadedSuccessfully = false,
                                FileRow = item.Row,
                                FileName = fileName,
                                Description = "لم تتم الإضافة بسبب أن المستفيد معطل في النظام",
                                DescriptionOthers = "",
                            });
                            systemProgress.Currant++;
                            _context.SystemProgress.Update(systemProgress);
                            await _context.SaveChangesAsync(cancellationToken);
                            continue;
                        }
                       
                        var goodPhoneNumber1 = _generalOperation.GetGoodPhoneNumber(item.PhoneNumber1);
                       
                                     if (goodPhoneNumber1.Length == 9)
                            {
                                contactObj.PersonalInfo!.PhoneNumber = goodPhoneNumber1;
                                contactObj.PhoneNumber= goodPhoneNumber1;
                            }
                           



                           
                            _context.Contact.Update(contactObj);
                            await _context.SaveChangesAsync(cancellationToken);
                           
                          
                       

                        if (goodPhoneNumber1.Length != 9)
                        {
                            await _context.ContactUploadingLog.AddAsync(new Domain.Entities.Log.ContactUploadingLog
                            {
                                SystemProgressId = systemProgress.Id,
                                ContactId = contactObj.Id,
                                CampaignId = request.CampaignId,
                                CategoryId = request.CategoryId,
                                IsUploadedSuccessfully = false,
                                FileRow = item.Row,
                                FileName = fileName,
                                Description = "لم تتم الإضافة بسبب أن رقم جوال المستفيد غير صحيح",
                                DescriptionOthers = "رقم الجوال المدخل : " + goodPhoneNumber1,
                            });
                            systemProgress.Currant++;
                            _context.SystemProgress.Update(systemProgress);
                            await _context.SaveChangesAsync(cancellationToken);
                            continue;
                        }


                       


                    }
                    else
                    {
                        Domain.Entities.Application.PersonalInfo personalInfo = new Domain.Entities.Application.PersonalInfo
                        {
                            IdentityNumber = item.IdentityNumber,
                            FullNameAr = item.FullName,
                          
                            PhoneNumber = item.PhoneNumber1,
                           
                        };
                        _context.PersonalInfo.Add(personalInfo);
                        await _context.SaveChangesAsync(cancellationToken);
                        contactObj = new Domain.Entities.Application.Contact
                        {
                            Id = personalInfo.Id,
                            PersonalInfoId = personalInfo.Id,
                        
                          PhoneNumber=item.PhoneNumber1
                        };
                        _context.Contact.Add(contactObj);
                        await _context.SaveChangesAsync(cancellationToken);
                    }



                  

                    var scheduledCallObj = new Domain.Entities.Application.ScheduledCall
                    {
                        ContactId = contactObj.Id,
                        CallStatusId = Shared.Struct.CallStatus.QueuedInSystem,
                        CallTypeId = request.CallTypeId,

                        //AssignToUserId
                        AssignFromUserId = Shared.Struct.StaticUser.System,
                        //AssignToUserAt
                        //ScheduledToUserId
                        ScheduledByUserId = _currentUserService.UserId ?? Shared.Struct.StaticUser.System,
                        ScheduledCallDate = selectedDate ?? DateTime.Now,
                       
                        CampaignId = request.CampaignId,
                        CategoryId = request.CategoryId,
                        PriorityId = request.PriorityId,
                        LatestHistoricalCallId = contactObj.HistoricalCalls?.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.Id,
                    };

                    

                    
                   
                    
                    await _context.ScheduledCall.AddAsync(scheduledCallObj);
                        await _context.SaveChangesAsync(cancellationToken);
                        await _context.ContactUploadingLog.AddAsync(new Domain.Entities.Log.ContactUploadingLog
                        {
                            SystemProgressId = systemProgress.Id,
                            ContactId = contactObj.Id,
                            CampaignId = request.CampaignId,
                            CategoryId = request.CategoryId,
                            IsUploadedSuccessfully = true,
                            FileRow = item.Row,
                            FileName = fileName,
                            Description = "تمت عملية الإضافة بنجاح",
                        });
                        await _context.SaveChangesAsync(cancellationToken);
                        IsUploadedSuccessfully = true;
                        added++;

                  
                    if (IsUploadedSuccessfully && request.IsNeedToLoadInPredictiveDialer==true)

                    {
                        var scheduledCall = await _context.ScheduledCall.Where(x => x.Id == scheduledCallObj.Id).FirstOrDefaultAsync();

                        var ext = "";
                     if (scheduledCall != null) {
                            var isAdded = await _pomService.SaveContactToListAsync(
                       scheduledCall.Id,
                       scheduledCall.CampaignId ?? Guid.Empty,
                       scheduledCall.CategoryId ?? Guid.Empty,
                       scheduledCall.ContactId,
                        scheduledCall.Contact?.PersonalInfo?.PhoneNumber?? "",
                        scheduledCall.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem ?? "",
                        Priority?.Number ?? 3, ext);
                            if (isAdded)
                            {
                                scheduledCall.CallStatusId = Shared.Struct.CallStatus.QueuedInDialer;
                                _context.ScheduledCall.Update(scheduledCall);
                                await _context.SaveChangesAsync(cancellationToken);
                               // await _hubContext.UpdatingOnCallsNumber(new List<string>(), null, Shared.Struct.CallStatus.QueuedInDialer, 1);
                            }
                            else
                            {
                               // await _hubContext.UpdatingOnCallsNumber(new List<string>(), null, Shared.Struct.CallStatus.QueuedInSystem, 1);
                            }
                        }
                       

                    }






                    ////if (IsUploadedSuccessfully && request.IsNeedToRemoveAllScudualedCalls == true)
                    ////{
                    ////    var allCalsToDelete = await _context.ScheduledCall.Where(x => x.ContactId == contactObj.Id && x.Id != scheduledCallObj.Id).ToListAsync();

                    ////    foreach (var CallToDelete in allCalsToDelete)
                    ////    {
                    ////        var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(CallToDelete.Id.ToString(), CallToDelete?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                    ////        if (isDeletedFromDialer)
                    ////        {
                    ////            _context.ScheduledCall.Remove(CallToDelete);
                    ////            await _context.SaveChangesAsync(cancellationToken);
                    ////        }
                    ////    }
                    ////}


                    systemProgress.Currant++;
                    _context.SystemProgress.Update(systemProgress);
                    await _context.SaveChangesAsync(cancellationToken);
                  //  await _hubContext.UpdatingSystemProgress(new List<string>(), systemProgress.Id, systemProgress.Currant);
                }
                result.Data = added;
                result.Message = new NotificationMessage
                {
                    Title = "تم الإنتهاء من عملية التحميل الملف : " + request.ExcelFile.FileName,
                    Body = "تم الإنتهاء من عملية التحميل التي بدأت بالوقت : " + startTime.ToString("yyyy/MM/dd HH:mm:ss") + "\n" +
                           "عدد السجلات المحملة بشكل صحيح : " + added + "\n" +
                           "عدد السجلات غير المحملة : " + notAdded,
                };
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                //send sms
                //var userMobil = (await _context.PersonalInfo.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync()).PhoneNumber?.TrimStart('0');

                //userMobil = "966" + userMobil;
                //SMSSendViewModel smsMessage = new SMSSendViewModel
                //{

                //// to = "558333735",
                //To = userMobil,
                //  Message = "تم الإنتهاء من عملية التحميل التي بدأت بالوقت : " + startTime.ToString("yyyy/MM/dd HH:mm:ss") + "\n" + "للملف الذي يحمل الاسم  : " + request.ExcelFile.FileName + "\n" +
                //           "عدد السجلات المحملة بشكل صحيح : " + added + "\n" +
                //           "عدد السجلات غير المحملة : " + notAdded,
                //};
                //await _smsService.SendSMS(smsMessage);
                //smsMessage.To = "966571750307";
                //await _smsService.SendSMS(smsMessage);

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
