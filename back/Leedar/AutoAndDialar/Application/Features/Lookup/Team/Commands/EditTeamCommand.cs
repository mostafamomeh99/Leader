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

    public class EditTeamCommand : IRequest<Response<EditTeamCommand>>
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid LeaderId { get; set; }
        public string LeaderName { get; set; }
        public bool StateCode { get; set; }
        public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand, Response<EditTeamCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public EditTeamCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<EditTeamCommand>> Handle(EditTeamCommand request, CancellationToken cancellationToken)
            {
                Response<EditTeamCommand> result = new();
                try
                {
                    // var team = _context.Team.Where(x => x.Id == request.Id);
                    // var mappedTeam = _mapper.Map<Team>(request);

                    // _context.Team.Update((Team)team);
                    // var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    // result.Data = _mapper.Map<EditTeamCommand>((Team)team);
                    // result.Succeeded = true;
                    // result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                    var mappedTeam = _mapper.Map<Team>(request);
                    _context.Team.Update(mappedTeam);
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