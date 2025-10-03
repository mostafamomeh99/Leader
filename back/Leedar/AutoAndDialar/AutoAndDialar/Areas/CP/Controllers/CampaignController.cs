using Application.Features.Lookup.Campaign.Commands;
using Application.Features.Lookup.Campaign.Commands.Create;
using Application.Features.Lookup.Campaign.Queries;


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class CampaignController : BaseController
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
            return PartialView(new EditCampaignCommand
            {
                Id = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> New([FromBody] CreateNewCampaignCommand model)
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
        public async Task<IActionResult> Edit([FromBody] EditCampaignCommand model)
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
