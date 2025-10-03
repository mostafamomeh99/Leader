//using Application.Features.Identity.User.Queries;
using System;

namespace Infrastructure.Interfaces
{
    public interface IContextCurrentUserService
    {
        Guid? UserId { get; }
        //CurrantUserViewModel CurrantUser { get; set; }
    }
}
