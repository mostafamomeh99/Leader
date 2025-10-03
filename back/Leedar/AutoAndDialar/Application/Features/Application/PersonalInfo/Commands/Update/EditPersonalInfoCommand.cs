using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.PersonalInfo.Commands.Update
{
    using AutoMapper;
    using Domain.Entities.Application;
    using Infrastructure.Interfaces;
    using MediatR;
    using Shared.Wrappers;
    using System.Threading;

    public class EditPersonalInfoCommand : IRequest<Response<EditPersonalInfoCommand>>
    {
        //test
        public Guid Id { get; set; }
        public string? IdentityNumber { get; set; }
        
        public string? FullNameAr { get; set; }


        public string? PhoneNumber { get; set; }
      
        public string? Notes { get; set; }
       

        public class EditTeamCommandHandler : IRequestHandler<EditPersonalInfoCommand, Response<EditPersonalInfoCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public EditTeamCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<EditPersonalInfoCommand>> Handle(EditPersonalInfoCommand request, CancellationToken cancellationToken)
            {
                Response<EditPersonalInfoCommand> result = new();
                try
                {


                    var mappedPersonalInfo = _mapper.Map<PersonalInfo>(request);
                    _context.PersonalInfo.Update(mappedPersonalInfo);
                    var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    result.Data = request;
                    result.Succeeded = true;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
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

