//using Application.Common.Interfaces;
//using Application.Common.Models;
//using MediatR;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Application.Contact.Queries
//{
//    public class ContactPhoneNumbersResult
//    {
//        public List<EntityFieldViewModel> phonesList { set; get; }
//    }
//    public class GetContactPhoneNumbersQuery : IRequest<Response<ContactPhoneNumbersResult>>
//    {
//        public Guid CallId { get; set; }
//    }
//    public class GetContactPhoneNumbersQueryHandler : IRequestHandler<GetContactPhoneNumbersQuery, Response<ContactPhoneNumbersResult>>
//    {
//        private readonly IApplicationDbContext _context;

//        public GetContactPhoneNumbersQueryHandler(IApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<Response<ContactPhoneNumbersResult>> Handle(GetContactPhoneNumbersQuery request, CancellationToken cancellationToken)
//        {
//            Response<ContactPhoneNumbersResult> result = new();
//            result.Data = new ContactPhoneNumbersResult();


//            try
//            {
//                var Contact = await _context.ScheduledCall.Where(x => x.Id == request.CallId)
//                    .Select(x => x.Contact).FirstOrDefaultAsync();
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

//                if (Contact != null)
//                {
//                    result.Data.phonesList = new List<EntityFieldViewModel>();
//                    if (!string.IsNullOrEmpty(Contact.PersonalInfo.PhoneNumber) && Contact.PersonalInfo.PhoneNumber.Length >= 9)
//                    {
//                        result.Data.phonesList.Add(new EntityFieldViewModel
//                        {
//                            //Id = Contact.PersonalInfo.PhoneNumber,
//                            Name = Contact.PersonalInfo.PhoneNumber,
                            
//                        });
//                    }
//                    if (!string.IsNullOrEmpty(Contact.PersonalInfo.PhoneNumber2) && Contact.PersonalInfo.PhoneNumber2.Length >= 9)
//                    {
//                        result.Data.phonesList.Add(new EntityFieldViewModel
//                        {
//                            //Id = Contact.PersonalInfo.PhoneNumber2,
//                            Name = Contact.PersonalInfo.PhoneNumber2
//                        });
//                    }
//                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                    result.Succeeded = true;
//                }
//                else
//                {
//                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
//                    result.Succeeded = false;
//                    result.Message = new NotificationMessage
//                    {
//                        Title = "معرف المكالمة غير مرتبط بأي مستفيد",
//                        Body = "معرف المكالمة غير موجود"
//                    };
//                }


//            }
//            catch (Exception ex)
//            {
//                result.Data = null;
//                result.Succeeded = false;
//                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
//                result.Exception = ex;
//                result.Message = new NotificationMessage
//                {
//                    Title = "",
//                    Body = ""
//                };
//            }
//            return result;
//        }
//    }
//}
