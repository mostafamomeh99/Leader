using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Commands.Update
{
    public class LogOutCommand : IRequest<Response<bool>>
    {
        public Guid userId { get; set; }
    }
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, Response<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;

        public LogOutCommandHandler(
            IApplicationDbContext context,
            SignInManager<Domain.Entities.Identity.User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<Response<bool>> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();
            try
            {
                var user = _context.User.Where(x => x.Id == request.userId).FirstOrDefault();
                if (user != null)
                {
                    user.IsLoggedIn = false;
                    _context.User.Update(user);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                await _signInManager.SignOutAsync();
                return new Response<bool> { Data = true, HttpStatusCode = System.Net.HttpStatusCode.OK };

            }
            catch (Exception ex)
            {
                return new Response<bool> { Data = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }
    }
}
