namespace Application.Features.Application.Contact.Queries
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
    public class GetByFilter : IRequest<Response<PagedResponse<ByFilterVM>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DisplayName { get; set; }
       
        //  public DateTime? LatestCallCreatedOn { get; set; }
        public DateRangViewModel? LatestCallCreatedOn { get; set; }
        public string? LatestCallStatusId { get; set; }
       
        public int? HistoricalCallCount { get; set; }
        public byte? StateCode { get; set; }
        public bool? IsDisable { get; set; }
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ByFilterVM>>>
    {
        private readonly IApplicationDbContext _context;
        public GetByFilterHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<ByFilterVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<ByFilterVM>> result = new();
            try
            {
                #region filters
                List<Expression<Func<Contact, bool>>> filters = new();
                IOrderedQueryable<Contact> orderBy(IQueryable<Contact> x) => x.OrderByDescending(x => x.CreatedOn);
               
                
                if (!string.IsNullOrEmpty(request.IdentityNumber))
                {
                    filters.Add(x => x.PersonalInfo!.IdentityNumber!.Contains(request.IdentityNumber));
                }
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                {
                    filters.Add(x => x.PersonalInfo!.PhoneNumber!.Contains(request.PhoneNumber) );
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayName))
                {
                    filters.Add(x => x.PersonalInfo!.FullNameAr!.Contains(request.DisplayName));
                }
               
              


                if (request.LatestCallCreatedOn != null &&
                   request.LatestCallCreatedOn.dateStart != null &&
                   request.LatestCallCreatedOn.dateEnd != null)
                {
                    if (!request.LatestCallCreatedOn.dateStart.IsNullOrDefault<DateTime>())
                    {
                        filters.Add(x =>
                           x.HistoricalCalls!.Count() > 0 &&
                           x.HistoricalCalls!.OrderByDescending(y => y.CreatedOn).FirstOrDefault()!.CreatedOn.Date >= request.LatestCallCreatedOn.dateStart.Value.Date.AddDays(1));
                    }
                    if (!request.LatestCallCreatedOn.dateEnd.IsNullOrDefault<DateTime>())
                    {
                        filters.Add(x =>
                            x.HistoricalCalls!.Count() > 0 &&
                            x.HistoricalCalls!.OrderByDescending(y => y.CreatedOn).FirstOrDefault()!.CreatedOn.Date <= request.LatestCallCreatedOn.dateEnd.Value.Date.AddDays(1));
                    }
                }
           


               
                //if (request.LatestCallCreatedOn != null)
                //{
                //    switch (request.LatestCallCreatedOnOperation.ToString().ToLower())
                //    {
                //        case Shared.Struct.EntitiesString.ConditionType.Equal:
                //            filters.Add(x =>
                //            x.HistoricalCalls.Count() > 0 &&
                //            x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date == request.LatestCallCreatedOn.Value.Date);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
                //            filters.Add(x =>
                //         x.HistoricalCalls.Count() > 0 &&
                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date != request.LatestCallCreatedOn.Value.Date);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
                //            filters.Add(x =>
                //         x.HistoricalCalls.Count() > 0 &&
                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date > request.LatestCallCreatedOn.Value.Date);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.LessThan:
                //            filters.Add(x =>
                //         x.HistoricalCalls.Count() > 0 &&
                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date < request.LatestCallCreatedOn.Value.Date);
                //            break;
                //    }
                //}

                if (request.LatestCallStatusId != null)
                {
                    filters.Add(x =>
                    x.HistoricalCalls!.Count() > 0 &&
                    x.HistoricalCalls!.OrderByDescending(y => y.CreatedOn).FirstOrDefault()!.CallStatusId == Guid.Parse(request.LatestCallStatusId));
                }

                //if (!string.IsNullOrWhiteSpace(request.EmployerType))
                //{
                //    filters.Add(x => x.EmployerType.NameAr.Contains(request.EmployerType) ||
                //                     x.EmployerType.NameEn.Contains(request.EmployerType));
                //}
                //if (request.HistoricalCallCount != null)
                //{
                //    switch (request.HistoricalCallCountOperation.ToString().ToLower())
                //    {
                //        case Shared.Struct.EntitiesString.ConditionType.Equal:
                //            filters.Add(x => x.HistoricalCalls.Count() == request.HistoricalCallCount);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
                //            filters.Add(x => x.HistoricalCalls.Count() != request.HistoricalCallCount);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
                //            filters.Add(x => x.HistoricalCalls.Count() > request.HistoricalCallCount);
                //            break;
                //        case Shared.Struct.EntitiesString.ConditionType.LessThan:
                //            filters.Add(x => x.HistoricalCalls.Count() < request.HistoricalCallCount);
                //            break;
                //    }


                //}

                //if (request.AssignToUserAtDateRange != null)
                //{
                //    if (request.AssignToUserAtDateRange.DateStart != null &&
                //          request.AssignToUserAtDateRange.DateEnd != null)
                //    {
                //        filters.Add(x =>
                //           x.AssignToUserAt.Value.Date >= request.AssignToUserAtDateRange.DateStart &&
                //           x.AssignToUserAt.Value.Date <= request.AssignToUserAtDateRange.DateStart
                //           );
                //    }
                //}

                //filters.Add(x => x.IsStatic != true);
                if (request.StateCode != null)
                {
                    filters.Add(x => x.StateCode == request.StateCode);
                }
                else
                {
                    filters.Add(x => x.StateCode == 1);
                }
                if (request.IsDisable != null)
                {
                    filters.Add(x => x.IsDesable == request.IsDisable);
                }

                #endregion

                var Contact = _context.Contact.AsQueryable();
                //.Include(x => x.PersonalInfo)
                //.Include(x => x.StumbleType)
                //.Include(x => x.EmployerType)
                //.Include(x => x.LatestSatisfaction);
                var pagedResponse = new PagedResponse<Contact>();
                if (request.PageIndex != null&& request.PageSize != null)
                {
                    pagedResponse = await Contact
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await Contact
                         .GetAllOnDynamicFilter(filters, orderBy);
                }
                result.Data = new PagedResponse<ByFilterVM>
                {
                    Items = new List<ByFilterVM>(),
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
                    var LatestCal = item.HistoricalCalls!.OrderByDescending(x => x.CreatedOn).FirstOrDefault();
                    result.Data.Items.Add(new ByFilterVM
                    {
                        Id = item.Id,
                        IdentityNumber = item.PersonalInfo?.IdentityNumber,
                        DisplayName = item.PersonalInfo?.FullNameAr,
                        PhoneNumber = item.PersonalInfo?.PhoneNumber,
                        PhoneNumber2 = item.PersonalInfo?.PhoneNumber2,
                        LatestCallCreatedOn = LatestCal?.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss" , new CultureInfo("en-GB")),
                        LatestCallStatus = LatestCal?.CallStatus?.NameAr,
                        HistoricalCallCount = item.HistoricalCalls!.Count(),
                    });
                }
                //result.Data = new PagedResponse<ByFilterVM>
                //{
                //    Items = CultureHelper.IsArabic ?
                //      pagedResponse.Items.Select(x => new ByFilterVM
                //      {
                //          Id = x.Id,
                //          IdentityNumber = x.PersonalInfo.IdentityNumber,
                //          DisplayName = x.PersonalInfo.FullNameAr,
                //          PhoneNumber = x.PersonalInfo.PhoneNumber,
                //          PhoneNumber2 = x.PersonalInfo.PhoneNumber2,
                //          StumbleTypeId = x.StumbleTypeId,
                //          StumbleType = x.StumbleType?.NameAr,
                //          Arrears = x.Contracts.Sum(y => y.Arrears).ToString("C", new CultureInfo("ar-SA")),
                //          NumberOfLateInstallments = x.Contracts.Sum(y => y.NumberOfLateInstallments).ToString(),
                //          LatestCallCreatedOn = x.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"),
                //          LatestCallStatus = x.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.CallStatus.NameAr,
                //          HistoricalCallCount = x.HistoricalCalls.Count(),

                //      }).ToList()
                //      :
                //      pagedResponse.Items.Select(x => new ByFilterVM
                //      {
                //          Id = x.Id,
                //          IdentityNumber = x.PersonalInfo.IdentityNumber,

                //          DisplayName = x.PersonalInfo.FullNameEn,
                //          PhoneNumber = x.PersonalInfo.PhoneNumber,
                //          Notes = x.Notes,
                //          PhoneNumber2 = x.PersonalInfo.PhoneNumber2,
                //          Age = x.PersonalInfo.Age,
                //          NetSalary = x.NetSalary,
                //          StumbleTypeId = x.StumbleTypeId,
                //          StumbleType = x.StumbleType?.NameEn,
                //          Arrears = x.Contracts.Sum(y => y.Arrears).ToString("C", new CultureInfo("ar-SA")),
                //          NumberOfLateInstallments = x.Contracts.Sum(y => y.NumberOfLateInstallments).ToString(),
                //          LatestCallCreatedOn = x.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"),
                //          LatestCallStatus = x.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.CallStatus.NameAr,
                //          HistoricalCallCount = x.HistoricalCalls.Count(),
                //      }).ToList()
                //      ,

                //};



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