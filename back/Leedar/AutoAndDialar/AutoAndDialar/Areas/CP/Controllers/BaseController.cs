using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    public class BaseController : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        public BaseController()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }
    }
}
