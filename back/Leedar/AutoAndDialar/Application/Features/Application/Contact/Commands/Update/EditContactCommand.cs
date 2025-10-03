using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.Contact.Commands
{
    using Domain.Entities.Application;
    using Infrastructure.Interfaces;

    public class EditContactCommand : IRequest<Response<EditContactCommand>>
    {
        public Guid? Id { get; set; }
        
        public string? FullNameAr { get; set; }
       
        public string? PhoneNumber { get; set; }
        public string? IdentityNumber { get; set; }
      
        public string? Notes { get; set; }
        public byte StateCode { get; set; }


        public bool? IsDesable { get; set; }
        public class EditContactCommandHandler : IRequestHandler<EditContactCommand, Response<EditContactCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public EditContactCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<EditContactCommand>> Handle(EditContactCommand request, CancellationToken cancellationToken)
            {
                Response<EditContactCommand> result = new();
                try
                {


                    var mappedContact = _mapper.Map<Contact>(request);
                    _context.Contact.Update(mappedContact);
                    var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    result.Data = _mapper.Map<EditContactCommand>(mappedContact);
                    result.Succeeded = true;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Message = new NotificationMessage
                    {
                        Title = "عملية ناجحة !!!",
                        Body = "تمت العملية بنجاح",
                    };
                }
                catch (Exception ex)
                {
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Exception = ex;
                    result.Message = new NotificationMessage
                    {
                        Title = "",
                        Body = "",
                    };
                }
                return result;
            }
        }
    }

}