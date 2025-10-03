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

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class ScheduledCallController : BaseController
    {
        public IActionResult Index(Guid? CallStatusId, int? PageSize, int? PageIndex)
        {
            ViewBag.CallStatusId = CallStatusId;
            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = PageIndex;
            return PartialView();
        }
        public async Task<IActionResult> View(Guid callId)
        {

            var response = await Mediator.Send(new Application.Features.Application.ScheduledCall.Queries.GetScheduledCallById
            {
                CallId = callId,
            });
            if (response.Succeeded)
            {
                ViewBag.CallId = callId;
                ViewBag.CallCategoryId = response.Data.CategoryId;
            }
            else
            {
                var Info = await Mediator.Send(new Application.Features.Application.HistoricalCall.Queries.GetInfoOfScheduledCallId
                {
                    ScheduledCallId =callId,
                });

                if (Info.Succeeded)
                {
                    ViewBag.HistoricalCallVM = Info.Data;
                }
            }
            return PartialView();
        }
        public async Task<IActionResult> PredictiveCall(Guid callId, string extention)
        {

            var response = await Mediator.Send(new Application.Features.Application.ScheduledCall.Commands.Update.AssignCallToCurrentUserCommand
            {
                ScheduledCallId = callId,
                AssignFromUserId = Shared.Struct.StaticUser.POMApplicationUser,
            });
            if (response.Succeeded)
            {
                ViewBag.CallId = callId;
            }
            else
            {
                var Info = await Mediator.Send(new Application.Features.Application.HistoricalCall.Queries.GetInfoOfScheduledCallId
                {
                    ScheduledCallId = callId,
                });

                if (Info.Succeeded)
                {
                    ViewBag.HistoricalCallVM = Info.Data;
                }
            }
            return PartialView();
        }

        public IActionResult New()
        {
            return PartialView();
        }

        [HttpPost]
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

        [HttpPost]
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
        [HttpPost]

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
       

        [HttpPost]
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
        [HttpPost]


        [HttpPost]
        public async Task<IActionResult> GetScheduledCallById([FromBody] GetScheduledCallById model)
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
        [HttpPost]
        public async Task<IActionResult> GetContactInfoOfCallId([FromBody] GetContactInfoOfCallId model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> AssignCallToNewUser([FromBody] AssignCallToNewUser model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> AssignAllCallsToNewUser([FromBody] AssignAllCallsToNewUser model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        
           
        [HttpPost]
        public async Task<IActionResult> GetHistoricalCallsOfCallId([FromBody] GetHistoricalCallsOfCallId model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitCallResult([FromBody] SubmitCallResultCommand model)

        {
            if (HttpContext.Session.GetString("callId")!= null && HttpContext.Session.GetString("callId")== model.ScheduledCallId.ToString())
            {
                var responsee= new Shared.Wrappers.Response<string>();
                // Button already clicked, prevent further processing
                responsee.HttpStatusCode = System.Net.HttpStatusCode.OK;
                responsee.Succeeded = true;
                responsee.Data = "This action has already been processed.";
               
                StatusCode((int)responsee.HttpStatusCode, responsee);
            }

            // Mark button as clicked
            HttpContext.Session.SetString("callId", model.ScheduledCallId.ToString());
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DoOperation([FromBody] DoOperationCommand model)
        {
            var response = await Mediator.Send(model);
            return StatusCode((int)response.HttpStatusCode, response);
        }

       
        [HttpPost]
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
        [HttpPost]
        public async Task<IActionResult> GetHistoricalByFilterForBankAgent([FromBody] Application.Features.Application.HistoricalCall.Queries.GetByFilter model)
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
