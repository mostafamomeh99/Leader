
using Application.Common.Interfaces;

using Application.Features.Application.HistoricalCall.Queries;

using Application.Features.Application.ScheduledCall.Commands.Create;

using Domain.Entities.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class OperationController : BaseController
    {
        
        [HttpPost("SchedualCallsToContactByExcel")]
        public async Task<IActionResult> SchedualCallsToContactByExcel(SchedualCallsToContactByExcelCommand model)
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
