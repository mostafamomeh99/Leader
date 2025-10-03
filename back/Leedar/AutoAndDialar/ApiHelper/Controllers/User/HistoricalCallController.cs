using Application.Common.Interfaces;
using Application.Features.Application.HistoricalCall.Queries;

using Infrastructure.Interfaces;
using Infrastructure.Persistence.Configurations.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Controllers.User
{
    [ApiVersion("1.0")]
    public class HistoricalCallController : BaseController
    {
        IContextCurrentUserService _currentUserService;
        IApplicationDbContext _context;
        public HistoricalCallController(IContextCurrentUserService currentUserService, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        [HttpPost("GetHistoricalCallGeneralStatistics")]
        public async Task<IActionResult> GetHistoricalCallGeneralStatistics([FromBody] GetHistoricalCallGeneralStatistics model)
        {
            model.UserIds = new List<string>();
            model.UserIds.Add((_currentUserService.UserId.Value).ToString());
            
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
