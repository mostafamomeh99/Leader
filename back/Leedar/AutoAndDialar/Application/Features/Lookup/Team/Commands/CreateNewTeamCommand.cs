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

namespace Application.Features.Lookup.Team.Commands
{
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;

    public class CreateNewTeamCommand : IRequest<Response<CreateNewTeamCommand>>
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid LeaderId { get; set; }
    }
    public class CreateNewTeamCommandHandler : IRequestHandler<CreateNewTeamCommand, Response<CreateNewTeamCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateNewTeamCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<CreateNewTeamCommand>> Handle(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewTeamCommand> result = new();
            try
            {
                var mappedTeam = _mapper.Map<Team>(request);
                _context.Team.Add(mappedTeam);
                var dbObject = await _context.SaveChangesAsync(cancellationToken);
                result.Data = _mapper.Map<CreateNewTeamCommand>(mappedTeam);
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
