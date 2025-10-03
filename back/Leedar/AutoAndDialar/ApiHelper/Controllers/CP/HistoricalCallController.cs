
using Application.Features.Application.HistoricalCall.Commands;
using Application.Features.Application.HistoricalCall.Queries;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class HistoricalCallController : BaseController
    {
       
        [HttpPost("GetHistoricalCallGeneralStatistics")]
        public async Task<IActionResult> GetHistoricalCallGeneralStatistics([FromBody] GetHistoricalCallGeneralStatistics model)
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
        
        [HttpPost("HistoricalCallStatisticsByCallStatus")]
        public async Task<IActionResult> HistoricalCallStatisticsByCallStatus([FromBody] GetHistoricalCallCountByCallStatus model)
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
        //public async Task<IActionResult> ExportHistoricalCallStatisticsByCallStatus([FromBody] ExportHistoricalCallCountByCallStatus model)
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


        //[HttpPost]
        //public async Task<IActionResult> HistoricalCallStatisticsByAssignToUser([FromBody] GetHistoricalCallStatisticsByAssignToUser model)
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

        //[HttpPost]
        //public async Task ExportHistoricalCallGeneralReport([FromBody] ExportHistoricalCallGeneralReport model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await Mediator.Send(model);

        //        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        //Response.AddHeader("content-disposition", "attachment;  filename=CallsDetails" + DateTime.Now.ToString("yyyy_MM_dd") + ".xlsx");

        //        //MemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
        //        //HttpContext.Current.Response.Flush();
        //        //HttpContext.Current.Response.End();
        //        //return StatusCode((int)response.HttpStatusCode, response);
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
        //        //return StatusCode((int)HttpStatusCode.BadRequest, message);
        //    }
        //}

        
       

    }
}
