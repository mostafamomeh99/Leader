namespace Application.Features.Lookup.Team.Queries
{
    using AutoMapper;
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using global::Application.Features.Lookup.Team.Commands;
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
    public class GetById : IRequest<Response<EditTeamCommand>>
    {
        public Guid Id { get; set; }

    }
    public class GetByIdHandler : IRequestHandler<GetById, Response<EditTeamCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<EditTeamCommand>> Handle(GetById request, CancellationToken cancellationToken)
        {
            Response<EditTeamCommand> result = new();
            try
            {
                var Team = await _context.Team.Where(x => x.Id == request.Id)
                   .Include(x => x.Leader).FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                result.Data = _mapper.Map<EditTeamCommand>(Team);
                //result.Data.LeaderName = Team.Leader.PersonalInfo.FullNameAr;
                //result.Data = new EditTeamCommand
                //{
                //    Id = Team.Id,
                //    NameAr = Team.NameAr,
                //    NameEn = Team.NameEn,
                //    LeaderId = Team.LeaderId,
                //    LeaderName = Team.Leader.PersonalInfo.FullNameAr,
                //    //TeamUsers = x.UserTeams.Where(y => y.User.StateCode == 1).ToDictionary(y => y.UserId, y => y.User.PersonalInfo.FirstNameAr),
                //    //TeamUsersCount = x.UserTeams.Count(y => y.User.StateCode == 1)


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