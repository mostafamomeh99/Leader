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

namespace Application.Features.Identity.Role.Command.Create
{
    public class AddUserRoleCommand : IRequest<Response<bool>>
    {
        public Guid UserId { get; set; }
        public List<Guid>? RoleIds { get; set; }
    }
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, Response<bool>>
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

        public AddUserRoleCommandHandler(

            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response<bool>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var dbUser = await _userManager.FindByIdAsync(request.UserId.ToString());
                List<string> roleNames = new List<string>();
                foreach (var item in request.RoleIds!)
                {
                    var roleObj = await _roleManager.FindByIdAsync(item.ToString());
                    roleNames.Add(roleObj?.Name?? "");
                }
                roleNames = roleNames.Distinct().ToList();
                var resultasd = await _userManager.AddToRolesAsync(dbUser, roleNames);

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
