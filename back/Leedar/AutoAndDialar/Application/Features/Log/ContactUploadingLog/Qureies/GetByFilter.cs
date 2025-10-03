namespace Application.Features.Log
{
    using Domain.Entities.Application;
    using Domain.Entities.Log;
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


    public class GetByFilter : IRequest<Response<PagedResponse<ContactUploadingLogVM>>>
    {
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public DateRangViewModel? SelectedDateRange { get; set; }
        public string? ContactIdentityNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
       
       
        public string? IsUploadedSuccessfully { get; set; }

        
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ContactUploadingLogVM>>>
    {
        private readonly IApplicationDbContext _context;
     
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        
        public GetByFilterHandler(
            IApplicationDbContext context,
           
            IContextCurrentUserService currentUserService,
            IGeneralOperation generalOperation
           )
        {
            _context = context;
           
            _currentUserService = currentUserService;
            _generalOperation = generalOperation;
           
        }
        public async Task<Response<PagedResponse<ContactUploadingLogVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            //new
           
            Response<PagedResponse<ContactUploadingLogVM>> result = new();
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateStart != null)
                {
                    var requestDateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
                }
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateEnd != null)
                {
                    var requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
                    if (request.SelectedDateRange.dateEnd == request.SelectedDateRange.dateStart)
                    {
                        requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(2);
                    }

                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
                }


                #region filters
                List<Expression<Func<ContactUploadingLog, bool>>> filters = new();
                IOrderedQueryable<ContactUploadingLog> orderBy(IQueryable<ContactUploadingLog> x) => x.OrderByDescending(x => x.CreatedOn);
                filters.Add(x => x.CreatedOn >= startDate && x.CreatedOn <= endDate);
               

                if (!string.IsNullOrEmpty(request.ContactIdentityNumber))
                {
                    filters.Add(x => x.Contact.PersonalInfo.IdentityNumber.Contains(request.ContactIdentityNumber));
                }
                if (!string.IsNullOrEmpty(request.ContactName))
                {
                    filters.Add(x => x.Contact.PersonalInfo.FullNameAr.Contains(request.ContactName) );
                }
                if (!string.IsNullOrWhiteSpace(request.ContactPhone))
                {
                    filters.Add(x => x.Contact.PersonalInfo.PhoneNumber.Contains(request.ContactPhone) ||
                                     x.Contact.PersonalInfo.PhoneNumber2.Contains(request.ContactPhone));
                }
                if (!string.IsNullOrEmpty(request.IsUploadedSuccessfully))
                {
                    if (request.IsUploadedSuccessfully == "yes")
                    { filters.Add(x => x.IsUploadedSuccessfully == true); }
                    else { filters.Add(x => x.IsUploadedSuccessfully == false); }
                }
                if (request.CategoryId != null)
                {
                    filters.Add(x => x.CategoryId == (request.CategoryId));
                }
                if (request.CampaignId != null)
                {
                    filters.Add(x => x.CampaignId == (request.CampaignId));
                }


                #endregion

                var ContactUploadingLog = _context.ContactUploadingLog.AsQueryable();
                var pagedResponse = new PagedResponse<ContactUploadingLog>();
                if (request.PageIndex != null && request.PageSize != null)
                {
                    pagedResponse = await ContactUploadingLog
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await ContactUploadingLog
                         .GetAllOnDynamicFilter(filters, orderBy);
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                result.Data = new PagedResponse<ContactUploadingLogVM>
                {
                    Items = new List<ContactUploadingLogVM>(),
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
                    if (item != null) {
                        var ContactUploadResultObject = new ContactUploadingLogVM
                        {
                            Id = item.Id,
                            ContactId = item.ContactId,
                            IdentityNumber = (item.Contact != null)? item.Contact?.PersonalInfo?.IdentityNumber : "",
                            ContactName = (item.Contact != null) ? item.Contact?.PersonalInfo?.FullNameAr : "",
                            PhoneNumber = (item.Contact != null) ? item.Contact?.PersonalInfo?.PhoneNumber : "",
                            AgentName = (item.CreatedByUser != null) ? item.CreatedByUser?.PersonalInfo?.FullNameAr : "",
                            IsUploadedSuccessfully = (item.IsUploadedSuccessfully == true) ? "تمت الإضافة" : " لم تتم الإضافة",
                            //GetResultNameByPIMCode(x.Completion_code_Name),
                            CreatedAt = item.CreatedOn.ToString(),
                            Description = (item.Description != null) ? item.Description : "",
                            DescriptionOthers = (item.DescriptionOthers != null) ? item.DescriptionOthers : "",
                            FileName = (item.FileName != null) ? item.FileName : "",
                            FileRow = item.FileRow,
                            CategoryName = (item.CategoryId != null) ? item.Category.NameAr : "",
                            CampaignName = (item.CampaignId != null) ? item.Campaign.NameAr : "",
                            PriorityName = (item.PriorityId != null) ? item.Priority.NameAr : "",


                        };
                        result.Data.Items.Add(ContactUploadResultObject);
                    }
                   
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
