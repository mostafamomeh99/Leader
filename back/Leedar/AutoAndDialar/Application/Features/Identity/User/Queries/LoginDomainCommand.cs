//using Application.Common.Interfaces;
//using AutoMapper;
//using Infrastructure.Interfaces;
//using Localization;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Shared.DTOs.LDAB;
//using Shared.Globalization;
//using Shared.Interfaces.Services;
//using Shared.Wrappers;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Net;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Identity.User.Queries
//{
//    public class LoginDomainCommand : IRequest<Response<CurrantUserViewModel>>
//    {
//        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
//        [Display(Name = "UserName", ResourceType = typeof(SharedResource))]
//        public string UserName { get; set; }
//        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
//        [Display(Name = "Password", ResourceType = typeof(SharedResource))]
//        public string Password { get; set; }
//    }
//    public class LoginDomainCommandHandler : IRequestHandler<LoginDomainCommand, Response<CurrantUserViewModel>>
//    {
//        private readonly IMapper _mapper;
//        private readonly IApplicationDbContext _context;
//        private readonly ILDABService _LDABService;
//        private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;

//        public LoginDomainCommandHandler(
//            IMapper mapper,
//            IApplicationDbContext context,
//            ILDABService LDABService,
//            SignInManager<Domain.Entities.Identity.User> signInManager)
//        {
//            _mapper = mapper;
//            _context = context;
//            _LDABService = LDABService;
//            _signInManager = signInManager;
//        }
//        public async Task<Response<CurrantUserViewModel>> Handle(LoginDomainCommand request, CancellationToken cancellationToken)
//        {
//            Response<CurrantUserViewModel> result = new();
//            try
//            {
//                //var isExisted = await _userManager.FindByNameAsync(request.UserName);
//                var mapModel = _mapper.Map<LoginModel>(request);
//                var verifiedInDomain = _LDABService.Login(mapModel);
//                if (verifiedInDomain.Succeeded)
//                {
//                    var userName = "uniithra_" + request.UserName;
//                    var userObj = await _context.User
//                         .Include(x => x.PersonalInfo.Nationality)
//                       .Include(x => x.UserPermissions)
//                       .Include(x => x.Roles)
//                       .FirstOrDefaultAsync(x => x.UserName == userName);

//                    if (userObj != null)
//                    {
//                        if (userObj.StateCode == 1)
//                        {
//                            await _signInManager.SignInAsync(userObj, true);
                            
//                            if (userObj.Roles.Any())
//                            {
//                                result.HttpStatusCode = HttpStatusCode.OK;
//                                result.Succeeded = true;

//                                result.Data = new CurrantUserViewModel
//                                {
//                                    BirthdayDate = userObj.PersonalInfo.DateOfBirth,
//                                    FullName = userObj.PersonalInfo.FullName,
//                                    GenderString = userObj.PersonalInfo.Gender?.NameAr,
//                                    BirthdayDateString = userObj.PersonalInfo.DateOfBirth?.ToString("yyyy/MM/dd"),
//                                    Id = userObj.Id,
//                                    IdentityNumber = userObj.PersonalInfo.IdentityNumber,
//                                    PhoneNumber = userObj.PersonalInfo.PhoneNumber,
//                                    Nationality = CultureHelper.IsArabic ? userObj.PersonalInfo.Nationality?.NameAr : userObj.PersonalInfo.Nationality?.NameEn,
//                                    Email = userObj.UserName,
//                                    RegistrationTypeId = userObj.RegistrationTypeId,
//                                    RoleIds = userObj.Roles.Select(x => x.RoleId).ToList(),
//                                };
//                            }
//                            else
//                            {
//                                result.HttpStatusCode = HttpStatusCode.OK;
//                                result.Succeeded = false;
//                                result.Message = new NotificationMessage
//                                {
//                                    Title = SharedResource.UserHasNoRole,
//                                };
//                            }
//                        }
//                        else
//                        {

//                        }
//                    }
//                    else
//                    {
//                    }
//                }
//                else
//                {

//                }
//            }
//            catch (Exception ex)
//            {

//                throw;
//            }
//            return result;
//        }
//    }
//}
