

using Application.Features.Application.HistoricalCall.Queries;
using Application.Features.Application.ScheduledCall.Queries;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class ReportController : BaseController
    {
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult New()
        {
            return PartialView();
        }
        public IActionResult AgentCallReport()
        {
            return PartialView();
        }
        public IActionResult ContactReport()
        {
            return PartialView();
        }
        public IActionResult DialerCallReport()
        {
            return PartialView();
        }
        public IActionResult UploadReport()
        {
            return PartialView();
        }


       
        [HttpPost]
        public async Task<IActionResult> GetPIMContactAttemptsHistory([FromBody] GetPIMContactAttemptsHistory model)
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
        public async Task<IActionResult> GetContactUploadingLog([FromBody] Application.Features.Log.GetByFilter model)
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
        public async Task<IActionResult> ExportPIMContactAttemptsHistory([FromBody] ExportPIMContactAttemptsHistory model)
        {
            model.HttpRequest = Request;
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
