using AutoMapper;
using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Commands
{
    using Domain.Entities.Identity;
    using Infrastructure.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class CreateNewRoleCommand : IRequest<Response<CreateNewRoleCommand>>
    {
        public Guid Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public List<Guid>? PermissionIds { get; set; }
    }
    public class CreateNewRoleCommandHandler : IRequestHandler<CreateNewRoleCommand, Response<CreateNewRoleCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

        public CreateNewRoleCommandHandler(IApplicationDbContext context, IMapper mapper , RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;

        }
        public async Task<Response<CreateNewRoleCommand>> Handle(CreateNewRoleCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewRoleCommand> result = new();
            var PermissionIdList = new List<Guid>();

            try
            {
                var role = new Domain.Entities.Identity.Role();
                role.NameAr = request.NameAr;
                role.Name = request.NameEn;
                var creationResult = await _roleManager.CreateAsync(role);
                
                 await _context.SaveChangesAsync(cancellationToken);

                foreach (var permissionId in request.PermissionIds!)
                {
                    _context.RolePermission.Add(new Domain.Entities.Identity.RolePermission
                    {
                        RoleId = role.Id,
                        PermissionId = permissionId

                    });
                    PermissionIdList.Add(permissionId);
                }
                await _context.SaveChangesAsync(cancellationToken);

                result.Data = request;
                result.Data.PermissionIds = PermissionIdList;
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
