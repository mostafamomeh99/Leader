namespace Application.Features.Application.HistoricalCall.Queries
{
    using Domain.Entities.Application;
    using global::Application.Common.Interfaces;
    using global::Application.Common.Models;
    using global::Application.Extensions;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.ViewModels;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetByFilter : IRequest<Response<PagedResponse<HistoricalCallVM>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? CallStatusId { get; set; }
        public DateRangViewModel? SelectedDateRange { get; set; }

        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
        public Guid AssignToUserId { get; set; }
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<HistoricalCallVM>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGeneralOperation _generalOperation;
        public GetByFilterHandler(IApplicationDbContext context, IGeneralOperation generalOperation)
        {
            _context = context;
            _generalOperation = generalOperation;
        }
        public async Task<Response<PagedResponse<HistoricalCallVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<HistoricalCallVM>> result = new();
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateStart !=null)
                {
                    var requestDateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
                }
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateEnd !=null)
                {
                    var requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
                    if (request.SelectedDateRange.dateEnd == request.SelectedDateRange.dateStart)
                    {
                        requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(2);
                    }

                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
                }


                #region filters
                List<Expression<Func<HistoricalCall, bool>>> filters = new();
                IOrderedQueryable<HistoricalCall> orderBy(IQueryable<HistoricalCall> x) => x.OrderByDescending(x => x.CallDate);
                filters.Add(x => x.CallDate >= startDate && x.CallDate <= endDate);


                if (!string.IsNullOrEmpty(request.IdNumber))
                {
                    filters.Add(x => x.Contact.PersonalInfo.IdentityNumber!= null && x.Contact.PersonalInfo.IdentityNumber.Contains(request.IdNumber));
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    filters.Add(x => x.Contact.PersonalInfo.FullNameAr != null && x.Contact.PersonalInfo.FullNameAr.Contains(request.Name) );
                }
                if (!string.IsNullOrWhiteSpace(request.Mobile))
                {
                    filters.Add(x => x.Contact.PersonalInfo.PhoneNumber != null && x.Contact.PersonalInfo.PhoneNumber.Contains(request.Mobile) );
                }
               
                if (request.CategoryId!=null)
                {
                    filters.Add(x => x.CategoryId == (request.CategoryId));
                }
                if (request.CampaignId != null)
                {
                    filters.Add(x => x.CampaignId == (request.CampaignId));
                }
                if (request.CallStatusId != null)
                {
                    filters.Add(x => x.CallStatusId == Guid.Parse(request.CallStatusId));
                }
               
                filters.Add(x => x.StateCode == 1);
               
                #endregion

                var HistoricalCall = _context.HistoricalCall.AsQueryable();
                var pagedResponse = new PagedResponse<HistoricalCall>();
                if (request.PageIndex !=null && request.PageSize != null)
                {
                    pagedResponse = await HistoricalCall
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await HistoricalCall
                         .GetAllOnDynamicFilter(filters, orderBy);
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                result.Data = new PagedResponse<HistoricalCallVM>
                {
                    Items = new List<HistoricalCallVM>(),
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
                    var historicalCallObject = new HistoricalCallVM
                    {
                        Id = item.Id,
                        IdNumber = item.Contact?.PersonalInfo?.IdentityNumber?? "",
                        Name = item.Contact?.PersonalInfo?.FullNameAr ?? "",
                        Mobile = item.Contact?.PersonalInfo?.PhoneNumber ?? "",

                        ContactId = item.ContactId,
                        CallStatusId = item.CallStatusId,
                        CallTypeId = item.CallTypeId,
                     
                       
                        CallDuration = item.CallDuration,
                      
                        IsLatestCall = item.IsLatestCall,
                        LatestHistoricalCallId = item.LatestHistoricalCallId,
                      
                       

                        CategoryName = item.Category?.NameAr?? "",
                        CampaignName = item.Campaign?.NameAr ?? "",
                        CallStatusName = item.CallStatus?.NameAr ?? "",
                       
                        CallTypeName = item.CallType?.NameAr??"",
                      CallDate = item.CallDate.ToString("yyyy/MM/dd hh:mm:ss"),

                       // SubNote = await _generalOperation.GetHistoricalCallResultCusTomFieldValue(item, "SubNoteId"),
                    };
                    result.Data.Items.Add(historicalCallObject);
                }

                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;

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
