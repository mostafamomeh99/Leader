namespace Application.Features.Lookup.Campaign.Queries
{
    using AutoMapper;
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using global::Application.Features.Lookup.Campaign.Commands;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.ViewModels;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetById : IRequest<Response<EditCampaignCommand>>
    {
        public Guid Id { get; set; }
       

    }
    public class GetByIdHandler : IRequestHandler<GetById, Response<EditCampaignCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdHandler(IApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<EditCampaignCommand>> Handle(GetById request, CancellationToken cancellationToken)
        {
            Response<EditCampaignCommand> result = new();
            try
            {
                var Campaign = await _context.Campaign.Where(x => x.Id == request.Id)
                   .Include(x => x.Priority).FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                result.Data = _mapper.Map<EditCampaignCommand>(Campaign);

                //result.Data = new EditCampaignCommand
                //{
                //    Id = Campaign.Id,
                //    NameAr = Campaign.NameAr,
                //    NameEn = Campaign.NameEn,
                //    PriorityId = Campaign.PriorityId,
                //    PriorityName = Campaign.Priority.DisplayName,
                    
                //};





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