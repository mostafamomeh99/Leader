using Application.Features.Identity.User.Commands.Create;
using Application.Features.Identity.User.Commands.Update;
using Application.Features.Application.PersonalInfo.Commands.Update;
using Application.Features.Identity.User.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Identity.Role.Command.Create;
using Application.Features.Identity.Role.Command.Delete;

using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Shared.DTOs.SMS;
using Shared.Helpers;
using Infrastructure.Interfaces;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
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
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult GetUserStatistics()
        {
            return PartialView();
        }
        public IActionResult New(Guid typeId)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x=>x.Roles).ToList();
            
            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x=>x.RoleId).First()==Shared.Struct.Roles.Employee )
            {
                return RedirectToAction("Login");
            }
                if (typeId == Shared.Struct.RegistrationType.Application)
            {
                return PartialView("NewApplicationType");
            }
            else if (typeId == Shared.Struct.RegistrationType.Domain)
            {
                return PartialView("NewDomainType");
            }
            return PartialView();
        }
        public IActionResult Edit(Guid id)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x => x.Roles).ToList();

            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x => x.RoleId).First() == Shared.Struct.Roles.Employee)
            {
                return RedirectToAction("Login");
            }
            EditUserCommand EditTeam = new EditUserCommand { Id = id };

            return PartialView(EditTeam);
        }
        [HttpPost]
        public async Task<IActionResult> GetUser([FromBody] Application.Features.Identity.User.Queries.GetByFilter model)
        {
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }
        
        [HttpPost]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpForChangePassword model)
        {

            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }



       
        [HttpPost]
        public async Task<IActionResult> NewApplicationUser([FromBody] CreateNewUserCommand model)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x => x.Roles).ToList();

            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x => x.RoleId).First() == Shared.Struct.Roles.Employee)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
              //  model.RegistrationTypeId = Shared.Struct.RegistrationType.Application;
                var response = await Mediator.Send(model);
                if (response.Succeeded)
                {
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

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand model)
        {
            var currentUserRoles = _context.User.Where(x => x.Id == _currentUserService.UserId).Select(x => x.Roles).ToList();

            if (currentUserRoles.Count == 1 &&
                 currentUserRoles.FirstOrDefault().Select(x => x.RoleId).First() == Shared.Struct.Roles.Employee)
            {
                return RedirectToAction("Login");
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
        [HttpPost]
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

        
       

        [HttpPost]
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
