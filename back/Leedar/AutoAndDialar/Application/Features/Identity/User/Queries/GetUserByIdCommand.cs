using Infrastructure.Interfaces;
using Application.Features.Identity.User.Commands.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Queries
{
    public class GetUserByIdCommand : IRequest<Response<EditUserCommand>>
    {
        public Guid UserId { get; set; }
    }
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, Response<EditUserCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdCommandHandler(
            IApplicationDbContext context,
            UserManager<Domain.Entities.Identity.User> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<EditUserCommand>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            Response<EditUserCommand> result = new();
            try
            {
                //var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                var user = await _context.User.Where(x => x.Id == request.UserId)
                    .Include(x => x.PersonalInfo)
                    .Include(x=>x.UserPermissions)
                    .Include(x=>x.Roles)
                    .FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                DateTimeFormatInfo ukDtfi = new CultureInfo("en-GB", false).DateTimeFormat;
                result.Data = _mapper.Map<EditUserCommand>(user.PersonalInfo);
                result.Data.UserName = user.UserName;
               // result.Data.DirectLeaderId = user.DirectLeaderId;
               // result.Data.EmployeeNumber = user.EmployeeNumber;
               // result.Data.RegistrationTypeId = user.RegistrationTypeId;
               // result.Data.Extension = user.Extension;
                result.Data.RoleIds = user.Roles?.Select(x => x.RoleId).ToList();
                result.Data.PermissionIds = user.UserPermissions?.Select(x => x.PermissionId).ToList();
               // result.Data.TeamIds = user.UserTeams?.Select(x => x.TeamId).ToList();
              //  result.Data.CategoryIds = user.UserCategorys?.Select(x => x.CategoryId).ToList();
                //if (result.Data.RegistrationTypeId == Shared.Struct.RegistrationType.Domain)
                //{
                //    result.Data.UserName = result.Data.UserName.Split("domain_")[1]?.Split("@")[0];
                //}
                //result.Data = new EditUserCommand

                //{
                //FirstName = user.PersonalInfo.FirstName,
                //SecondName = user.PersonalInfo.FatherName,
                //ThirdName = user.PersonalInfo.GrandFatherName,
                //LastName = user.PersonalInfo.FamilyName,

                //BirthdayDate = user.PersonalInfo.BirthdayDate,
                //FullName = user.PersonalInfo.FullName,
                //IsMale = user.PersonalInfo.IsMale,
                //GenderString = user.PersonalInfo.IsMale ? SharedResource.Male : SharedResource.Female,
                //BirthdayDateString = user.PersonalInfo.BirthdayDate.ToString("yyyy/MM/dd", ukDtfi),
                //Id = user.Id,
                //IdentityNumber = user.PersonalInfo.IdentityNumber,
                //MobileNumber = user.PersonalInfo.MobileNumber,
                //Nationality = CultureHelper.IsArabic ? user.PersonalInfo.Nationality?.NameAr : user.PersonalInfo.Nationality?.NameEn,
                //Email = user.UserName,
                //Culture = user.Culture

            }
            catch (Exception ex)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
            }
            return result;
        }
    }
}
