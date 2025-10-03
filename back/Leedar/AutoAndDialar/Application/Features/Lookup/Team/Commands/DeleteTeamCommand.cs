using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.Application;
using Infrastructure.Interfaces;
using Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Globalization;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Team.Commands
{
    public class DeleteTeamCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }



    }
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Response<bool>>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTeamCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<bool>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            Response<bool> result = new();


            try
            {
                var TeamToDelete = await _context.Team.Where(x => x.Id == request.Id)
                   .FirstOrDefaultAsync();
                _context.Team.Remove(TeamToDelete);
                await _context.SaveChangesAsync(cancellationToken);

                result.Data = true;
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex)
            {

                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = SharedResource.FailedOperation,
                    Body = ""

                };
            }
            return result;
        }
    }
}

