//using Application.Common.Interfaces;
//using Infrastructure.Interfaces;
//using Localization;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Shared.Extensions;
//using Shared.Globalization;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Identity.User.Commands.Create
//{
//    public class CreateNewDomainUserCommand : IRequest<Response<CreateNewDomainUserCommand>>
//    {
//        public Guid Id { get; set; }
//        public Guid RegistrationTypeId { get; set; }
//        public string EmployeeNumber { get; set; }
//        public string Extension { get; set; }
//        public string UserName { get; set; }
//        public Guid? DirectLeaderId { get; set; }

//        public string IdentityNumber { get; set; }
//        public string FirstNameAr { get; set; }
//        public string SecondNameAr { get; set; }
//        public string ThirdNameAr { get; set; }
//        public string LastNameAr { get; set; }

//        public string FirstNameEn { get; set; }
//        public string SecondNameEn { get; set; }
//        public string ThirdNameEn { get; set; }
//        public string LastNameEn { get; set; }

//        //public string FullNameAr { get; set; }
//        //public string FullNameEn { get; set; }
//        public string PhoneNumber { get; set; }
//        public string PhoneNumber2 { get; set; }
//        public string Email { get; set; }
//        public string Age { get; set; }
//        public string DateOfBirth { get; set; }
//        public string JobDescription { get; set; }
//        public string Notes { get; set; }
//        public string MaritalStatus { get; set; }


//        public List<Guid> RoleIds { get; set; }
//        public List<Guid> PermessionIds { get; set; }
//        public List<Guid> TeamIds { get; set; }
//    }
//    public class CreateNewDomainUserCommandHandler : IRequestHandler<CreateNewDomainUserCommand, Response<CreateNewDomainUserCommand>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
//        private readonly RoleManager<Domain.Entities.Identity.Role> _roleManager;

//        public CreateNewDomainUserCommandHandler(
//            IContextCurrentUserService _currentUserService,
//            IApplicationDbContext context,
//            UserManager<Domain.Entities.Identity.User> userManager,
//            RoleManager<Domain.Entities.Identity.Role> roleManager)
//        {
//            _context = context;
//            _userManager = userManager;
//            _roleManager = roleManager;
//        }

//        public async Task<Response<CreateNewDomainUserCommand>> Handle(CreateNewDomainUserCommand request, CancellationToken cancellationToken)
//        {
//            Response<CreateNewDomainUserCommand> result = new();
//            Domain.Entities.Application.PersonalInfo personalInfo = new()
//            {
//                IdentityNumber = request.IdentityNumber,
//                FirstNameAr = request.FirstNameAr,
//                SecondNameAr = request.SecondNameAr,
//                ThirdNameAr = request.ThirdNameAr,
//                LastNameAr = request.LastNameAr,
//                FirstNameEn = request.FirstNameEn,
//                SecondNameEn = request.SecondNameEn,
//                ThirdNameEn = request.ThirdNameEn,
//                LastNameEn = request.LastNameEn,
//                PhoneNumber = request.PhoneNumber,
//                PhoneNumber2 = request.PhoneNumber2,
//                Email = request.Email,
//                Age = request.Age,
//                //DateOfBirth = request.DateOfBirth,
//                JobDescription = request.JobDescription,
//                Notes = request.Notes,
//                //MaritalStatus = request.MaritalStatus,

//                FullNameAr = request.FirstNameAr + " " + request.SecondNameAr + " " + request.ThirdNameAr + " " + request.LastNameAr,
//                FullNameEn = request.FirstNameEn + " " + request.SecondNameEn + " " + request.ThirdNameEn + " " + request.LastNameEn
//            };
//            try
//            {
//                _context.PersonalInfo.Add(personalInfo);
//                await _context.SaveChangesAsync(cancellationToken);


//                request.UserName = "Domain_" + request.UserName;
//                var Password = request.UserName + "P@ssw0rd@123";

//                var user = new Domain.Entities.Identity.User(personalInfo.Id, request.UserName, Shared.Struct.RegistrationType.Domain, request.Extension, request.Email, personalInfo.CreatedByUserId.Value);
//                var creationResult = await _userManager.CreateAsync(user, Password);
//                if (!creationResult.Succeeded)
//                {
//                    _context.PersonalInfo.Remove(personalInfo);
//                    throw new Exception("خطأ في تسجيل الحساب الجديد");
//                }
//                //foreach (var item in request.RoleIds)
//                //{
//                //    user.Roles.Add(new IdentityUserRole<Guid>
//                //    {
//                //        RoleId = item,
//                //        UserId = user.Id
//                //    });
//                //}
//                //_context.User.Update(user);
//                //await _context.SaveChangesAsync(cancellationToken);

//                if (request.PermessionIds != null)
//                {
//                    foreach (var permessionId in request.PermessionIds)
//                    {
//                        _context.UserPermission.Add(new Domain.Entities.Identity.UserPermission
//                        {
//                            UserId = user.Id,
//                            PermissionId = permessionId
//                        });
//                    }
//                }
//                //if (request.TeamIds != null)
//                //{
//                //    foreach (var TeamId in request.TeamIds)
//                //    {
//                //        _context.UserTeams.Add(new Domain.Entities.Identity.UserTeams
//                //        {
//                //            UserId = user.Id,
//                //            TeamId = TeamId
//                //        });
//                //    }
//                //}


               
//                await _context.SaveChangesAsync(cancellationToken);

//                request.Id = user.Id;
//                result.Data = request;
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                result.Succeeded = true;
//            }
//            catch (Exception ex)
//            {

//                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
//                result.Exception = ex;
//                result.Message = new NotificationMessage
//                {
//                    Title = SharedResource.FailedOperation,
//                    Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.Users}" :
//                     $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.Users}",
//                };
//            }

//            return result;
//        }
//    }
//}
