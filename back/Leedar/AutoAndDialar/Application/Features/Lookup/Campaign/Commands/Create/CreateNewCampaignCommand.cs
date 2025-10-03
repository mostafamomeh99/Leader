using Application.Common.Interfaces;
namespace Application.Features.Lookup.Campaign.Commands.Create
{
    using MediatR;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Entities.Lookup;

    using System.Threading;
    using AutoMapper;
    using Infrastructure.Interfaces;

    public class CreateNewCampaignCommand : IRequest<Response<CreateNewCampaignCommand>>
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; } = "default";
        public string NameEn { get; set; } = "default";
        public Guid? PriorityId { get; set; }
    }
    public class CreateNewCampaignCommandHandler : IRequestHandler<CreateNewCampaignCommand, Response<CreateNewCampaignCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateNewCampaignCommandHandler(IApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<CreateNewCampaignCommand>> Handle(CreateNewCampaignCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewCampaignCommand> result = new();
            try
            {
                var mappedCampaign = _mapper.Map<Campaign>(request);
                _context.Campaign.Add(mappedCampaign);
                var dbObject = await _context.SaveChangesAsync(cancellationToken);
                result.Data = _mapper.Map<CreateNewCampaignCommand>(mappedCampaign);
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "مشكلة في إنشاء حملة جديدة",
                    Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                };
            }
            return result;
        }
    }
}
