using Application.Common.Interfaces;
using Domain.Entities.Identity;
using Domain.Entities.Log;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Shared.Wrappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.Avaya.Commands
{
    public class GetCallResultFromDialerNHCCommand : IRequest<Response<string>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class GetCallResultFromDialerNHCCommandHandler : IRequestHandler<GetCallResultFromDialerNHCCommand, Response<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGeneralOperation _generalOperation;
        public GetCallResultFromDialerNHCCommandHandler(IGeneralOperation generalOperation, IApplicationDbContext dbContext)
        {
            _generalOperation = generalOperation;
            _context = dbContext;

        }
        public async Task<Response<string>> Handle(GetCallResultFromDialerNHCCommand request, CancellationToken cancellationToken)
        {
            Response<string> result = new Response<string>();
            try
            {
                string[] arrayOffFields = new string[] {

                   " ucid",
                  
                  // " evalresult1",
                  // " evalresult2"
                   //,"ROW_NUMBER() OVER(PARTITION BY nhc.address ORDER BY nhc.contact_attempt_time) AS AddressCount "
                   //,"CASE\r\n\r\n        WHEN nhc.completion_code_id IN (12, 13) THEN N'تم الرد'\r\n\r\n        WHEN nhc.completion_code_id IN (55, 45, 69, 18, 9, 8, 5, 15, 17, 7, 54, 43, 4) THEN N'لم يتم الرد'\r\n\r\n        WHEN nhc.completion_code_id = 16 THEN N'لم يتم الوصول'\r\n\r\n        WHEN nhc.completion_code_id = 10 THEN N'الرقم مشغول'\r\n\r\n        WHEN nhc.completion_code_id = 11 THEN N'رنين و لم يتم الرد'\r\n\r\n        WHEN nhc.completion_code_id = 14 THEN N'رد آلي'\r\n\r\n        ELSE N'غير معروف'\r\n\r\n    END AS Status"




            };

                string quaryFields = string.Join(",", arrayOffFields);
                string quaryTableName = "pim_contact_attempts_history";

                //  string quaryTableName = "pim_contact_attempts_history  AS nhc LEFT JOIN nhc_agentless_can AS can ON RIGHT(can.callernumber, 9) = nhc.address AND can.ucid = nhc.ucid";
                // string quaryWhereDate = "Where nhc.contact_attempt_time >= '" + request.FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and nhc.contact_attempt_time <= '" + request.ToDate.ToString("yyyy-MM-dd HH:mm:ss")+"' ";
                string quaryWhereDate = "where contact_attempt_time >='2025-01-09 00:00:00' and contact_attempt_time <= '2025-01-15 00:00:00' ";

                string quaryWhereClose = "";
                string quaryGroupBy = "";
                //string quaryOrderBy = "nhc.contact_attempt_time";
                string quaryOrderBy = "";

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


                    User user = null;
                    if (!string.IsNullOrEmpty(PIMContactAttemptsHistory.Agent_id))
                    {
                        user = _context.User.FirstOrDefault(x => x.Extension == PIMContactAttemptsHistory.Agent_id);
                    }
                    var sessionId = _context.Pim_contact_attempts_history
                        .Where(x => x.Pim_session_id == PIMContactAttemptsHistory.Pim_session_id).FirstOrDefault();
                    if (sessionId == null)
                    {
                         
                        try
                        {
                            Domain.Entities.Application.Contact contact = null;
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
                            };
                            if (PIMContactAttemptsHistory.ProductId != "" && PIMContactAttemptsHistory.ProductId != Guid.Empty.ToString())
                            {
                                itemForDb.CategoryId = Guid.Parse(PIMContactAttemptsHistory.ProductId);
                            }
                            if (PIMContactAttemptsHistory.CallID != "" && PIMContactAttemptsHistory.CallID != Guid.Empty.ToString())
                            {
                                itemForDb.ScheduledCallId = Guid.Parse(PIMContactAttemptsHistory.CallID);
                            }
                            if (PIMContactAttemptsHistory.CampaginId != "" && PIMContactAttemptsHistory.CampaginId != Guid.Empty.ToString())
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
                            var lastCall = contact.ScheduledCalls
                                    .OrderByDescending(x => x.Id == itemForDb.ScheduledCallId).FirstOrDefault();

                            if (lastCall != null)
                            {
                                var identity = lastCall?.Contact?.PersonalInfo?.IdentityNumber;
                                var test = PIMContactAttemptsHistory.Code;
                                var CallStatus = (PIMContactAttemptsHistory.Code == "Default_code" || PIMContactAttemptsHistory.Code == "Answer_Human" || PIMContactAttemptsHistory.Code == "Call_Answered") ? "ناجحة" : "غير ناجحة";
                                if (CallStatus == "غير ناجحة")
                                {
                                    if (lastCall.CallStatusId != Shared.Struct.CallStatus.NotSuccessByDialer)
                                    {
                                        lastCall.CallStatusId = Shared.Struct.CallStatus.NotSuccessByDialer;
                                        _context.ScheduledCall.Update(lastCall);
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }

                                }
                            }
                            //var inCallHistory = contact.HistoricalCalls
                            //         .Where(x => x.ScheduledCallId == itemForDb.ScheduledCallId)
                            //         .FirstOrDefault();
                            //if (inCallHistory != null)
                            //{
                            //    inCallHistory.CallDuration = duration;
                            //    _context.HistoricalCall.Update(inCallHistory);
                            //    await _context.SaveChangesAsync(cancellationToken);


                            //    var inCallHistoryLog = _context.HistoricalCallGeneralReportSammary
                            //     .Where(x => x.HistoricalCallId == inCallHistory.Id)
                            //     .FirstOrDefault();
                            //    if (inCallHistoryLog != null)
                            //    {
                            //        inCallHistoryLog.CallDuration = duration;
                            //        var callDurationTimeSpan = TimeSpan.FromSeconds(inCallHistoryLog.CallDuration ?? 0);
                            //        inCallHistoryLog.CallDurationString = callDurationTimeSpan.ToString(@"hh\:mm\:ss");
                            //        inCallHistoryLog.CallEndAt = itemForDb.Call_completion_time;
                            //        inCallHistoryLog.CallStartAt = itemForDb.Call_start_time;
                            //        _context.HistoricalCallGeneralReportSammary.Update(inCallHistoryLog);
                            //        await _context.SaveChangesAsync(cancellationToken);
                            //    }

                            //}
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

                //fill missed duration
                //DateTime date = DateTime.Now.AddDays(-2);
                //var historicalCall = _context.HistoricalCallGeneralReportSammary.Where(x => x.CallDuration == null && x.CallDate >= date && x.CategoryId != Guid.Parse("14843860-4C0B-4D42-A637-B13E00FB66A8")).ToList();

                //foreach (var call in historicalCall)
                //{
                //    var CallForDuration = _context.Pim_contact_attempts_history.Where(x => x.ScheduledCallId == call.HistoricalCall.ScheduledCallId).FirstOrDefault();

                //    if (CallForDuration != null)
                //    {
                //        var MissedDuration = CallForDuration.CallDuration;

                //        call.CallDuration = MissedDuration;
                //        var callDurationTimeSpan = TimeSpan.FromSeconds(call.CallDuration ?? 0);
                //        call.CallDurationString = callDurationTimeSpan.ToString(@"hh\:mm\:ss");
                //        call.CallEndAt = CallForDuration.Call_completion_time;
                //        call.CallStartAt = CallForDuration.Call_start_time;
                //        _context.HistoricalCallGeneralReportSammary.Update(call);
                //    }




                //}
                //await _context.SaveChangesAsync(cancellationToken);
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

        }
    }
}
