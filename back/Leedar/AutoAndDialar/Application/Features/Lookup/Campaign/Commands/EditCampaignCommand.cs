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

namespace Application.Features.Lookup.Campaign.Commands
{
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;

    public class EditCampaignCommand : IRequest<Response<EditCampaignCommand>>
    {
        public Guid Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public Guid? PriorityId { get; set; }
        public string ?PriorityName { get; set; }
        public bool StateCode { get; set; }

        public class EditCampaignCommandHandler : IRequestHandler<EditCampaignCommand, Response<EditCampaignCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public EditCampaignCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<EditCampaignCommand>> Handle(EditCampaignCommand request, CancellationToken cancellationToken)
            {
                Response<EditCampaignCommand> result = new();
                try
                {
                   

                    var mappedCampaign = _mapper.Map<Campaign>(request);
                    _context.Campaign.Update(mappedCampaign);
                    var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    result.Data = request;
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

}