using Application.Common.Interfaces;
using Application.Features.Application.Contact.Commands;
using Application.Features.Application.Contact.Commands.Create;
using Application.Features.Application.Contact.Queries;

using Application.Features.Application.HistoricalCall.Queries;
using Application.Features.Application.ScheduledCall.Commands.Create;
using Application.Features.Lookup.CategoryPath.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : BaseController
    {
        
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult New()
        {
            return PartialView();
        }
        public IActionResult Edit(Guid id)
        {
            return PartialView(new EditContactCommand
            {
                Id = id
            });
        }
        public IActionResult View(Guid id)
        {
            ViewBag.ContactId = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> New([FromBody] CreateNewContactCommand model)
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

        public async Task<IActionResult> GetByFilter([FromBody] Application.Features.Application.Contact.Queries.GetByFilter model)
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
        public async Task<IActionResult> Edit([FromBody] EditContactCommand model)
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
        public async Task<IActionResult> GetById([FromBody] GetById model)
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
        public async Task<IActionResult> GetHistoricalCallsOfContactId([FromBody] GetHistoricalCallsOfContactId model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> GetPathOfCallId([FromBody] GetFullPath model)
        {

            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddScheduledCallAndStart([FromBody] SchedualCallsToContactBySpecificUserCommand model)
        //{
        //    var response = await Mediator.Send(model);
        //    return StatusCode((int)response.HttpStatusCode, response);
        //}
        
    }
}
