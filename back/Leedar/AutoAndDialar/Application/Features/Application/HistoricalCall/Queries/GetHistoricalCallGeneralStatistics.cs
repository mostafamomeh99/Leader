using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall.Queries
{

    public class GetHistoricalCallGeneralStatistics : IRequest<Response<HistoricalCallGeneralStatistics>>
    {
        public DateRangViewModel? SelectedDateRange { get; set; }
        public List<string>? UserIds { get; set; }
        public List<string>? TeamIds { get; set; }

    }
    public class GetHistoricalCallGeneralStatisticsHandler : IRequestHandler<GetHistoricalCallGeneralStatistics, Response<HistoricalCallGeneralStatistics>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHistoricalCallGeneralStatisticsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<HistoricalCallGeneralStatistics>> Handle(GetHistoricalCallGeneralStatistics request, CancellationToken cancellationToken)
        {
            Response<HistoricalCallGeneralStatistics> result = new();
            try
            {
                
                //var dbHistoricalCallInDate = await _context.HistoricalCall.Where(x => x.ScheduledCallDate >= request.StartDate && x.ScheduledCallDate <= request.EndDate).ToListAsync();
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateStart!=null)
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


                var historicalCall = _context.HistoricalCall.AsQueryable();
                historicalCall = historicalCall.Where(x => x.CallDate >= startDate && x.CallDate <= endDate);

                if (request.TeamIds != null && request.TeamIds.Any())

                {
                     List<Guid> teamsGuid = request.TeamIds.Select(Guid.Parse).ToList();
                    historicalCall = historicalCall.Where(x => x.AssignToUser.UserTeams.Any(y => teamsGuid.Contains(y.TeamId)));
                }
                if (request.UserIds != null && request.UserIds.Any())
                {
                    List<Guid> userGuid = request.UserIds.Select(Guid.Parse).ToList();
                    historicalCall = historicalCall.Where(x => userGuid.Contains(x.AssignToUserId.Value));
                }

                var grouppedhistoricalCall = await historicalCall.GroupBy(x => new
                {
                    x.CallStatusId,
                    x.SubCallStatusId
                }).Select(x => new
                {
                    CallStatusId = x.Key.CallStatusId,
                    SubCallStatusId = x.Key.SubCallStatusId,
                    Ccount = x.Count()
                }).ToListAsync();

                result.Data = new HistoricalCallGeneralStatistics();
                result.Data.SuccessCall = grouppedhistoricalCall.Where(x => x.CallStatusId == Shared.Struct.CallStatus.Success)?.Sum(x => x.Ccount) ?? 0;
                result.Data.NotSuccessCall = grouppedhistoricalCall.Where(x => x.CallStatusId == Shared.Struct.CallStatus.Notsuccess)?.Sum(x => x.Ccount) ?? 0;
                result.Data.ReCall = grouppedhistoricalCall.Where(x => x.CallStatusId == Shared.Struct.CallStatus.Recall)?.Sum(x => x.Ccount) ?? 0;

                result.Data.SuccessCallInterested = grouppedhistoricalCall.Where(x => x.SubCallStatusId == Shared.Struct.SubStatus.Interested && x.CallStatusId == Shared.Struct.CallStatus.Success)?.Sum(x => x.Ccount) ?? 0;
                result.Data.SuccessCallNotInterested = grouppedhistoricalCall.Where(x => x.SubCallStatusId == Shared.Struct.SubStatus.NotInterested && x.CallStatusId == Shared.Struct.CallStatus.Success)?.Sum(x => x.Ccount) ?? 0;
                result.Data.SuccessCallInProgress = grouppedhistoricalCall.Where(x => x.SubCallStatusId == Shared.Struct.SubStatus.InProgress && x.CallStatusId == Shared.Struct.CallStatus.Success)?.Sum(x => x.Ccount) ?? 0;

                //result.Data.SuccessCallFollowup = grouppedhistoricalCall.Where(x => x.CallTypeId == Shared.Struct.CallType.CollectingCallFollowup && x.CallStatusId == Shared.Struct.CallStatus.Success)?.Sum(x => x.Ccount) ?? 0;
                //result.Data.NotSuccessCallFollowup = grouppedhistoricalCall.Where(x => x.CallTypeId == Shared.Struct.CallType.CollectingCallFollowup && x.CallStatusId == Shared.Struct.CallStatus.Notsuccess)?.Sum(x => x.Ccount) ?? 0;
                //result.Data.ReCallFollowup = grouppedhistoricalCall.Where(x => x.CallTypeId == Shared.Struct.CallType.CollectingCallFollowup && x.CallStatusId == Shared.Struct.CallStatus.Recall)?.Sum(x => x.Ccount) ?? 0;


               
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
