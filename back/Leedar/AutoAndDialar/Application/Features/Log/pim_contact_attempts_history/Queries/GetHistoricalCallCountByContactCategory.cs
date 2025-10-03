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

//    public class GetHistoricalCallCountByContactCategory : IRequest<Response<HistoricalCallStatisticsForCallStatusVM>>
//    {
//        public DateRangViewModel SelectedDateRange { get; set; }

//    }
//    public class GetHistoricalCallCountByContactCategoryHandler : IRequestHandler<GetHistoricalCallCountByContactCategory, Response<HistoricalCallStatisticsForCallStatusVM>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public GetHistoricalCallCountByContactCategoryHandler(IApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }
//        public async Task<Response<HistoricalCallStatisticsForCallStatusVM>> Handle(GetHistoricalCallCountByContactCategory request, CancellationToken cancellationToken)
//        {
//            Response<HistoricalCallStatisticsForCallStatusVM> result = new();
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

//                var calls = await historicalCall.Where(x => x.Contact_attempt_time != null)
//                    .GroupBy(x => new
//                    {
//                        CategoryId = x.CategoryId,
//                        x.IsSuccess
//                    }).Select(x => new
//                    {
//                        CategoryId = x.Key.CategoryId,
//                        IsSuccess = x.Key.IsSuccess,
//                        successCount = x.Count(y => x.Key.IsSuccess),
//                        count = x.Count(),
//                    }).ToListAsync();


//                var allCampaigns = calls
//                    .OrderBy(x => x.successCount)
//                    .Select(x => x.CategoryId).Distinct().ToList();

//                var CampaigDic = await _context.Category.ToDictionaryAsync(x => x.Id, x => x.NameAr);

//                result.Data = new HistoricalCallStatisticsForCallStatusVM
//                {
//                    Label = new List<string>(),
//                    SuccessCall = new List<int>(),
//                    NotSuccessCall = new List<int>(),
//                    Recall = new List<int>(),
//                    BillCount = new List<int>(),
//                    BillAmount = new List<double>(),
//                };
//                foreach (var categoryId in allCampaigns)
//                {
//                    var neededlabel = calls.Where(x => x.CategoryId == categoryId);
//                    string label = "غير معروف";
//                    if (categoryId != null)
//                    {
//                        label = CampaigDic[categoryId.Value];
//                    }

//                    result.Data.Label.Add(label);
//                    result.Data.SuccessCall.Add(neededlabel.Where(x => x.CategoryId == categoryId && x.IsSuccess == true).Sum(x => x.count));
//                    result.Data.NotSuccessCall.Add(neededlabel.Where(x => x.CategoryId == categoryId && x.IsSuccess == true).Sum(x => x.count));
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
