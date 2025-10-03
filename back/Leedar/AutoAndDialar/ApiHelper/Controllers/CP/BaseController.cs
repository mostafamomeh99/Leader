using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ApiHelper.Controllers.CP
{
    [ApiController]
    [Route("CP/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
