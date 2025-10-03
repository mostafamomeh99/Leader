using Application.Common.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetHistoricalCallsOfCallId : IRequest<Response<List<HistoricalCallVM>>>
    {
        public string CallId { get; set; }
    }
    public class GetHistoricalCallsOfCallIdHandler : IRequestHandler<GetHistoricalCallsOfCallId, Response<List<HistoricalCallVM>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGeneralOperation _generalOperation;

        public GetHistoricalCallsOfCallIdHandler(IApplicationDbContext context, IMapper mapper, IGeneralOperation generalOperation)
        {
            _context = context;
            _mapper = mapper;
            _generalOperation = generalOperation;
        }
        public async Task<Response<List<HistoricalCallVM>>> Handle(GetHistoricalCallsOfCallId request, CancellationToken cancellationToken)
        {
            Response<List<HistoricalCallVM>> result = new();
            try
            {
                var dbContact = await _context.ScheduledCall.Where(x => x.Id == Guid.Parse(request.CallId))
                    .Select(x => x.Contact).FirstOrDefaultAsync();
                if (dbContact != null)
                {
                    var historicalCallIds = await _context.HistoricalCall.Where(x => x.ContactId == dbContact.Id).Select(x => x.Id).ToListAsync();
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Data = new List<HistoricalCallVM>();
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    foreach (var callId in historicalCallIds)
                    {
                        var historicalCall = await _context.HistoricalCall.FindAsync(callId);

                        result.Data.Add(new HistoricalCallVM
                        {
                            Id = historicalCall.Id,
                            ContactId = historicalCall.ContactId,
                            CallStatusId = historicalCall.CallStatusId,
                            CallTypeId = historicalCall.CallTypeId,
                            AssignToUserId = historicalCall.AssignToUserId,
                            AssignFromUserId = historicalCall.AssignFromUserId,
                            AssignToUserAt = historicalCall.AssignToUserAt,
                            ScheduledToUserId = historicalCall.ScheduledToUserId,
                            ScheduledByUserId = historicalCall.ScheduledByUserId,
                            ScheduledToUserAt = historicalCall.ScheduledToUserAt,
                            ScheduledCallDate = historicalCall.ScheduledCallDate,
                           
                            CallDuration = historicalCall.CallDuration,
                           
                            IsLatestCall = historicalCall.IsLatestCall,
                            LatestHistoricalCallId = historicalCall.LatestHistoricalCallId,
                           
                            CampaignId = historicalCall.CampaignId,
                            CategoryId = historicalCall.CategoryId,

                            CategoryName = historicalCall.Category?.NameAr,
                            CampaignName = historicalCall.Campaign?.NameAr,
                            CallStatusName = historicalCall.CallStatus?.NameAr,
                            AssignToUserName = historicalCall.AssignToUser?.PersonalInfo.FullNameAr,
                            CallTypeName = historicalCall.CallType?.NameAr,
                            CallDate = historicalCall.CallDate.ToString("yyyy/MM/dd hh:mm:ss"),

                            //SubNote = await _generalOperation.GetHistoricalCallResultCusTomFieldValue(historicalCall, "SubNoteId"),
                        });
                    }
                    result.Data = result.Data.OrderByDescending(x => x.CallDate).ToList();
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = true;
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
