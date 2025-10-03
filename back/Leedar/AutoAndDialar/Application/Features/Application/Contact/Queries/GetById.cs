namespace Application.Features.Application.Contact.Queries
{
    using Domain.Entities.Application;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using global::Application.Features.Application.Contact.Commands;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.ViewModels;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetById : IRequest<Response<EditContactCommand>>
    {
        public string Id { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

    }
    public class GetByIdHandler : IRequestHandler<GetById, Response<EditContactCommand>>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EditContactCommand>> Handle(GetById request, CancellationToken cancellationToken)
        {
            Response<EditContactCommand> result = new();
            try
            {
                var Contact = await _context.Contact.Where(x => x.Id == Guid.Parse(request.Id))
                   .Include(x => x.PersonalInfo)
                   
                  .FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                if(Contact!= null) {
                    result.Data = new EditContactCommand
                    {
                        Id = Contact.Id,
                        IdentityNumber = Contact.PersonalInfo?.IdentityNumber,
                        FullNameAr = Contact.PersonalInfo?.FullNameAr,


                        PhoneNumber = Contact.PersonalInfo?.PhoneNumber,
                       
                        Notes = Contact.Notes,
                       

                        StateCode = Contact.StateCode,

                       
                    };

                }






                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "",
                    Body = ""
                };
            }
            return result;
        }
    }
}