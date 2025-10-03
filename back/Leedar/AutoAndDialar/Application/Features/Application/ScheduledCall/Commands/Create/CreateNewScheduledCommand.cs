using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall.Commands
{
    using Domain.Entities.Application;
    using Infrastructure.Interfaces;

    public class CreateNewScheduledCallCommand : IRequest<Response<CreateNewScheduledCallCommand>>
    {
        public Guid ContactId { get; set; }
        public Guid CallStatusId { get; set; }
        public Guid? CallTypeId { get; set; }
       
        public DateTime? AssignToUserAt { get; set; }
       
        public Guid? ScheduledByUserId { get; set; }
        public DateTime? ScheduledToUserAt { get; set; }
        public DateTime? ScheduledCallDate { get; set; }
      
        
        public Guid? LatestHistoricalCallId { get; set; }

        public Guid? CampaignId { get; set; }
        public Guid? CategoryId { get; set; }

    }
    public class CreateNewScheduledCallCommandHandler : IRequestHandler<CreateNewScheduledCallCommand, Response<CreateNewScheduledCallCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateNewScheduledCallCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<CreateNewScheduledCallCommand>> Handle(CreateNewScheduledCallCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewScheduledCallCommand> result = new();
            try
            {
                var mappedScheduledCall = _mapper.Map<ScheduledCall>(request);
                _context.ScheduledCall.Add(mappedScheduledCall);
                var dbObject = await _context.SaveChangesAsync(cancellationToken);
                result.Data = _mapper.Map<CreateNewScheduledCallCommand>(mappedScheduledCall);
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "",
                    Body = "",
                };
            }
            return result;
        }
    }
}
