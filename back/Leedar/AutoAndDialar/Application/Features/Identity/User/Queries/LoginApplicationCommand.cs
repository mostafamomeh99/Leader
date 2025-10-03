using Application.Common.Interfaces;
using Infrastructure.Interfaces;
using Localization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Queries
{
    public class LoginApplicationCommand : IRequest<Response<CurrantUserViewModel>>
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
        [Display(Name = "UserName", ResourceType = typeof(SharedResource))]
        [NotNull]
        public string UserName { get; set; }= string.Empty;
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
        [Display(Name = "Password", ResourceType = typeof(SharedResource))]
        public string Password { get; set; }=string.Empty;
    }
    public class LoginApplicationCommandHandler : IRequestHandler<LoginApplicationCommand, Response<CurrantUserViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;
        private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginApplicationCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IApplicationDbContext context,
            UserManager<Domain.Entities.Identity.User> userManager,
            RoleManager<Domain.Entities.Identity.Role> roleManager,
            SignInManager<Domain.Entities.Identity.User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response<CurrantUserViewModel>> Handle(LoginApplicationCommand request, CancellationToken cancellationToken)
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
                            
                            .Include(x => x.UserPermissions)
                            .Include(x => x.Roles)
                            .FirstOrDefaultAsync();
                            //var userRoles = await _userManager.GetRolesAsync(isExisted);
                            if(isExisted != null)
                            if (isExisted.Roles != null)
                            {
                                result.HttpStatusCode = HttpStatusCode.OK;
                                result.Succeeded = true;

                                result.Data = new CurrantUserViewModel
                                {
                                  //  BirthdayDate = isExisted.PersonalInfo.DateOfBirth,
                                    FullName = isExisted.PersonalInfo?.FullNameAr,
                                    Id = isExisted.Id,
                                    IdentityNumber = isExisted.PersonalInfo?.IdentityNumber,
                                    PhoneNumber = isExisted.PersonalInfo?.PhoneNumber,
                                   // Nationality = CultureHelper.IsArabic ? isExisted.PersonalInfo.Nationality?.NameAr : isExisted.PersonalInfo.Nationality?.NameEn,
                                    Email = isExisted.UserName,
                                   // RegistrationTypeId = isExisted.RegistrationTypeId,
                                    RoleIds = isExisted.Roles.Select(x => x.RoleId).ToList(),
                                };
                                //_httpContextAccessor.HttpContext
                                //HttpContext.Current.Response.Cookies.Add(cookie);
                                //_httpContextAccessor.HttpContext.User.AddIdentity(new System.Security.Claims.ClaimsIdentity
                                //{
                                //    Name = "",
                                //    NameClaimType =""
                                //}) = "test";
                                //_httpContextAccessor.HttpContext.Items.Add("CurrantUser", result.Data);
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
