using Application.Common.Interfaces;
using Domain.Entities.Identity;
using Domain.Entities.Log;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.Avaya.Commands
{
    public class GetCallResultFromAutoDialerCommand : IRequest<Response<string>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class GetCallResultFromAutoDialerCommandHandler : IRequestHandler<GetCallResultFromAutoDialerCommand, Response<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGeneralOperation _generalOperation;
        public GetCallResultFromAutoDialerCommandHandler(IGeneralOperation generalOperation, IApplicationDbContext dbContext)
        {
            _generalOperation = generalOperation;
            _context = dbContext;

        }
        public async Task<Response<string>> Handle(GetCallResultFromAutoDialerCommand request, CancellationToken cancellationToken)
        {
            Response<string> result = new Response<string>();


            //_logger.LogInformation("job get avaya pom rsult started at" + DateTime.Now.ToString());

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

           
            try
            {
                string[] arrayOffFields = new string[] {

                "max(pcah.pim_session_id) as pim_session_id",
                "max(pcc.completion_code_id) as completion_code_id",
                "max(pcc.code) as code",
                "max(pcah.contact_attempt_time) as contact_attempt_time",
                "max(pcah.ringback_start_time) as ringback_start_time",
                "max(pcah.last_nw_disposition_time) as last_nw_disposition_time",
                "max(pcah.call_start_time) as call_start_time",
                "max(pcah.call_completion_time) as call_completion_time",
                "max(pcah.address) as address",
                "max(agent_id) as agent_id",
                "max(pcah.campaign_id) as campaign_id",
                "max(contact_list_id) as contact_list_id",
                "max(case when pca.attribute_name = 'ProductId' then pca.attribute_Value end) as ProductId",
                "max(case when pca.attribute_name = 'CampaginId' then pca.attribute_Value end) as CampaginId",
                "max(case when pca.attribute_name = 'CallID' then pca.attribute_Value end) as CallID",
                "max(case when pca.attribute_name = 'CallContactId' then pca.attribute_Value end) as CallContactId",
                "max(pcah.ucid) as ucid"
            };

                string quaryFields = string.Join(",", arrayOffFields);
                string quaryTableName = "pim_contact_attempts_history as pcah inner join public.pim_completion_code as pcc on pcah.completion_code_id = pcc.completion_code_id " +
                                        " inner join pim_contact_attribute_history as pca on pcah.contact_id = pca.contact_id " +
                                        " inner join pim_campaign as pcamp on pcamp.campaign_id = pcah.campaign_id";
                string quaryWhereDate = "Where pcah.contact_attempt_time >= '" + request.FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and pcah.contact_attempt_time <= '" + request.ToDate.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                    " and pcamp.name in ('AgentlessCamp02','NHC_Agentless','NHC_Interest_Camp')";
                string quaryWhereClose = "";
                string quaryGroupBy = "pcah.contact_id, pcah.pim_session_id";
                string quaryOrderBy = "pcah.contact_attempt_time";

                var quary = _generalOperation.GetStructuredQuary(quaryFields, quaryTableName, quaryWhereDate, quaryWhereClose, quaryGroupBy, quaryOrderBy);
                var quaryResult = _generalOperation.AURAPOMGetQuaryResult(quary, arrayOffFields.Length);

                var duration = new double();
                var all = await _context.Pim_contact_attempts_history
               .Where(x => x.Contact_attempt_time != null &&
                        x.Contact_attempt_time.Value.Date >= request.FromDate.Date &&
                         x.Contact_attempt_time.Value.Date <= request.ToDate.Date &&
                         x.Completion_Code_id != 43)
               .Select(x => x.Pim_session_id.ToString()).ToListAsync();


                var notAdded = quaryResult.Where(x => !all.Any(y => y == x[0])).ToList();

                //2021-12-13
                int isadded = 0;
                foreach (var item in notAdded)
                {
                    //if (!all.Any(x => x == item[0]))
                    //{

                    PIMContactAttemptsHistory PIMContactAttemptsHistory = new PIMContactAttemptsHistory();
                    if (!string.IsNullOrEmpty(item[0]))
                        PIMContactAttemptsHistory.Pim_session_id = long.Parse(item[0]);

                    if (!string.IsNullOrEmpty(item[1]))
                        PIMContactAttemptsHistory.Completion_code_id = int.Parse(item[1]);

                    PIMContactAttemptsHistory.Code = item[2];

                    if (!string.IsNullOrEmpty(item[3]))
                        PIMContactAttemptsHistory.Contact_attempt_time = DateTime.Parse(item[3]);
                    if (!string.IsNullOrEmpty(item[4]))
                        PIMContactAttemptsHistory.Ringback_start_time = DateTime.Parse(item[4]);
                    if (!string.IsNullOrEmpty(item[5]))
                        PIMContactAttemptsHistory.Last_nw_disposition_time = DateTime.Parse(item[5]);

                    if (!string.IsNullOrEmpty(item[6]))
                        PIMContactAttemptsHistory.Call_start_time = DateTime.Parse(item[6]);
                    if (!string.IsNullOrEmpty(item[7]))
                        PIMContactAttemptsHistory.Call_completion_time = DateTime.Parse(item[7]);

                    PIMContactAttemptsHistory.Address = item[8];

                    PIMContactAttemptsHistory.Agent_id = item[9];

                    if (!string.IsNullOrEmpty(item[10]))
                        PIMContactAttemptsHistory.Campaign_id = int.Parse(item[10]);
                    if (!string.IsNullOrEmpty(item[11]))
                        PIMContactAttemptsHistory.Contact_list_id = int.Parse(item[11]);

                    if (!string.IsNullOrEmpty(item[12]))
                    {
                        PIMContactAttemptsHistory.ProductId = (!string.IsNullOrEmpty(item[12])) ? item[12] : "";
                    }
                    if (!string.IsNullOrEmpty(item[13]))
                    {
                        PIMContactAttemptsHistory.CampaginId = (!string.IsNullOrEmpty(item[13])) ? item[13] : "";
                    }
                    if (!string.IsNullOrEmpty(item[14]))
                    {
                        PIMContactAttemptsHistory.CallID = (!string.IsNullOrEmpty(item[14])) ? item[14] : "";
                    }
                    if (!string.IsNullOrEmpty(item[15]))
                    {
                        PIMContactAttemptsHistory.ContactId = (!string.IsNullOrEmpty(item[15])) ? item[15] : "";
                    }
                    if (!string.IsNullOrEmpty(item[16]))
                    {
                        PIMContactAttemptsHistory.Ucid = (!string.IsNullOrEmpty(item[16])) ? item[16] : "";
                    }


                    User? user = null;
                    if (!string.IsNullOrEmpty(PIMContactAttemptsHistory.Agent_id))
                    {
                        user = _context.User.FirstOrDefault(x => x.Extension == PIMContactAttemptsHistory.Agent_id);
                    }
                    var sessionId = _context.Pim_contact_attempts_historyLog
                        .Where(x => x.Pim_session_id == PIMContactAttemptsHistory.Pim_session_id).FirstOrDefault();
                    if (sessionId == null)
                    {

                        try
                        {
                            Domain.Entities.Application.Contact? contact = null;
                            if (!string.IsNullOrEmpty(PIMContactAttemptsHistory.ContactId))
                            {
                                var cId = Guid.Parse(PIMContactAttemptsHistory.ContactId);
                                contact = _context.Contact.FirstOrDefault(x => x.Id == cId);
                            }
                            else
                            {
                                contact = _context.Contact.FirstOrDefault(x => x.PersonalInfo.PhoneNumber.Contains(PIMContactAttemptsHistory.Address));
                            }

                            var itemForDb = new Pim_contact_attempts_history
                            {
                                Id = Guid.NewGuid(),
                                UserId = (user != null) ? user.Id : null,
                                ContactId = (contact != null) ? contact.Id : (Guid?)null,
                                Address = PIMContactAttemptsHistory.Address,
                                Agent_id = PIMContactAttemptsHistory.Agent_id,
                                Call_completion_time = PIMContactAttemptsHistory.Call_completion_time,
                                Call_start_time = PIMContactAttemptsHistory.Call_start_time,
                                Campaign_id = PIMContactAttemptsHistory.Campaign_id,
                                Completion_Code_id = (PIMContactAttemptsHistory.Completion_code_id != null) ? PIMContactAttemptsHistory.Completion_code_id.Value : -1,
                                Completion_Code_Name = PIMContactAttemptsHistory.Code,
                                Contact_attempt_time = PIMContactAttemptsHistory.Contact_attempt_time,
                                Campaign_list_id = PIMContactAttemptsHistory.Contact_list_id,
                                CreatedOn = DateTime.Now,
                                CreatedByUserId = Shared.Struct.StaticUser.POMApplicationUser,
                                Last_nw_disposition_time = PIMContactAttemptsHistory.Last_nw_disposition_time,
                                Pim_session_id = PIMContactAttemptsHistory.Pim_session_id,
                                Ucid = PIMContactAttemptsHistory.Ucid,
                                CallTypeId = Shared.Struct.CallType.Auto,
                            };
                            if (PIMContactAttemptsHistory.ProductId != null && PIMContactAttemptsHistory.ProductId != "" && PIMContactAttemptsHistory.ProductId != Guid.Empty.ToString())
                            {
                                itemForDb.CategoryId = Guid.Parse(PIMContactAttemptsHistory.ProductId);
                            }
                            if (PIMContactAttemptsHistory.CallID != null && PIMContactAttemptsHistory.CallID != "" && PIMContactAttemptsHistory.CallID != Guid.Empty.ToString())
                            {
                                itemForDb.ScheduledCallId = Guid.Parse(PIMContactAttemptsHistory.CallID);
                            }
                            if (PIMContactAttemptsHistory.CampaginId != null && PIMContactAttemptsHistory.CampaginId != "" && PIMContactAttemptsHistory.CampaginId != Guid.Empty.ToString())
                            {
                                itemForDb.CampaignId = Guid.Parse(PIMContactAttemptsHistory.CampaginId);
                            }

                            if (itemForDb.Call_start_time != null && itemForDb.Call_completion_time != null)
                            {
                                duration = (itemForDb.Call_completion_time.Value - itemForDb.Call_start_time.Value).TotalSeconds;
                                itemForDb.CallDuration = duration;




                            }
                            if (itemForDb.Completion_Code_Name == "Default_code" ||
                                   itemForDb.Completion_Code_Name == "Answer_Human" ||
                                    itemForDb.Completion_Code_Name == "Answer_Machine" ||
                                   itemForDb.Completion_Code_Name == "Call_Answered")
                            {
                                itemForDb.IsSuccess = true;
                            }
                            else
                            {
                                itemForDb.IsSuccess = false;
                            }
                            //var isCallIndata = _context.HistoricalCall
                            //         .Where(x => x.ScheduledCallId == itemForDb.ScheduledCallId).FirstOrDefault();
                            //if (isCallIndata == null) { continue; }
                            _context.Pim_contact_attempts_history.Add(itemForDb);
                            await _context.SaveChangesAsync(cancellationToken);
                            isadded++;

                            //contact.CurruntDialerCallCount += 1;
                            var lastCall = contact?.ScheduledCalls?
                                    .OrderByDescending(x => x.Id == itemForDb.ScheduledCallId).FirstOrDefault();

                            if (lastCall != null)
                            {
                                if (lastCall.CallTypeId == Shared.Struct.CallType.Auto) 
                                {
                                    var identity = lastCall?.Contact?.PersonalInfo?.IdentityNumber;
                                    var test = PIMContactAttemptsHistory.Code;
                                    var CallStatus = (PIMContactAttemptsHistory.Code == "Default_code" || PIMContactAttemptsHistory.Code == "Answer_Human" || PIMContactAttemptsHistory.Code == "Answer_Machine" || PIMContactAttemptsHistory.Code == "Call_Answered") ? "ناجحة" : "غير ناجحة";
                                    if (CallStatus == "غير ناجحة")
                                    {
                                        if (lastCall?.CallStatusId != Shared.Struct.CallStatus.NotSuccessByDialer)
                                        {
                                            lastCall.CallStatusId = Shared.Struct.CallStatus.NotSuccessByDialer;
                                            _context.ScheduledCall.Update(lastCall);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }

                                    }
                                    else if (CallStatus == "ناجحة")
                                    {
                                        if (lastCall.CallStatusId != Shared.Struct.CallStatus.Completed)
                                        {
                                            lastCall.CallStatusId = Shared.Struct.CallStatus.Completed;
                                            _context.ScheduledCall.Update(lastCall);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }

                                    }
                                }
                                

                            }
                          

                        }
                        catch (Exception)
                        {
                            result.Succeeded = false;
                            result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                           // result.Exception = ;
                            result.Message = new NotificationMessage
                            {
                                Title = "",
                                Body = "",
                            };
                        }
                       
                    }
                }

               
                var oldStatusCall = _context.ScheduledCall.Where(x => x.CallStatusId != Shared.Struct.CallStatus.Completed && x.CallStatusId != Shared.Struct.CallStatus.NotSuccessByDialer).ToList();
                foreach (var call in oldStatusCall)
                {
                    var pamCall = _context.Pim_contact_attempts_history.Where(x => x.ScheduledCallId == call.Id).FirstOrDefault();
                    if (pamCall != null)
                    {
                        if (pamCall.IsSuccess == true)
                        {
                            call.CallStatusId = Shared.Struct.CallStatus.Completed;
                            _context.ScheduledCall.Update(call);
                            await _context.SaveChangesAsync(cancellationToken);

                        }
                        else
                        {
                            call.CallStatusId = Shared.Struct.CallStatus.NotSuccessByDialer;
                            _context.ScheduledCall.Update(call);
                            await _context.SaveChangesAsync(cancellationToken);

                        }
                    }
                }
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
        public class PIMContactAttemptsHistory
        {
            public long Pim_session_id { get; set; }
            public int? Completion_code_id { get; set; }
            public string? Code { get; set; }
            public DateTime? Contact_attempt_time { get; set; }
            public DateTime? Ringback_start_time { get; set; }
            public DateTime? Last_nw_disposition_time { get; set; }
            public DateTime? Call_start_time { get; set; }
            public DateTime? Call_completion_time { get; set; }
            public string? Address { get; set; }
            public string? Agent_id { get; set; }
            public int? Campaign_id { get; set; }
            public int? Contact_list_id { get; set; }
            public string? ProductId { get; set; }
            public string? CampaginId { get; set; }
            public string? CallID { get; set; }
            public string? ContactId { get; set; }
            public string? Ucid { get; set; }


        }
    }
}
