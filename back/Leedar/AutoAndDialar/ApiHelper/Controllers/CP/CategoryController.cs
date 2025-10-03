
using Application.Features.Lookup.Category.Commands;
using Application.Features.Lookup.Category.Commands.Create;
using Application.Features.Lookup.Category.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseController
    {
       
        [HttpPost("New")]
        public async Task<IActionResult> New([FromBody] CreateNewCategoryCommand model)
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

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditCategoryCommand model)
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

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] Guid Id)
        {
            if (ModelState.IsValid)
            {
                var response = await Mediator.Send(new GetById
                {
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

    }
}
