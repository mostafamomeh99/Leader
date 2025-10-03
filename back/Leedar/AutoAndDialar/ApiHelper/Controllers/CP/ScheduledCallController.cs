using Application.Features.Application.Contact.Queries;

using Application.Features.Application.HistoricalCall.Queries;
using Application.Features.Application.ScheduledCall.Queries;
using Application.Features.Lookup.CategoryPath.Queries;
using Application.Features.Application.ScheduledCall.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Application.HistoricalCall.Commands.Create;
using Application.Features.Application.ScheduledCall.Commands.Create;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using Application.Features.Application.ScheduledCall.Commands.Update;



namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class ScheduledCallController : BaseController
    {
       

        [HttpPost("New")]
        public async Task<IActionResult> New([FromBody] CreateNewScheduledCallCommand model)
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

        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody] Application.Features.Application.ScheduledCall.Queries.GetByFilter model)
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
        //[HttpPost]
        //public async Task<IActionResult> ExportScheduledCallLog([FromBody] Application.Features.Log.ScheduledCallLog.Queries.ExportScheduledCallLog model)
        //{
        //    model.HttpRequest = Request;
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
       

        [HttpPost("GetStaticsByFilter")]
        public async Task<IActionResult> GetStaticsByFilter([FromBody] Application.Features.Application.ScheduledCall.Queries.GetStaticsByFilter model)
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
        [HttpPost("AssignCallToNewUser")]
        public async Task<IActionResult> AssignCallToNewUser([FromBody] AssignCallToNewUser model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost("AssignAllCallsToNewUser")]
        public async Task<IActionResult> AssignAllCallsToNewUser([FromBody] AssignAllCallsToNewUser model)
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
            if (HttpContext.Session.GetString("callId")!= null && HttpContext.Session.GetString("callId")== model.ScheduledCallId.ToString())
            {
                var responsee= new Shared.Wrappers.Response<string>();
                // Button already clicked, prevent further processing
                responsee.HttpStatusCode = HttpStatusCode.OK;
                responsee.Succeeded = true;
                responsee.Data = "This action has already been processed.";
               
                StatusCode((int)responsee.HttpStatusCode, responsee);
            }

            // Mark button as clicked
            HttpContext.Session.SetString("callId", model.ScheduledCallId.ToString());
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("DoOperationCommand")]
        public async Task<IActionResult> DoOperation([FromBody] DoOperationCommand model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

       
        [HttpPost("GetByFilterHistoricalCall")]
        public async Task<IActionResult> GetByFilterHistoricalCall([FromBody] Application.Features.Application.HistoricalCall.Queries.GetByFilter model)
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
        //[HttpPost("")]
        //public async Task<IActionResult> GetHistoricalByFilterForBankAgent([FromBody] Application.Features.Application.HistoricalCall.Queries.GetByFilter model)
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
    }
}
