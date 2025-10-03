using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Extensions;
using Application.Features.Application.Avaya;
using AutoMapper;
using Domain.Entities.Log;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Shared.Extensions;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall.Queries
{
    public class GetPIMContactAttemptsHistory : IRequest<Response<PagedResponse<POMCallResultViewModel>>>
    {
       
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public DateRangViewModel? SelectedDateRange { get; set; }
        public string? ContactIdentityNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
       
        public List<Guid>? UserIds { get; set; }
      
        public string? CallStatus { get; set; }

        
    }
    public class GetPIMContactAttemptsHistoryHandler : IRequestHandler<GetPIMContactAttemptsHistory, Response<PagedResponse<POMCallResultViewModel>>>
    {
        private readonly IApplicationDbContext _context;
     
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        
        public GetPIMContactAttemptsHistoryHandler(
            IApplicationDbContext context,

            IContextCurrentUserService currentUserService,
            IGeneralOperation generalOperation
           )
        {
            _context = context;
           
            _currentUserService = currentUserService;
            _generalOperation = generalOperation;
           
        }
        public async Task<Response<PagedResponse<POMCallResultViewModel>>> Handle(GetPIMContactAttemptsHistory request, CancellationToken cancellationToken)
        {
            //new
           
            Response<PagedResponse<POMCallResultViewModel>> result = new();
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateStart !=null)
                {
                    var requestDateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 0, 0, 0);
                }
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateEnd!=null)
                {
                    var requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
                    if (request.SelectedDateRange.dateEnd == request.SelectedDateRange.dateStart)
                    {
                        requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(2);
                    }

                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 0, 0, 0);
                }


                #region filters
                List<Expression<Func<Pim_contact_attempts_historyLog, bool>>> filters = new();
                IOrderedQueryable<Pim_contact_attempts_historyLog> orderBy(IQueryable<Pim_contact_attempts_historyLog> x) => x.OrderByDescending(x => x.Call_start_time);
                filters.Add(x => x.Contact_attempt_time >= startDate && x.Contact_attempt_time <= endDate);
               

                if (!string.IsNullOrEmpty(request.ContactIdentityNumber))
                {
                    
                    filters.Add(x => x.Contact.IdentityNumber.Contains(request.ContactIdentityNumber));
                }
                if (!string.IsNullOrEmpty(request.ContactName))
                {
                    filters.Add(x => x.Contact.FullName.Contains(request.ContactName) );
                }
                if (!string.IsNullOrWhiteSpace(request.ContactPhone))
                {
                    filters.Add(x => x.Contact.PhoneNumber.Contains(request.ContactPhone));
                }
                if (!string.IsNullOrEmpty(request.CallStatus))
                {
                    if (request.CallStatus == "ناجحة")
                    { filters.Add(x => x.IsSuccess == true); }
                    else { filters.Add(x => x.IsSuccess == false); }
                }
                if (request.CategoryId !=null)
                {
                    filters.Add(x => x.CategoryId == (request.CategoryId));
                }
                if (request.CampaignId != null)
                {
                    filters.Add(x => x.CampaignId == (request.CampaignId));
                }


                #endregion
                //  DateTime ChangingTime = new DateTime(DateTime.Now.Year, 10, 29, 2, 0, 0);
                DateTime ChangingTime = new DateTime(DateTime.Now.Year, 11, 03, 2, 0, 0);
                var extra = 7;

                var Pim_contact_attempts_historyLog = _context.Pim_contact_attempts_historyLog.AsQueryable();
                var pagedResponse = new PagedResponse<Pim_contact_attempts_historyLog>();
                if (request.PageIndex != null && request.PageSize !=null)
                {
                    pagedResponse = await Pim_contact_attempts_historyLog
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await Pim_contact_attempts_historyLog
                         .GetAllOnDynamicFilter(filters, orderBy);
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                result.Data = new PagedResponse<POMCallResultViewModel>
                {
                    Items = new List<POMCallResultViewModel>(),
                    PageIndex = pagedResponse.PageIndex,
                    PageItemsEnd = pagedResponse.PageItemsEnd,
                    PageItemsStart = pagedResponse.PageItemsStart,
                    PageSize = pagedResponse.PageSize,
                    Succeeded = true,
                    TotalItems = pagedResponse.TotalItems,
                    TotalPages = pagedResponse.TotalPages,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                };
                foreach (var item in pagedResponse.Items)
                {
                    if (item.Contact_attempt_time >= ChangingTime) { extra = 8; }
                    var PomCallResultObject = new POMCallResultViewModel
                    {
                        Id = item.Id,
                        ContactId = item.ContactId,
                        IdentityNumber = (item.Contact != null) ? item.Contact.IdentityNumber : "",
                        BeneficiryName = (item.Contact != null) ? item.Contact.FullName : "",
                        PhoneNumber = (item.Contact != null) ? item.Contact.PhoneNumber : "",
                        AgentName = (item.User != null) ? item.User?.PersonalInfo?.FullNameAr : "",
                        CallStatus = (item.Completion_Code_Name == "Default_code" || item.Completion_Code_Name == "Answer_Human" || item.Completion_Code_Name == "Call_Answered") ? "ناجحة" : "غير ناجحة",
                        //GetResultNameByPIMCode(x.Completion_code_Name),

                        Contact_attempt_timeString = (item.Contact_attempt_time != null) ? (item.Contact_attempt_time)?.AddHours(extra).ToString() : "",
                        Contact_attempt_time = (item.Contact_attempt_time)?.AddHours(extra) ,
                        Last_nw_disposition_timeString = (item.Last_nw_disposition_time != null) ? item.Last_nw_disposition_time?.AddHours(extra).ToString() : "",
                        Call_start_timeString = (item.Contact_attempt_time != null) ? item.Contact_attempt_time?.AddHours(extra).ToString() : "",
                        Call_completion_timeString = (item.Call_completion_time != null) ? item.Call_completion_time?.AddHours(extra).ToString() : "",
                        CategoryName = (item.CategoryId != null) ? item.Category?.NameAr : "",
                        CampaignName = (item.CampaignId != null) ? item.Campaign?.NameAr : "",
                        CallCompletionCode = item.Completion_Code_id.ToString(),
                        CallCompletionName = _generalOperation.GetArabicCompletationCode(item.Completion_Code_Name),


                    };
                    result.Data.Items.Add(PomCallResultObject);
                }

                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;

                //end

            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "",
                    Body = ""
                };
            }
            return result;
        }


       

    }

}
