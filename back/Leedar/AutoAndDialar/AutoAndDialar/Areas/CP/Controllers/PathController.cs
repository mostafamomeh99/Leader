
using Application.Features.Entity.EntityActionTypeRequiredField.Queries;
using Application.Features.Entity.EntityField.Queries;
using Application.Features.Entity.EntityFieldOption.Queries;
using Application.Features.Lookup.CategoryPath.Commands;
using Application.Features.Lookup.CategoryPath.Commands.Create;
using Application.Features.Lookup.CategoryPath.Commands.Update;
using Application.Features.Lookup.CategoryPath.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class PathController : BaseController
    {
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult New()
        {
            return PartialView();
        }
        public IActionResult GetPathViewOfCallId(Guid? callId, bool? isHistoricalCall)
        {
            ViewBag.CallId = callId;
            ViewBag.IsHistoricalCall = isHistoricalCall;
            return PartialView("View");
        }
        public IActionResult Edit(Guid CategoryPathId)
        {
            ViewBag.CategoryPathId = CategoryPathId;
            return PartialView("New");
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
        public async Task<IActionResult> GetAllFieldsNames([FromBody] GetAllFieldsNames model)
        {
            if (ModelState.IsValid)
            {
                //GetAllFieldsNames model = new GetAllFieldsNames();
                //model.Name = name;
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
        public async Task<IActionResult> New([FromBody] CreateNewPathFullCommand model)
        {
            if (model == null)
            {
                return StatusCode((int)HttpStatusCode.OK, null);
            }
            //return null;
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdatePathFullCommand model)
        {
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> GetFullPathByCategoryId([FromBody] GetFullPath model)
        {
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> GetFieldOptions([FromBody] GetFieldOptionsQuery model)
        {
            var result = await Mediator.Send(model);

            return StatusCode((int)result.HttpStatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> GetEntityActionTypeRequiredFieldsToEntityActionType([FromBody] GetEntityActionTypeRequiredFieldsToEntityActionTypeQuery model)
        {
            var result = await Mediator.Send(model);
            return StatusCode((int)result.HttpStatusCode, result);
        }

    }
}
