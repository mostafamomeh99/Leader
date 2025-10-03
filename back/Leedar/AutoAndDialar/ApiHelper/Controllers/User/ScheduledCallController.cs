using Application.Common.Interfaces;
using Application.Features.Application.Contact.Queries;
using Application.Features.Application.HistoricalCall.Commands.Create;
using Application.Features.Application.HistoricalCall.Queries;
using Application.Features.Application.ScheduledCall.Queries;
using Application.Features.Lookup.CategoryPath.Queries;

using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Controllers.User
{
    [ApiVersion("1.0")]
    public class ScheduledCallController : BaseController
    {
        IContextCurrentUserService _currentUserService;
        public ScheduledCallController(IContextCurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
       
      
        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] Application.Features.Application.ScheduledCall.Queries.GetByFilter model)
        {
            if (ModelState.IsValid)
            {   
               // DateTime date = DateTime.Now;

                model.AssignToUserId = _currentUserService.UserId;
                
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
       
        [HttpPost("GetScheduledCallCountByCallStatus")]
       
        public async Task<IActionResult> GetScheduledCallCountByCallStatus([FromBody] GetScheduledCallCountByCallStatus model)
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
        [HttpPost("GetScheduledCallById")]
        public async Task<IActionResult> GetScheduledCallById([FromBody] GetScheduledCallById model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost("GetPathOfCallId")]
        public async Task<IActionResult> GetPathOfCallId([FromBody] GetFullPath model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost("GetContactInfoOfCallId")]
        public async Task<IActionResult> GetContactInfoOfCallId([FromBody] GetContactInfoOfCallId model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
       
        [HttpPost("GetHistoricalCallsOfCallId")]
        public async Task<IActionResult> GetHistoricalCallsOfCallId([FromBody] GetHistoricalCallsOfCallId model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("SubmitCallResult")]
        public async Task<IActionResult> SubmitCallResult([FromBody] SubmitCallResultCommand model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        //[HttpPost]
        //public async Task<IActionResult> GetStaticsByFilter([FromBody] Application.Features.Application.ScheduledCall.Queries.GetFollowUpCountForUser model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await Mediator.Send(model);
        //        return StatusCode((int)response.HttpStatusCode, response);
        //    }
        //    else
        //    {
        //        string message = "";
        //        foreach (var value in ModelState.Values)
        //        {
        //            foreach (var error in value.Errors)
        //            {
        //                message += error.ErrorMessage + " \n ";
        //            }
        //        }
        //        return StatusCode((int)HttpStatusCode.BadRequest, message);
        //    }
        //}
        [HttpPost("GetByFilterHistoricalCall")]
        public async Task<IActionResult> GetByFilterHistoricalCall([FromBody] Application.Features.Application.HistoricalCall.Queries.GetByFilter model)
        {
            if (ModelState.IsValid)
            {
                model.AssignToUserId = _currentUserService.UserId.Value;
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
