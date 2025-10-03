using Application.Features.Lookup.Team.Commands;
using Application.Features.Lookup.Team.Queries;

using AutoMapper;
using Domain.Entities.Lookup;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class TeamController : BaseController
    {
       
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult New()
        {
            return PartialView();
        }
        public IActionResult Edit( Guid Id)
        {
             EditTeamCommand EditTeam = new EditTeamCommand { Id = Id };

            //var mappedTeam = _mapper.Map<Team>(EditTeam);
            //EditTeam = _mapper.Map<EditTeamCommand>(mappedTeam);
            //var EditTeam = _mapper.Map<EditTeamCommand>(mappedTeam);
           


            return PartialView(EditTeam);
        }
        [HttpPost]
        public async Task<IActionResult> GetByFilter([FromBody] GetByFilter model)
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
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] Guid Id)
        {
            if (ModelState.IsValid)
            {
                var response = await Mediator.Send(new GetById {
                    Id = Id
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
        public async Task<IActionResult> New([FromBody] CreateNewTeamCommand model)
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
       
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditTeamCommand model)
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
