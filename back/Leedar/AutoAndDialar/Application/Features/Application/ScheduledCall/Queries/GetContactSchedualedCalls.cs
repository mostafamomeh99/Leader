//using Application.Common.Interfaces;
//using Application.Common.Models;
//using Infrastructure.Interfaces;
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

//namespace Application.Features.Application.ScheduledCall.Queries
//{
//    public class ContactSchedualedCallResult
//    {
//        public List<EntityFieldViewModel> callList { set; get; }
//        public string isHasSchedualedCalls { set; get; }
//    }
//    public class GetContactSchedualedCalls : IRequest<Response<ContactSchedualedCallResult>>
//    {
//        public Guid CallId { get; set; }
//    }
//    public class GetContactSchedualedCallsHandler : IRequestHandler<GetContactSchedualedCalls, Response<ContactSchedualedCallResult>>
//    {
//        private readonly IApplicationDbContext _context;

//        public GetContactSchedualedCallsHandler(IApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<Response<ContactSchedualedCallResult>> Handle(GetContactSchedualedCalls request, CancellationToken cancellationToken)
//        {
//            Response<ContactSchedualedCallResult> result = new();
//            result.Data = new ContactSchedualedCallResult();
//            try
//            {
//                var Contact = await _context.ScheduledCall.Where(x => x.Id == request.CallId)
//                    .Select(x => x.Contact).FirstOrDefaultAsync();
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

//                if (Contact != null)
//                {
//                    var listResult = (await _context.ScheduledCall.Where(x =>
//                     x.ContactId == Contact.Id &&
//                     x.Id != request.CallId &&
//                     (x.CallStatusId == Shared.Struct.CallStatus.ScheduledInSystem ||
//                     x.CallStatusId == Shared.Struct.CallStatus.ScheduledInDialer))
//                         .Select(x => new
//                         {
//                             Id = x.Id,
//                             AgentName = x.ScheduledToUser.PersonalInfo.FullName,
//                             ScheduledCallDate = x.ScheduledCallDate.Value.ToString("yyyy/MM/dd HH:mm:ss"),
//                         }).ToListAsync())
//                           .Select(x => new EntityFieldViewModel
//                           {
//                               Id = x.Id,
//                               Name = "اسم الموظف : " + x.AgentName + ", تاريخ المكالمة المجدولة : " + x.ScheduledCallDate
//                           }).ToList();

//                    result.Data.callList = listResult;
//                    result.Data.isHasSchedualedCalls = listResult.Any()?"true":"false";
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
