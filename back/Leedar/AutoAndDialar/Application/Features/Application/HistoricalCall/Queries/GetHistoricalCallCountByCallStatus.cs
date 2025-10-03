using Application.Common.Interfaces;
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

    public class GetHistoricalCallCountByCallStatus : IRequest<Response<GeneralStatisticsVM>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? User { get; set; }


    }
    class forJoin
    {
        public Guid ContactId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class GetHistoricalCallCountByCallStatusHandler : IRequestHandler<GetHistoricalCallCountByCallStatus, Response<GeneralStatisticsVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHistoricalCallCountByCallStatusHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<GeneralStatisticsVM>> Handle(GetHistoricalCallCountByCallStatus request, CancellationToken cancellationToken)
        {
            Response<GeneralStatisticsVM> result = new();
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.StartDate != null && !request.StartDate.IsNullOrDefault<DateTime>())
                {
                    var requestDateStart = request.StartDate.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
                }
                if (request.EndDate != null && !request.EndDate.IsNullOrDefault<DateTime>())
                {
                    var requestDateEnd = request.EndDate.Value.AddDays(1);
                    if (request.EndDate == request.StartDate)
                    {
                        requestDateEnd = request.EndDate.Value.AddDays(2);
                    }
                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
                }

                var historicalCalls = _context.HistoricalCall.AsQueryable();
                var contacts = _context.Contact.AsQueryable();

                historicalCalls = historicalCalls.Where(x => x.CallDate >= startDate && x.CallDate <= endDate);
                if (historicalCalls != null)
                {
                    contacts = contacts.Where(x => x.HistoricalCalls!.Any(y => y.CallDate >= startDate && y.CallDate <= endDate));


                    var groppedContacts = (await contacts
                        .Where(x => x.HistoricalCalls!.Any(y => y.CallDate >= startDate && y.CallDate <= endDate))
                        .Select(x => new
                        {
                            CallStatusId = x.HistoricalCalls!.Where(y => y.CallDate >= startDate && y.CallDate <= endDate)!.OrderBy(y => y.CallDate)!.FirstOrDefault()!.CallStatusId,
                        }).ToListAsync())
                        .GroupBy(x => new {  x.CallStatusId })
                        .Select(x => new
                        {
                            
                            CallStatusId = x.Key.CallStatusId,
                            Ccount = x.Count(),
                           
                        }).ToList();


                    var groppedhistoricalCalls = await historicalCalls.GroupBy(x =>
                     new {  x.CallStatusId }
                     ).Select(x => new
                     {
                         x.Key.CallStatusId,
                       
                         Ccount = x.Count(),

                     }).ToListAsync();


                    var dbHistoricalCallInDate = _context.HistoricalCall
                    .Where(x => x.ScheduledCallDate >= request.StartDate && x.ScheduledCallDate <= request.EndDate);

                   
                    result.Data.SuccessCallAVG = new ClassificationString
                    {
                        Close = (result.Data.AllCall.Close > 0 ? Math.Round((double)result.Data.SuccessCall.Close * 100 / (double)result.Data.AllCall.Close, 2) : 0).ToString() + " %",
                        Regular = (result.Data.AllCall.Regular > 0 ? Math.Round((double)result.Data.SuccessCall.Regular * 100 / (double)result.Data.AllCall.Regular, 2) : 0).ToString() + " %",
                        Stumbled = (result.Data.AllCall.Stumbled > 0 ? Math.Round((double)result.Data.SuccessCall.Stumbled * 100 / (double)result.Data.AllCall.Stumbled, 2) : 0).ToString() + " %",
                        NotRegular = (result.Data.AllCall.NotRegular > 0 ? Math.Round((double)result.Data.SuccessCall.NotRegular * 100 / (double)result.Data.AllCall.NotRegular, 2) : 0).ToString() + " %",
                        RedumpMortgage = (result.Data.AllCall.RedumpMortgage > 0 ? Math.Round((double)result.Data.SuccessCall.RedumpMortgage * 100 / (double)result.Data.AllCall.RedumpMortgage, 2) : 0).ToString() + " %",
                        UnDefined = (result.Data.AllCall.UnDefined > 0 ? Math.Round((double)result.Data.SuccessCall.UnDefined * 100 / (double)result.Data.AllCall.UnDefined, 2) : 0).ToString() + " %",

                    };
                    result.Data.NotSuccessCallAVG = new ClassificationString
                    {
                        Close = (result.Data.AllCall.Close > 0 ? Math.Round((double)result.Data.NotSuccessCall.Close * 100 / (double)result.Data.AllCall.Close, 2) : 0).ToString() + " %",
                        Regular = (result.Data.AllCall.Regular > 0 ? Math.Round((double)result.Data.NotSuccessCall.Regular * 100 / (double)result.Data.AllCall.Regular, 2) : 0).ToString() + " %",
                        Stumbled = (result.Data.AllCall.Stumbled > 0 ? Math.Round((double)result.Data.NotSuccessCall.Stumbled * 100 / (double)result.Data.AllCall.Stumbled, 2) : 0).ToString() + " %",
                        NotRegular = (result.Data.AllCall.NotRegular > 0 ? Math.Round((double)result.Data.NotSuccessCall.NotRegular * 100 / (double)result.Data.AllCall.NotRegular, 2) : 0).ToString() + " %",
                        RedumpMortgage = (result.Data.AllCall.RedumpMortgage > 0 ? Math.Round((double)result.Data.NotSuccessCall.RedumpMortgage * 100 / (double)result.Data.AllCall.RedumpMortgage, 2) : 0).ToString() + " %",
                        UnDefined = (result.Data.AllCall.UnDefined > 0 ? Math.Round((double)result.Data.NotSuccessCall.UnDefined * 100 / (double)result.Data.AllCall.UnDefined, 2) : 0).ToString() + " %",
                    };
                    result.Data.ReCallAVG = new ClassificationString
                    {
                        Close = (result.Data.AllCall.Close > 0 ? Math.Round((double)result.Data.Recall.Close * 100 / (double)result.Data.AllCall.Close, 2) : 0).ToString() + " %",
                        Regular = (result.Data.AllCall.Regular > 0 ? Math.Round((double)result.Data.Recall.Regular * 100 / (double)result.Data.AllCall.Regular, 2) : 0).ToString() + " %",
                        Stumbled = (result.Data.AllCall.Stumbled > 0 ? Math.Round((double)result.Data.Recall.Stumbled * 100 / (double)result.Data.AllCall.Stumbled, 2) : 0).ToString() + " %",
                        NotRegular = (result.Data.AllCall.NotRegular > 0 ? Math.Round((double)result.Data.Recall.NotRegular * 100 / (double)result.Data.AllCall.NotRegular, 2) : 0).ToString() + " %",
                        RedumpMortgage = (result.Data.AllCall.RedumpMortgage > 0 ? Math.Round((double)result.Data.Recall.RedumpMortgage * 100 / (double)result.Data.AllCall.RedumpMortgage, 2) : 0).ToString() + " %",
                        UnDefined = (result.Data.AllCall.UnDefined > 0 ? Math.Round((double)result.Data.Recall.UnDefined * 100 / (double)result.Data.AllCall.UnDefined, 2) : 0).ToString() + " %",
                    };
                    result.Data.PaymentPromisesAVG = new ClassificationString
                    {
                        Close = (result.Data.AllCall.Close > 0 ? Math.Round((double)result.Data.PaymentPromises.Close * 100 / (double)result.Data.AllCall.Close, 2) : 0).ToString() + " %",
                        Regular = (result.Data.AllCall.Regular > 0 ? Math.Round((double)result.Data.PaymentPromises.Regular * 100 / (double)result.Data.AllCall.Regular, 2) : 0).ToString() + " %",
                        Stumbled = (result.Data.AllCall.Stumbled > 0 ? Math.Round((double)result.Data.PaymentPromises.Stumbled * 100 / (double)result.Data.AllCall.Stumbled, 2) : 0).ToString() + " %",
                        NotRegular = (result.Data.AllCall.NotRegular > 0 ? Math.Round((double)result.Data.PaymentPromises.NotRegular * 100 / (double)result.Data.AllCall.NotRegular, 2) : 0).ToString() + " %",
                        RedumpMortgage = (result.Data.AllCall.RedumpMortgage > 0 ? Math.Round((double)result.Data.PaymentPromises.RedumpMortgage * 100 / (double)result.Data.AllCall.RedumpMortgage, 2) : 0).ToString() + " %",
                        UnDefined = (result.Data.AllCall.UnDefined > 0 ? Math.Round((double)result.Data.PaymentPromises.UnDefined * 100 / (double)result.Data.AllCall.UnDefined, 2) : 0).ToString() + " %",
                    };

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