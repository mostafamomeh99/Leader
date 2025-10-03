namespace Application.Features.Identity.Role.Queries
{
    using AutoMapper;
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using global::Application.Features.Identity.Role.Commands;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
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
    public class GetById : IRequest<Response<EditRoleCommand>>
    {
        public Guid Id { get; set; }

    }
    public class GetByIdHandler : IRequestHandler<GetById, Response<EditRoleCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;
        public GetByIdHandler(IApplicationDbContext context, IMapper mapper, RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;

        }
        public async Task<Response<EditRoleCommand>> Handle(GetById request, CancellationToken cancellationToken)
        {
            Response<EditRoleCommand> result = new();
            try
            {
                //var Role = await _context.Team.Where(x => x.Id == request.Id)
                //   .Include(x => x.Leader).FirstOrDefaultAsync();
                var role = await _context.Role.Where(x => x.Id == request.Id)
                    .Include(x => x.RolePermissions)
                    .FirstOrDefaultAsync();

                result.Data = _mapper.Map<EditRoleCommand>(role);

                result.Data.NameAr = role.NameAr;
                result.Data.PermissionIds = role.RolePermissions?.Select(x => x.PermissionId).ToList();






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