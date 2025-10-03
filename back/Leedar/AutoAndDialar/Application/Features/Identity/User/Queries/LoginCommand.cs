using Infrastructure.Interfaces;
using Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Queries
{
    public class LoginCommand : IRequest<Response<CurrantUserViewModel>>
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
        [Display(Name = "UserName", ResourceType = typeof(SharedResource))]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
        [Display(Name = "Password", ResourceType = typeof(SharedResource))]
        public string Password { get; set; }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<CurrantUserViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;
        private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;

        public LoginCommandHandler(
            IApplicationDbContext context,
            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager,
            SignInManager<Domain.Entities.Identity.User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<Response<CurrantUserViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Response<CurrantUserViewModel> result = new();
            try
            {
                var isExisted = await _userManager
                    .FindByNameAsync(request.UserName);
                if (isExisted != null)
                {
                    if (isExisted.StateCode == 1)
                    {
                        var resultSignIn = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, lockoutOnFailure: false);

                        if (!resultSignIn.Succeeded)
                        {
                            result.Message = new NotificationMessage
                            {
                                Title = SharedResource.UsernameOrPasswordIsNotValid,
                            };
                        }
                        else
                        {
                       isExisted = await _context.User.Where(x => x.Id == isExisted.Id)
                       //.Include(x => x.PersonalInfo.Nationality)
                       .Include(x => x.UserPermissions)
                       .Include(x => x.Roles)
                       .FirstOrDefaultAsync();
                            //var userRoles = await _userManager.GetRolesAsync(isExisted);
                            if (isExisted.Roles.Any())
                            {
                                result.HttpStatusCode = HttpStatusCode.OK;
                                result.Succeeded = true;

                                result.Data = new CurrantUserViewModel
                                {
                                    //BirthdayDate = isExisted.PersonalInfo.DateOfBirthDate,
                                    FullName = isExisted.PersonalInfo.FullNameAr,
                                    //IsMale = isExisted.PersonalInfo.IsMale,
                                    //GenderName = isExisted.PersonalInfo.IsMale == true ? SharedResource.Male : SharedResource.Female,
                                    //BirthdayString = isExisted.PersonalInfo.DateOfBirthDate?.ToString("yyyy/MM/dd"),
                                    Id = isExisted.Id,
                                    IdentityNumber = isExisted.PersonalInfo.IdentityNumber,
                                    PhoneNumber = isExisted.PersonalInfo.PhoneNumber,
                                    //NationalityName = CultureHelper.IsArabic ? isExisted.PersonalInfo.Nationality?.NameAr : isExisted.PersonalInfo.Nationality?.NameEn,
                                    Email = isExisted.UserName,
                                    //RegistrationTypeId = isExisted.RegistrationTypeId,
                                    RoleIds = isExisted.Roles.Select(x => x.RoleId).ToList(),
                                };
                            }
                            else
                            {
                                result.HttpStatusCode = HttpStatusCode.OK;
                                result.Succeeded = false;
                                result.Message = new NotificationMessage
                                {
                                    Title = SharedResource.UserHasNoRole,
                                };
                            }
                         
                        }
                    }
                    else
                    {
                        result.Message = new NotificationMessage
                        {
                            Title = SharedResource.AccountIsDisabled,
                        };
                    }
                }
                else
                {
                    result.Message = new NotificationMessage
                    {
                        Title = SharedResource.AccountIsNotRegistered,
                    };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
