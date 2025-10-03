using Application.Common.Interfaces;
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

namespace Application.Features.Lookup.CategoryPath.Queries
{
    public class GetPathOfCallId : IRequest<Response<object>>
    {
        public Guid CallId { get; set; }
    }
    public class GetPathOfCallIdHandler : IRequestHandler<GetPathOfCallId, Response<object>>
    {
        private readonly IApplicationDbContext _context;
        public GetPathOfCallIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<object>> Handle(GetPathOfCallId request, CancellationToken cancellationToken)
        {
            Response<object> result = new();
            try
            {
                var pathId = await _context.ScheduledCall.Where(x => x.Id == request.CallId)
                      .Select(x => x.Category.CategoryPathId).FirstOrDefaultAsync();



                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
            }

            return result;
        }
    }
}
