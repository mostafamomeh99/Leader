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
    public class GetInfoOfScheduledCallId : IRequest<Response<HistoricalCallVM>>
    {
        public string ScheduledCallId { get; set; }


    }
    public class GetInfoOfScheduledCallIdHandler : IRequestHandler<GetInfoOfScheduledCallId, Response<HistoricalCallVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGeneralOperation _generalOperation;
        public GetInfoOfScheduledCallIdHandler(IApplicationDbContext context, IGeneralOperation generalOperation)
        {
            _context = context;
            _generalOperation = generalOperation;
        }
        public async Task<Response<HistoricalCallVM>> Handle(GetInfoOfScheduledCallId request, CancellationToken cancellationToken)
        {
            Response<HistoricalCallVM> result = new();
            try
            {

                var HistoricalCall = await _context.HistoricalCall.FirstOrDefaultAsync(x => x.ScheduledCallId == Guid.Parse(request.ScheduledCallId));

                if (HistoricalCall != null)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    result.Data = new HistoricalCallVM
                    {
                        Id = HistoricalCall.Id,
                        IdNumber = HistoricalCall.Contact?.PersonalInfo?.IdentityNumber,
                        Name = HistoricalCall.Contact?.PersonalInfo?.FullNameAr,
                        Mobile = HistoricalCall.Contact?.PersonalInfo?.PhoneNumber,

                        CategoryName = HistoricalCall.Category?.NameAr,
                        CampaignName = HistoricalCall.Campaign?.NameAr,
                        CallStatusName = HistoricalCall.CallStatus?.NameAr,
                      
                        CallTypeName = HistoricalCall.CallType?.NameAr,
                        CallDate = HistoricalCall.CallDate.ToString("yyyy/MM/dd hh:mm:ss"),

                       // SubNote = await _generalOperation.GetHistoricalCallResultCusTomFieldValue(HistoricalCall, "SubNoteId"),
                    };

                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = true;
                }
                else
                {
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = false;
                    result.Message = new NotificationMessage
                    {
                        Title = "لا يوجد مكالمة تاريخية ",
                        Body = "لا يوجد مكالمة تاريخية متعلقة بالمعرف للمكالمة المجدولة",
                    };
                }



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
