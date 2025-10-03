namespace Application.Features.Application.ScheduledCall.Queries
{
    using Domain.Entities.Application;
    using global::Application.Common.Interfaces;
    using global::Application.Common.Models;
    using global::Application.Extensions;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    //using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
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
    public class GetStaticsByFilter : IRequest<Response<StatisticsByFilter>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public Guid? CallStatusId { get; set; }

        public string? IdNumber { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }

       
        public Guid? PreviousCallStatusId { get; set; }

        public Guid? AssignToUserId { get; set; }
        public Guid? AssignFromUserId { get; set; }

        public DateRangViewModel? StatisticDateRange { get; set; }

    }
    public class GetStaticsByFilterHandler : IRequestHandler<GetStaticsByFilter, Response<StatisticsByFilter>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        public GetStaticsByFilterHandler(IApplicationDbContext context, IContextCurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<Response<StatisticsByFilter>> Handle(GetStaticsByFilter request, CancellationToken cancellationToken)
        {
            Response<StatisticsByFilter> result = new();
            try
            {
                #region filters
                var startDate = DateTime.Now;
                var endDate = DateTime.Now;
                var schadualedCalls = _context.ScheduledCall.AsQueryable();
                if (request.CallStatusId != null)
                {
                    schadualedCalls = schadualedCalls.Where(x => x.CallStatusId == request.CallStatusId);
                }
                if (request.StatisticDateRange != null && request.StatisticDateRange.dateStart != null)
                {
                    var requestDateStart = request.StatisticDateRange.dateStart.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
                }
                if (request.StatisticDateRange != null && request.StatisticDateRange.dateEnd != null)
                {
                    var requestDateEnd = request.StatisticDateRange.dateEnd.Value.AddDays(1);
                    if (request.StatisticDateRange.dateEnd == request.StatisticDateRange.dateStart)
                    {
                        requestDateEnd = request.StatisticDateRange.dateEnd.Value.AddDays(2);
                    }

                   endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
                }

                var currentUserRole = (await _context.User.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync())?.Roles!.Select(x => x.RoleId).ToList();
                if (currentUserRole!.Any(x => x == Shared.Struct.Roles.Admin ||
                x == Shared.Struct.Roles.SuperAdmin ||
                x == Shared.Struct.Roles.Supervisor ||
                 x == Shared.Struct.Roles.QualitySupervisor ||
                  x == Shared.Struct.Roles.QualityEmployee))
                {

                }
               
                
                else
                {
                    result.Data = null;
                    result.Message = new NotificationMessage
                    {
                        Title = "صلاحية غير موجودة",
                        Body = "عذراً لا يوجد لديك صلاحية للقيام بالإجراء المطلوب"
                    };
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = false;
                    return result;
                }

                #endregion
                //var today = DateTime.Today;
                //var month = new DateTime(today.Year, today.Month, 1);
                //var first = month.AddMonths(-1);
                //var last = month.AddDays(-1);
                var last = DateTime.Now.AddDays(-1);
                var first = DateTime.Now.AddDays(-31);
              
                var groppedCategory = schadualedCalls.GroupBy(x => x.Category!.NameAr)
                  .Select(x => new StatisticsCustomList
                  {
                      Name = x.Key,
                      Count = x.Count()
                  }).OrderBy(x => x.Count).ToList();
                var groppedCampaign = schadualedCalls.GroupBy(x => x.Campaign!.NameAr)
                      .Select(x => new StatisticsCustomList
                      {
                          Name = x.Key,
                          Count = x.Count()
                      }).OrderBy(x => x.Count).ToList();
                result.Data = new StatisticsByFilter
                {
                   
                    Campaign = groppedCampaign,
                    Category = groppedCategory,
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
                    Title = "مشكلة في الحصول على إحصائيات المكالمات ",
                    Body = "يرجى المحاولة من جديد"
                };
            }
            return result;
        }
    }
}
