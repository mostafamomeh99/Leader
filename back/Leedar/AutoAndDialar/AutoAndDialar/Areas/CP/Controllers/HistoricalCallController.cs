using Application.Features.Application.HistoricalCall.Commands;
using Application.Features.Application.HistoricalCall.Queries;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class HistoricalCallController : BaseController
    {
        public IActionResult GeneralReport()
        {
            return PartialView();
        }
        public IActionResult HistoricalCallStatisticsByCallStatus()
        {
            return PartialView();
        }

        public IActionResult New()
        {
            return PartialView();
        }

       

        [HttpPost]
        public async Task<IActionResult> GetHistoricalCallGeneralStatistics([FromBody] GetHistoricalCallGeneralStatistics model)
        {
           // model.SelectedDateRange.dateStart= new DateTime(DateTime.Now.Year, 3, 07, 2, 0, 0);
           // model.SelectedDateRange.dateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, 23, 0, 0);
            //DateTime fromDate = new DateTime(2022, 01, 01);
            //while (fromDate < DateTime.Now)
            //{
            //    var test = await Mediator.Send(new
            //        Application.Features.Log.HistoricalCallGeneralReportSammary.Create.FillReportSamaryFromHistoricalCallCommand
            //    {
            //        SelectedDateRange = new Application.Common.Models.DateRangViewModel
            //        {
            //            dateStart = fromDate,
            //            dateEnd = fromDate.AddDays(1),
            //        }
            //    });
            //    fromDate = fromDate.AddDays(1);
            //}

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
