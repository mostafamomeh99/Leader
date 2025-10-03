using Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Command.Delete
{
    public class DeleteUserRoleCommand : IRequest<Response<bool>>
    {
        public Guid UserId { get; set; }
        public List<Guid>? RoleIds { get; set; }
    }
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, Response<bool>>
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

        public DeleteUserRoleCommandHandler(

            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response<bool>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var dbUser = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (dbUser != null)
                {
                    List<string> roleNames = new List<string>();
                    if (request.RoleIds == null || request.RoleIds.Count == 0)
                    {
                        request.RoleIds = dbUser?.Roles?.Select(x => x.RoleId).ToList();
                    }
                    foreach (var item in request.RoleIds!)
                    {
                        var roleObj = await _roleManager.FindByIdAsync(item.ToString());
                        IdentityResult deletionResult = await _userManager.RemoveFromRoleAsync(dbUser, roleObj.Name);
                        roleNames.Add(roleObj.Name);
                    }
                }
                
                //foreach (var roleName in deleteList)
                //{
                //    IdentityResult deletionResult = await _userManager.RemoveFromRolesAsync(dbUser, roleNames);
                //}
                //roleNames = roleNames.Distinct().ToList();
                //await _userManager.RemoveFromRolesAsync(dbUser, roleNames);

                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {

                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = SharedResource.FailedOperation,
                    Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.Users}" :
                     $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.Users}",
                };
            }

            return result;
        }
    }
}
