using Application.Common.Interfaces;
using Application.Features.Application.Contact.Commands;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.Contact.Queries
{
    public class GetContactInfoOfCallId : IRequest<Response<EditContactCommand>>
    {
        public string CallId { get; set; }
    }
    public class GetContactInfoOfCallIdHandler : IRequestHandler<GetContactInfoOfCallId, Response<EditContactCommand>>
    {
        private readonly IApplicationDbContext _context;

        public GetContactInfoOfCallIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EditContactCommand>> Handle(GetContactInfoOfCallId request, CancellationToken cancellationToken)
        {
            Response<EditContactCommand> result = new();
            try
            {
                var Contact = await _context.ScheduledCall.Where(x => x.Id == Guid.Parse(request.CallId))
                    .Select(x => x.Contact).FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                if (Contact != null)
                {
                    result.Data = new EditContactCommand
                    {
                        Id = Contact.Id,
                        IdentityNumber = Contact.PersonalInfo?.IdentityNumber,
                        FullNameAr = Contact.PersonalInfo?.FullNameAr,

                       
                        PhoneNumber = Contact.PersonalInfo?.PhoneNumber,
                      
                        Notes = Contact.Notes,
                       

                    };

                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = true;
                }
                else
                {
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Succeeded = false;
                    result.Message = new NotificationMessage
                    {
                        Title = "معرف المكالمة غير مرتبط بأي مستفيد",
                        Body = "معرف المكالمة غير موجود"
                    };
                }


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
