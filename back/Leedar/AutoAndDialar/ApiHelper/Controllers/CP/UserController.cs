using Application.Features.Application.PersonalInfo.Commands.Update;
using Application.Features.Identity.Role.Command.Create;
using Application.Features.Identity.Role.Command.Delete;
using Application.Features.Identity.User.Commands.Create;
using Application.Features.Identity.User.Commands.Update;
using Application.Features.Identity.User.Queries;
using AutoMapper;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;



namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        IContextCurrentUserService _currentUserService;
        IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IContextCurrentUserService currentUserService, IApplicationDbContext context)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _context = context;
        }

        //public IActionResult New(Guid typeId)
        //{
        //    var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x=>x.Roles).ToList();

        //    if (currentUserRoles.Count == 1 &&
        //         currentUserRoles.FirstOrDefault().Select(x=>x.RoleId).First()==Shared.Struct.Roles.Employee )
        //    {
        //        return RedirectToAction("Login");
        //    }
        //        if (typeId == Shared.Struct.RegistrationType.Application)
        //    {
        //        return PartialView("NewApplicationType");
        //    }
        //    else if (typeId == Shared.Struct.RegistrationType.Domain)
        //    {
        //        return PartialView("NewDomainType");
        //    }
        //    return PartialView();
        //}

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] Application.Features.Identity.User.Queries.GetByFilter model)
        {
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }

        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpForChangePassword model)
        {

            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }




        [HttpPost("NewApplicationUser")]
        public async Task<IActionResult> NewApplicationUser([FromBody] CreateNewUserCommand model)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x => x.Roles).ToList();

            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x => x.RoleId).First() == Shared.Struct.Roles.Employee)
            {
                string message = "No Permission";

                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
            if (ModelState.IsValid)
            {
                //  model.RegistrationTypeId = Shared.Struct.RegistrationType.Application;
                var response = await Mediator.Send(model);
                if (response.Succeeded)
                {
                    await Mediator.Send(new AddUserRoleCommand
                    {
                        UserId = new Guid(),
                        RoleIds = model.RoleIds
                    });
                }
                return StatusCode((int)response.HttpStatusCode, response);
            }
            else
            {
                string message = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        message += error.ErrorMessage + " \n ";
                    }
                }
                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand model)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x => x.Roles).ToList();

            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x => x.RoleId).First() == Shared.Struct.Roles.Employee)
            {
                string message = "No Permission";

                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
            if (ModelState.IsValid)
            {
                var responsePersonalInfo = await Mediator.Send(_mapper.Map<EditPersonalInfoCommand>(model));
                var response = await Mediator.Send(model);
                if (response.Succeeded)
                {
                    await Mediator.Send(new DeleteUserRoleCommand
                    {
                        UserId = response.Data.Id,
                    });
                    await Mediator.Send(new AddUserRoleCommand
                    {
                        UserId = response.Data.Id,
                        RoleIds = model.RoleIds
                    });
                }
                return StatusCode((int)response.HttpStatusCode, response);
            }
            else
            {
                string message = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        message += error.ErrorMessage + " \n ";
                    }
                }
                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
        }
        [HttpPost("GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] Guid Id)
        {
            if (ModelState.IsValid)
            {
                var response = await Mediator.Send(new GetUserByIdCommand
                {
                    UserId = Id
                });

                return StatusCode((int)response.HttpStatusCode, response);
            }
            else
            {
                string message = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        message += error.ErrorMessage + " \n ";
                    }
                }
                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
        }




        [HttpPost("ResetPasswordHard")]
        public async Task<IActionResult> ResetPasswordHard([FromBody] ResetPasswordHardCommand model)
        {
            if (ModelState.IsValid)
            {
                var response = await Mediator.Send(model);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            else
            {
                string message = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        message += error.ErrorMessage + " \n ";
                    }
                }
                return StatusCode((int)HttpStatusCode.BadRequest, message);
            }
        }


    }
}
