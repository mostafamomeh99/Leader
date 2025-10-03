//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Localization;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DialerSystem.Middlewares
//{
//    public class SecurityHeadersMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public SecurityHeadersMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//           // context.Response.Headers.Add("Access-Control-Allow-Origin", "https://www.moc.gov.sa/");
//            //context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
//            //context.Response.Headers.Add("Content-Security-Policy", "frame-ancestors");
//            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
//           // context.Response.Headers.Add("Referrer-Policy", "origin");
//            context.Response.Headers.Add("Permissions-Policy", "geolocation=*, camera=(), microphone=()");
//           // context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
//            context.Response.Headers.Add("X-AspNetMvc-Version" , " ");
//            context.Response.Headers.Add("X-Powered-By"," ");
//            context.Response.Headers.Add("Server"," ");
//            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
//           // context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
//            context.Response.Headers.Add("X-Frame-Options", "DENY");
//            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
//            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self';");
//            context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
//           // context.Response.Headers.Add("Permissions-Policy", "geolocation=(self), microphone=(), camera=()");


//            await _next(context);
//        }
//    }
//}
