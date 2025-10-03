using Application.Common.Interfaces;
namespace Application.Features.Application.Contact.Commands.Create
{ 
using Localization;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Domain.Entities.Application;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;

    public class CreateNewContactCommand : IRequest<Response<CreateNewContactCommand>>
    {
        public Guid Id { get; set; }

        public string? FullNameAr { get; set; }
        public string? FullNameEn { get; set; }
        public string? IdentityNumber { get; set; }




        public string? PhoneNumber { get; set; }
      
       
        public string? Notes { get; set; }

       

        public bool? IsDesable { get; set; }

    }
    public class CreateNewContactCommandHandler : IRequestHandler<CreateNewContactCommand, Response<CreateNewContactCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateNewContactCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Response<CreateNewContactCommand>> Handle(CreateNewContactCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewContactCommand> result = new();
            Domain.Entities.Application.PersonalInfo personalInfo = new()
            {
                IdentityNumber = request.IdentityNumber,
              
               
                PhoneNumber = request.PhoneNumber,

                FullNameEn = request.FullNameEn,



                FullNameAr = request.FullNameAr    };
            try
            {
             _context.PersonalInfo.Add(personalInfo);
                await _context.SaveChangesAsync(cancellationToken);

                Domain.Entities.Application.Contact contact = new() {
                    Id = personalInfo.Id,
                    PersonalInfoId = personalInfo.Id,
                    FullName = request.FullNameAr,
                   
                    PhoneNumber = request.PhoneNumber,
                  IdentityNumber = request.IdentityNumber,
                    Notes = request.Notes,
                   
                    IsDesable = request.IsDesable
                };


                //var mappedContact = _mapper.Map<Contact>(request);
                _context.Contact.Add(contact);
                var dbObject = await _context.SaveChangesAsync(cancellationToken);
                result.Data = _mapper.Map<CreateNewContactCommand>(contact);
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;



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
                    Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                };
            }

            return result;
        }
    }
}
