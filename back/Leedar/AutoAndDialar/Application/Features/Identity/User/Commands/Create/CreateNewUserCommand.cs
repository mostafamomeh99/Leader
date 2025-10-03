using Infrastructure.Interfaces;
using Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Globalization;
using Shared.Wrappers;

namespace Application.Features.Identity.User.Commands.Create
{
    public class CreateNewUserCommand : IRequest<Response<CreateNewUserCommand>>
    {
        public Guid? Id { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }


        public string? Extension { get; set; }
        public string? IdentityNumber { get; set; }


        public string? FullNameAr { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Notes { get; set; }

        public Guid? DirectLeaderId { get; set; }

        public List<Guid>? RoleIds { get; set; }
        public List<Guid>? PermessionIds { get; set; }
        public List<Guid>? TeamIds { get; set; }
        public List<Guid>? CategoryIds { get; set; }

    }
    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand, Response<CreateNewUserCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

        public CreateNewUserCommandHandler(
            IContextCurrentUserService _currentUserService,
            IApplicationDbContext context,
            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response<CreateNewUserCommand>> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewUserCommand> result = new();
            Domain.Entities.Application.PersonalInfo personalInfo = new()
            {
                IdentityNumber = request.IdentityNumber,

                PhoneNumber = request.PhoneNumber,

                Email = request.Email,

                Notes = request.Notes,
                //MaritalStatus = request.MaritalStatus,
                CreatedOn = DateTime.Now,
                FullNameAr = request.FullNameAr
            };
            try
            {
                _context.PersonalInfo.Add(personalInfo);
                await _context.SaveChangesAsync(cancellationToken);



                var user = new Domain.Entities.Identity.User(personalInfo.Id, request.UserName!, request.Extension ?? "0", request.Email ?? "", personalInfo!.CreatedByUserId!.Value, request.DirectLeaderId);
                var creationResult = await _userManager.CreateAsync(user, request.Password!);
                if (!creationResult.Succeeded)
                {
                    _context.PersonalInfo.Remove(personalInfo);
                    throw new Exception("خطأ في تسجيل الحساب الجديد");
                }


                if (request.RoleIds != null)
                {
                    foreach (var item in request.RoleIds)
                    {
                        user.Roles?.Add(new IdentityUserRole<Guid>
                        {
                            RoleId = item,
                            UserId = user.Id
                        });
                    }
                }

                if (request.TeamIds != null)
                {
                    foreach (var TeamId in request.TeamIds)
                    {
                        _context.UserTeams.Add(new Domain.Entities.Identity.UserTeams
                        {
                            UserId = user.Id,
                            TeamId = TeamId
                        });
                    }

                }

                //foreach (var CategoryId in request.CategoryIds)
                //{
                //    _context.UserCategory.Add(new Domain.Entities.Identity.UserPermission
                //    {
                //        UserId = user.Id,
                //        CategoryId = CategoryId
                //    });
                //}
                if (request.PermessionIds != null)
                {
                    foreach (var PermessionId in request.PermessionIds)
                    {
                        _context.UserPermission.Add(new Domain.Entities.Identity.UserPermission
                        {
                            UserId = user.Id,
                            PermissionId = PermessionId
                        });
                    }

                }




                //  _context.User.Update(user);
                //  await _context.SaveChangesAsync(cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                request.Id = user.Id;
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
