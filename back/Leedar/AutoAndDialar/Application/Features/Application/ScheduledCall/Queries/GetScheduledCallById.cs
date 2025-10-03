using Application.Common.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall.Queries
{
    public class GetScheduledCallById : IRequest<Response<ScheduledCallVM>>
    {
        public string CallId { get; set; }
    }
    public class GetScheduledCallByIdHandler : IRequestHandler<GetScheduledCallById, Response<ScheduledCallVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetScheduledCallByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<ScheduledCallVM>> Handle(GetScheduledCallById request, CancellationToken cancellationToken)
        {
            Response<ScheduledCallVM> result = new();
            try
            {
                var dbScheduledCall = await _context.ScheduledCall.Where(x => x.Id == Guid.Parse(request.CallId)).FirstOrDefaultAsync();
                if (dbScheduledCall != null)
                {
                    result.Data = _mapper.Map<ScheduledCallVM>(dbScheduledCall);
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = true;
                }
                else
                {
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = false;
                    result.Message = new NotificationMessage
                    {
                        Title = "خطأ !!",
                        Body = "معرف المكالمة غير موجود",
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
