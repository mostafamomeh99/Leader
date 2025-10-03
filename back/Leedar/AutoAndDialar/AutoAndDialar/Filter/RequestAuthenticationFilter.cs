using Application.Common.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DialerSystem.Filter
{
    public class RequestAuthenticationFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContextCurrentUserService _currentUserService;
        public RequestAuthenticationFilter(IHttpContextAccessor httpContextAccessor, IContextCurrentUserService currentUserService)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUserService = currentUserService;
        }



        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var type1 = context.Controller.GetType();
            var controllerName = type1.Name;
            if (controllerName != "AccountController")
            {
                if (_currentUserService.UserId == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        action = "Login",
                        controller = "Account",
                        area = "" 
                    }));
                }
            }
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
