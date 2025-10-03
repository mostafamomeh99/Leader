using Application.Common.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall.Queries
{

    public class GetScheduledCallCountByCallStatus : IRequest<Response<ScheduledCallByCallStatusVM>>
    {


    }
    public class GetScheduledCallCountByCallStatusHandler : IRequestHandler<GetScheduledCallCountByCallStatus, Response<ScheduledCallByCallStatusVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPOMService _pomService;
        public GetScheduledCallCountByCallStatusHandler(IApplicationDbContext context, IMapper mapper, IPOMService pOMService)
        {
            _context = context;
            _mapper = mapper;
            _pomService = pOMService;
        }
        public async Task<Response<ScheduledCallByCallStatusVM>> Handle(GetScheduledCallCountByCallStatus request, CancellationToken cancellationToken)
        {
            Response<ScheduledCallByCallStatusVM> result = new();
            try
            {
                //var repeted = _context.ScheduledCall.Where(x => x.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer)
                //     .GroupBy(x => x.ContactId)
                //     .Select(x => new
                //     {
                //         x.Key,
                //         cCount = x.Count()
                //     }).Where(x => x.cCount > 1).ToList();

                //foreach (var item in repeted)
                //{
                //    var allCalls = _context.ScheduledCall.Where(x => x.ContactId == item.Key && x.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer)
                //         .OrderBy(x => x.CreatedOn).Select(x => x.Id).ToList();
                //    int i = 0;
                //    foreach (var callIdToDelete in allCalls)
                //    {
                //        if (i > 0)
                //        {
                //            var callToDeleteItem = await _context.ScheduledCall.FindAsync(callIdToDelete);
                //            var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(callToDeleteItem.Id.ToString(), callToDeleteItem?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
                //            if (isDeletedFromDialer)
                //            {
                //                _context.ScheduledCall.Remove(callToDeleteItem);
                //                await _context.SaveChangesAsync(cancellationToken);
                //            }
                //        }
                //        i++;
                //    }
                //}


                var grouppedQuary = await _context.ScheduledCall
                    .GroupBy(x => x.CallStatusId).Select(x => new
                    {
                        CallStatusId = x.Key,
                        Ccount = x.Count(),
                    }).ToListAsync();

                result.Data = new ScheduledCallByCallStatusVM
                {
                    Assigned = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.Assigned)?.Ccount ?? 0,
                    QueuedInSystem = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.QueuedInSystem)?.Ccount ?? 0,
                    ScheduledInSystem = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.ScheduledInSystem)?.Ccount ?? 0,
                    QueuedInDialer = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.QueuedInDialer)?.Ccount ?? 0,
                    ScheduledInDialer = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer)?.Ccount ?? 0,
                    NotSuccessByDialer = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.NotSuccessByDialer)?.Ccount ?? 0,
                    Completed = grouppedQuary.FirstOrDefault(x => x.CallStatusId == Shared.Struct.CallStatus.Completed)?.Ccount ?? 0,

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
                    Title = "",
                    Body = ""
                };
            }
            return result;
        }
    }
}
