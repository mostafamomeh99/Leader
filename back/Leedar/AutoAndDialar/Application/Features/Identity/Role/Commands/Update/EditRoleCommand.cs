using Infrastructure.Interfaces;
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
    using Domain.Entities.Lookup;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;

    public class EditRoleCommand : IRequest<Response<EditRoleCommand>>
    {
        public Guid Id { get; set; }
        public string? NameAr { get; set; }
        public List<Guid>? PermissionIds { get; set; }


        public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, Response<EditRoleCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

            public EditRoleCommandHandler(IApplicationDbContext context, IMapper mapper , RoleManager<Domain.Entities.Identity.Role> roleManager)
            {
                _context = context;
                _mapper = mapper;
                _roleManager = roleManager;
            }
            public async Task<Response<EditRoleCommand>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
            {
                Response<EditRoleCommand> result = new();
                try
                {


                    var mappedRole = await _context.Role
                    .Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                    //await _roleManager.UpdateAsync(mappedRole);
                    //var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    //result.Data = request;
                    mappedRole!.NameAr = request.NameAr;
                    _context.Role.Update(mappedRole);
                    await _context.SaveChangesAsync(cancellationToken);

                    var dbRelatedToPermissionIds = mappedRole!.RolePermissions!.Select(x => x.PermissionId).ToList();
                    List<Guid> deferantPermissionIds = new();

                    if (request.PermissionIds != null)
                    {
                        deferantPermissionIds = deferantPermissionIds.GetDifference(request.PermissionIds, dbRelatedToPermissionIds).ToList();
                    }
                    if (deferantPermissionIds.Any())
                    {
                        foreach (var permissionId in dbRelatedToPermissionIds)
                        {
                            var dbItemItem = await _context.RolePermission.FindAsync(permissionId, mappedRole.Id);
                            if (dbItemItem != null)
                            {
                                _context.RolePermission.Remove(dbItemItem);
                                await _context.SaveChangesAsync(cancellationToken);
                            }
                        }
                        foreach (var permissionId in deferantPermissionIds)
                        {
                            await _context.RolePermission.AddAsync(new RolePermission
                            {
                                PermissionId = permissionId,
                                RoleId = mappedRole.Id
                            });
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                    }





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