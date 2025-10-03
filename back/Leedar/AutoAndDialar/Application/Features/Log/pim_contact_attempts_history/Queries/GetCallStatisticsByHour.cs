//using Application.Common.Interfaces;
//using Application.Common.Models;
//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Shared.Extensions;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Log.pim_contact_attempts_history.Queries
//{
//    public class GetCallStatisticsByHour : IRequest<Response<CallStatisticsByHourVM>>
//    {
//        public DateRangViewModel SelectedDateRange { get; set; }

//    }
//    public class GetCallStatisticsByHourHandler : IRequestHandler<GetCallStatisticsByHour, Response<CallStatisticsByHourVM>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public GetCallStatisticsByHourHandler(IApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }
//        public async Task<Response<CallStatisticsByHourVM>> Handle(GetCallStatisticsByHour request, CancellationToken cancellationToken)
//        {
//            Response<CallStatisticsByHourVM> result = new();
//            try
//            {
//                var historicalCall = _context.Pim_contact_attempts_history.AsQueryable();
//                if (request.SelectedDateRange == null)
//                {
//                    request.SelectedDateRange = new DateRangViewModel();
//                }
//                if (request.SelectedDateRange != null && !request.SelectedDateRange.dateStart.IsNullOrDefault<DateTime>())
//                {
//                    historicalCall = historicalCall.Where(x => x.CreatedOn.Date >= request.SelectedDateRange.dateStart.Value.Date.AddDays(1));
//                }
//                if (request.SelectedDateRange != null && !request.SelectedDateRange.dateEnd.IsNullOrDefault<DateTime>())
//                {
//                    historicalCall = historicalCall.Where(x => x.CreatedOn.Date <= request.SelectedDateRange.dateEnd.Value.Date.AddDays(1));
//                }
//                if (request.SelectedDateRange.dateStart.IsNullOrDefault<DateTime>())
//                {
//                    historicalCall = historicalCall.Where(x => x.CreatedOn.Date == DateTime.Now.Date);
//                }

//                var groppedCalls = (await historicalCall.Where(x => x.Contact_attempt_time != null).GroupBy(x => new
//                {
//                    x.Contact_attempt_time.Value.Hour,
//                    x.IsSuccess
//                }).Select(x => new
//                {
//                    Hour = x.Key.Hour,
//                    IsSuccess = x.Key.IsSuccess,
//                    Count = x.Count(),
//                }).ToListAsync());

//                var allHours = groppedCalls.Select(x => x.Hour).Distinct().ToList().OrderBy(x => x).ToList();
//                result.Data = new CallStatisticsByHourVM
//                {
//                    Label = new List<string>(),
//                    SuccessCall = new List<int>(),
//                    NotSuccessCall = new List<int>(),
//                    Recall = new List<int>(),
//                };
//                foreach (var hour in allHours)
//                {
//                    result.Data.Label.Add(hour.ToString());
//                    result.Data.SuccessCall.Add(groppedCalls.Where(x => x.Hour == hour && x.IsSuccess == true).Sum(x => x.Count));
//                    result.Data.NotSuccessCall.Add(groppedCalls.Where(x => x.Hour == hour && x.IsSuccess == false).Sum(x => x.Count));
//                }
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                result.Succeeded = true;


//            }
//            catch (Exception ex)
//            {
//                result.Data = null;
//                result.Succeeded = false;
//                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
//                result.Exception = ex;
//                result.Message = new NotificationMessage
//                {
//                    Title = "",
//                    Body = ""
//                };
//            }
//            return result;
//        }
//    }
//}
