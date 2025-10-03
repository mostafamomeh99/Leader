using Application.Common.Interfaces;
using AutoMapper;
using Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Extensions;
using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Commands.Update
{
    using Domain.Entities.Application;
    using Domain.Entities.Identity;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class EditUserCommand : IRequest<Response<EditUserCommand>>
    {
        public Guid Id { get; set; }
       
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
       

        public string? IdentityNumber { get; set; }
      

        public string? FullNameAr { get; set; }
        //public string FullNameEn { get; set; }
        public string? PhoneNumber { get; set; }
      
        public string? Email { get; set; }
       
        public string? Notes { get; set; }
        


        public List<Guid>? RoleIds { get; set; }

        public List<Guid>? PermissionIds { get; set; }
        

    }
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Response<EditUserCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;
        private readonly IMapper _mapper;

        public EditUserCommandHandler(
            IContextCurrentUserService _currentUserService,
            IApplicationDbContext context,
            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<Response<EditUserCommand>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            Response<EditUserCommand> result = new();
            try
            {

                //var oldUser = await _userManager.FindByIdAsync(request.Id);
                //var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                //var oldRoleName = _context.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;

                var dbUser = await _context.User
                    //.AsNoTrackingWithIdentityResolution()
                    .Where(x => x.Id == request.Id).FirstOrDefaultAsync();
              
                if (dbUser != null)
                {
                  //  var existedRoleIds = dbUser.Roles!.Select(x => x.RoleId).ToList();

                   

                    _context.User.Update(dbUser);
                    await _context.SaveChangesAsync(cancellationToken);
                    //_context.User.AsNoTrackingWithIdentityResolution();
                }


                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;





                var dbRelatedToPermissionIds = dbUser!.UserPermissions!.Select(x => x.PermissionId).ToList();
                List<Guid> deferantPermissionIds = new();
                if (request.PermissionIds != null)
                {
                    deferantPermissionIds.GetDifference(request.PermissionIds, dbRelatedToPermissionIds);
                }
                if (deferantPermissionIds.Any())
                {
                    foreach (var permissionId in dbRelatedToPermissionIds)
                    {
                        var dbItemItem = await _context.UserPermission.FindAsync(permissionId, dbUser.Id);
                        if (dbItemItem != null)
                        {
                            _context.UserPermission.Remove(dbItemItem);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                    }
                    foreach (var permissionId in deferantPermissionIds)
                    {
                        await _context.UserPermission.AddAsync(new UserPermission
                        {
                            PermissionId = permissionId,
                            UserId = dbUser.Id
                        });
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }




                //_context.User.Update(dbUser).State = EntityState.Detached;
                //await _context.SaveChangesAsync(cancellationToken);
                //List<string> roleNames = new List<string>();

                //foreach (var item in existedRoleIds)
                //{
                //    var roleObj = await _roleManager.FindByIdAsync(item.ToString());
                //    roleNames.Add(roleObj.Name);
                //}
                //roleNames = roleNames.Distinct().ToList();
                //await _userManager.RemoveFromRolesAsync(dbUser, roleNames);
                //var rolesToDelete = dbUser.Roles.Where(x => existedRoleIds.Contains(x.RoleId)).ToList();
                ////dbUser.Roles.Remove(new IdentityUserRole<Guid>
                ////{
                ////    RoleId = item,
                ////    UserId = dbUser.Id
                ////});
                ////_context.User.Update(dbUser);
                ////await _context.SaveChangesAsync(cancellationToken);
                //_context.User.Update(dbUser).DetectChanges();

                //foreach (var item in request.RoleIds)
                //{
                //    var roleObj = await _roleManager.FindByIdAsync(item.ToString());
                //    roleNames.Add(roleObj.Name);
                //}
                //roleNames = roleNames.Distinct().ToList();
                //await _userManager.AddToRolesAsync(dbUser, roleNames);



                //dbUser.Roles.Add(new IdentityUserRole<Guid>
                //{
                //    RoleId = item,
                //    UserId = dbUser.Id
                //});
                //_context.User.Update(dbUser);
                //await _context.SaveChangesAsync(cancellationToken);
                _context.User.Update(dbUser).DetectChanges();



                //request.Id = user.Id;
                result.Data = request;
                
                

                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
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
