using Infrastructure.Interfaces;
using Localization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ContextCurrentUserService : IContextCurrentUserService
    {
        protected ISender Mediator;
        protected IHttpContextAccessor httpContextAccessor;
        //private CurrantUserViewModel currantUser;
        //public CurrantUserViewModel CurrantUser { get; set; }
        //public CurrantUserViewModel CurrantUser
        //{
        //    get => httpContextAccessor.HttpContext?.Items["CurrantUser"] != null ? (CurrantUserViewModel)httpContextAccessor.HttpContext?.Items["CurrantUser"] : null;
        //    set => throw new NotImplementedException();
        //}
        //private readonly IApplicationDbContext _context;
        public ContextCurrentUserService(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            //Mediator = sender;
            // _context = context;
            //var test = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //var testasd = httpContextAccessor.HttpContext?.User.Identity;

            var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
            var UserIdString = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            //var CurrantUserString = httpContextAccessor.HttpContext?.Items["CurrantUser"];
            //if (CurrantUserString != null)
            //{
            //    CurrantUser = (CurrantUserViewModel)CurrantUserString;
            //}
            if (!string.IsNullOrEmpty(userId))
            {
                UserId = Guid.Parse(userId);
                Role = role;
                // User = GetCurrentUser().Result;
            }
        }

        public Guid? UserId { get; }
        public string Role { get; }
        // CurrantUserViewModel IContextCurrentUserService.CurrantUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
