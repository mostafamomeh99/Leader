namespace Application.Features.Application.ScheduledCall.Queries
{
    using Domain.Entities.Application;
    using global::Application.Common.Interfaces;
    using global::Application.Common.Models;
    using global::Application.Extensions;
    using Infrastructure.Interfaces;
    using MediatR;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetByFilter : IRequest<Response<PagedResponse<ByFilterVm>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public string? CallStatusId { get; set; }


        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? CategoryId { get; set; }
        public string? CampaignId { get; set; }
        public string? PriorityId { get; set; }
        public string? CallTypeId { get; set; }



        public DateRangViewModel? ScheduledCallDateRange { get; set; }
        public Guid? AssignToUserId { get; set; }
        // public DateRangViewModel TryingDateRange { get; set; }


    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ByFilterVm>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        public GetByFilterHandler(IApplicationDbContext context,
          IGeneralOperation generalOperation,
            IContextCurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _generalOperation = generalOperation;

        }
        public async Task<Response<PagedResponse<ByFilterVm>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            //  await _generalOperation.CheckAllNotSentCallsToREDF();
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
            if (DateTime.Now.Hour == 0)
            {
                startDate = startDate.AddDays(-1);
            }
            DateTime endDate = startDate.AddDays(1);
            DateTime startTryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
            if (DateTime.Now.Hour == 0)
            {
                startTryDate = startTryDate.AddDays(-1);
            }
            DateTime endTryDate = startTryDate.AddDays(1);

            if (request.ScheduledCallDateRange != null && request.ScheduledCallDateRange.dateStart != null)
            {
                var requestDateStart = request.ScheduledCallDateRange.dateStart.Value.AddDays(1);
                startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
            }
            if (request.ScheduledCallDateRange != null && request.ScheduledCallDateRange.dateEnd != null)
            {
                var requestDateEnd = request.ScheduledCallDateRange.dateEnd.Value.AddDays(1);
                if (request.ScheduledCallDateRange.dateEnd == request.ScheduledCallDateRange.dateStart)
                {
                    requestDateEnd = request.ScheduledCallDateRange.dateEnd.Value.AddDays(2);
                }

                endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
            }
            //if (request.TryingDateRange != null && !request.TryingDateRange.dateStart.IsNullOrDefault<DateTime>())
            //{
            //    var requestDateStart = request.TryingDateRange.dateStart.Value.AddDays(1);
            //    startTryDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
            //}
            //if (request.TryingDateRange != null && !request.TryingDateRange.dateEnd.IsNullOrDefault<DateTime>())
            //{
            //    var requestDateEnd = request.TryingDateRange.dateEnd.Value.AddDays(1);
            //    if (request.TryingDateRange.dateEnd == request.TryingDateRange.dateStart)
            //    {
            //        requestDateEnd = request.TryingDateRange.dateEnd.Value.AddDays(2);
            //    }

            //    endTryDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
            //}


            Response<PagedResponse<ByFilterVm>> result = new();
            try
            {
                #region filters
                List<Expression<Func<ScheduledCall, bool>>> filters = new();
                IOrderedQueryable<ScheduledCall> orderBy(IQueryable<ScheduledCall> x) => x.OrderByDescending(x => x.CreatedOn);
                //var currentUserRole = (await _context.User.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync())?.Roles.Select(x => x.RoleId).ToList();
                //if (currentUserRole.Any(x => x == Shared.Struct.Roles.Admin ||
                //x == Shared.Struct.Roles.SuperAdmin ||
                //x == Shared.Struct.Roles.Supervisor ||
                // x == Shared.Struct.Roles.QualitySupervisor ||
                //  x == Shared.Struct.Roles.QualityEmployee))
                //{

                //}

                //else
                //{
                //    result.Data = null;
                //    result.Message = new NotificationMessage
                //    {
                //        Title = "صلاحية غير موجودة",
                //        Body = "عذراً لا يوجد لديك صلاحية للقيام بالإجراء المطلوب"
                //    };
                //    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                //    result.Succeeded = false;
                //    return result;
                //}
                //  var isBankAgent = (await _context.User.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync())?.RelatedToBankId;
                //  if(isBankAgent != null) { filters.Add(x => x.ScheduledCallDate <= DateTime.Now); }
                if (request.ScheduledCallDateRange != null && request.ScheduledCallDateRange.dateEnd != null && request.ScheduledCallDateRange.dateStart != null)
                {
                    filters.Add(x => x.ScheduledCallDate >= startDate && x.ScheduledCallDate <= endDate);
                }
                //if (request.TryingDateRange != null && !request.TryingDateRange.dateEnd.IsNullOrDefault<DateTime>() && !request.TryingDateRange.dateStart.IsNullOrDefault<DateTime>())
                //{
                //    filters.Add(x => x.LastModifiedOn >= startTryDate && x.LastModifiedOn <= endTryDate);
                //}

                if (!string.IsNullOrEmpty(request.IdNumber))
                {
                    filters.Add(x => x.Contact!.PersonalInfo!.IdentityNumber!.Contains(request.IdNumber));
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    filters.Add(x => x!.Contact!.PersonalInfo!.FullNameAr!.Contains(request.Name));
                }
                if (!string.IsNullOrWhiteSpace(request.Mobile))
                {
                    filters.Add(x => x!.Contact!.PersonalInfo!.PhoneNumber!.Contains(request.Mobile));
                }

                if (request.CategoryId != null)
                {
                    filters.Add(x => x.CategoryId == Guid.Parse(request.CategoryId));
                }
                if (request.PriorityId != null)
                {
                    filters.Add(x => x.PriorityId == Guid.Parse(request.PriorityId));
                }
                if (request.CampaignId != null)
                {
                    filters.Add(x => x.CampaignId == Guid.Parse(request.CampaignId));
                }
                if (request.CallStatusId != null)
                {
                    filters.Add(x => x.CallStatusId == Guid.Parse(request.CallStatusId));
                }
                if (request.CallTypeId != null)
                {
                    filters.Add(x => x.CallTypeId == Guid.Parse(request.CallTypeId));
                }





                //filters.Add(x => x.IsStatic != true);
                filters.Add(x => x.StateCode == 1);


                #endregion

                var ScheduledCall = _context.ScheduledCall.AsQueryable();
                var pagedResponse = new PagedResponse<ScheduledCall>();
                if (request.PageIndex != null && request.PageSize != null)
                {
                    pagedResponse = await ScheduledCall
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await ScheduledCall
                         .GetAllOnDynamicFilter(filters, orderBy);
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                result.Data = new PagedResponse<ByFilterVm>
                {
                    Items =
                    //CultureHelper.IsArabic ?
                    pagedResponse.Items.Select(x => new ByFilterVm
                    {
                        Id = x.Id,
                        IdNumber = x.Contact?.IdentityNumber ?? "",
                        Name = x.Contact?.FullName ?? "",
                        Mobile = x.Contact?.PhoneNumber ?? "",
                        //CategoryPathId = x.Category.CategoryPathId,
                        //CategoryPath = x.Category?.NameAr,
                        CampaignId = x.CampaignId,
                        Campaign = x.Campaign?.NameAr ?? "",
                        Category = x.Category?.NameAr ?? "",
                        Priority = x.Priority?.NameAr ?? "",

                        PreviousCallStatusId = x.CallStatusId,
                        PreviousCallStatus = x.LatestHistoricalCall?.CallStatus?.NameAr ?? "",

                        //ScheduledByUser = x.ScheduledByUser?.PersonalInfo.FullNameAr,
                        ScheduledToUserAt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),

                        LatestCallAt = x.LatestHistoricalCall?.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss") ?? "",
                    }).ToList()
                    //:
                    //pagedResponse.Items.Select(x => new ByFilterVm
                    //{
                    //    Id = x.Id,
                    //    IdNumber = x.Contact.PersonalInfo.IdentityNumber,
                    //    Name = x.Contact.PersonalInfo.FullNameEn,
                    //    Mobile = x.Contact.PersonalInfo.PhoneNumber,
                    //    //CategoryPathId = x.Category.CategoryPathId,
                    //    //CategoryPath = x.Category.CategoryPath?.NameEn,
                    //    CampaignId = x.CampaignId,
                    //    Campaign = x.Campaign.NameEn,
                    //    Category = x.Category.NameEn,
                    //    PreviousCallStatusId = x.CallStatusId,
                    //    Arrears = x.Contract?.Arrears.ToString("C", new CultureInfo("ar-SA")),
                    //    ArrearsDic = x.Contact.Contracts.ToDictionary(y => y.ContractNumber, y => y.Arrears.ToString("C", new CultureInfo("ar-SA"))),
                    //    PreviousCallStatus = x.LatestHistoricalCall?.CallStatus.NameEn,
                    //    AssignedToUser = x.AssignFromUser?.PersonalInfo.FullNameEn,
                    //    AssignedToUserAt = x.AssignToUserAt?.ToString("yyyy/MM/dd hh:mm:ss"),
                    //    AssignedFromUser = x.AssignFromUser?.PersonalInfo.FullNameEn,
                    //    ScheduledToUser = x.ScheduledToUser?.PersonalInfo.FullNameEn,
                    //    ScheduledCallDate = x.ScheduledCallDate?.ToString("yyyy/MM/dd hh:mm:ss"),
                    //    ScheduledByUser = x.ScheduledByUser?.PersonalInfo.FullNameEn,
                    //    ScheduledToUserAt = x.ScheduledToUserAt?.ToString("yyyy/MM/dd hh:mm:ss"),
                    //    LatestCallByUser = x.LatestHistoricalCall?.AssignToUser?.PersonalInfo.FullNameEn,
                    //    LatestCallAt = x.LatestHistoricalCall?.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"),
                    //}).ToList()
                    ,
                    PageIndex = pagedResponse.PageIndex,
                    PageItemsEnd = pagedResponse.PageItemsEnd,
                    PageItemsStart = pagedResponse.PageItemsStart,
                    PageSize = pagedResponse.PageSize,
                    Succeeded = true,
                    TotalItems = pagedResponse.TotalItems,
                    TotalPages = pagedResponse.TotalPages,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                };



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
                    Title = "مشكلة في الحصول على المكالمات ",
                    Body = "يرجى المحاولة من جديد"
                };
            }
            return result;
        }
    }
}
