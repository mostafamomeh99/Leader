//using Application.Common.Interfaces;
//using Application.Common.Models;
//using Application.Features.Application.Contact.Commands.Create;
//using AutoMapper;
//using Domain.Entities.Identity;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Shared.Extensions;
//using Shared.Interfaces.Services;
//using Shared.Settings;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Log.pim_contact_attempts_history.Queries
//{
//    public class FillMissingCallDuration : IRequest<Response<bool>>
//    {
//        public DateRangViewModel SelectedDateRange { get; set; }

//    }
//    public class FillMissingCallDurationHandler : IRequestHandler<FillMissingCallDuration, Response<bool>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly IPOMService _pomService;
//        private readonly IREDFWS _NHCAPISettings;

//        public FillMissingCallDurationHandler(IApplicationDbContext context, IMapper mapper, IPOMService pomService, IREDFWS NHCAPISettings)
//        {
//            _context = context;
//            _mapper = mapper;
//            _pomService = pomService;
//            _NHCAPISettings = NHCAPISettings;
//        }
//        public async Task<Response<bool>> Handle(FillMissingCallDuration request, CancellationToken cancellationToken)
//        {
//            Response<bool> result = new();
//            try
//            {
//                //DateTime Enddate = new DateTime(DateTime.Now.Year, 01, 01, 00, 00, 00);

//                //DateTime date = new DateTime(DateTime.Now.Year-1, 06, 01, 00, 00, 00);
//                //var historicalCall = _context.HistoricalCallGeneralReportSammary.Where(x => x.CallStartAt == null && x.CallEndAt == null && x.CallDate >= date && x.CallDate <= Enddate && x.CategoryId != Guid.Parse("14843860-4C0B-4D42-A637-B13E00FB66A8")).ToList();

//                //foreach (var call in historicalCall)
//                //{
//                //    var CallForduration = _context.Pim_contact_attempts_history.Where(x => x.ScheduledCallId == call.HistoricalCall.ScheduledCallId).FirstOrDefault();

//                //    if (CallForduration != null)
//                //    {
//                //       // var duration = CallForduration.CallDuration;

//                //      //  call.CallDuration = duration;
//                //      //  var callDurationTimeSpan = TimeSpan.FromSeconds(call.CallDuration ?? 0);
//                //      //  call.CallDurationString = callDurationTimeSpan.ToString(@"hh\:mm\:ss");
//                //        call.CallEndAt = CallForduration.Call_completion_time;
//                //        call.CallStartAt = CallForduration.Call_start_time;
//                //        _context.HistoricalCallGeneralReportSammary.Update(call);
//                //    }




//                //}
//                //await _context.SaveChangesAsync(cancellationToken);
//                //  await _NHCAPISettings.GetToken();
//                //      var NewCenters = await _NHCAPISettings.GetCentersAndProjects("AAIgNWJhMWU0MjYyNzVhZjRmMzZhZjY0MGY0NDAyYWM5YWIAd8s5dmOwQSWzdIHz9JYMOboEb4w_DFUgLNOIaqrra8QrLIysbbXzQ1g9PNNAz-GM3ZY-_X8n_ZSlMPOr6KWgF0bvoMAaNkkoo7ZGFck4I2WzjcC0Pc7oa72rmzM6jVQ");
//                //foreach (var variable in Environment.GetEnvironmentVariables().Keys)
//                //{
//                //    Console.WriteLine($"{variable}: {Environment.GetEnvironmentVariable(variable.ToString())}");
//                //}
//                //    var test = Environment.GetEnvironmentVariables().Keys;

//                #region test delete drom avaya
//                //var scheduledCallObj = _context.ScheduledCall.Where(x => x.Id == Guid.Parse("321528f3-b7c4-44a1-ab7b-b17500942481")).FirstOrDefault();
//                //var isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), scheduledCallObj?.Category?.AVAYAAURACampaignPredictive?.NameInAvayaSystem);
//                //if (!isDeletedFromDialer)
//                //{
//                //    isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPredictiveOnMapCL");
//                //    if (!isDeletedFromDialer)
//                //    {
//                //        isDeletedFromDialer = await _pomService.DeleteContactFromListAsync(scheduledCallObj.Id.ToString(), "REDFPreviewCL");
//                //    }
//                //}

//                #endregion
//                var username = "943dab9c6e1d72fbf5a3fefedaf30641";
//                var password = "f1bc9a6c321c7aab413667914fbfeeb4";
//                var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
//                var user=_context.User.Where(x=>x.EmailConfirmed==true).FirstOrDefault();
//                //if (user.Identity != null && user.IsAuthenticated)
//                //{
//                //    // The user is authenticated
//                //    Console.WriteLine($"User {User.Identity.Name} is authenticated.");
//                //}
//                //else
//                //{
//                //    // The user is not authenticated
//                //    Console.WriteLine("User is not authenticated.");
//                //}
//                result.Data = true;
//                return result;


//            }
//            catch (Exception ex)
//            {
//                result.Data = false;
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
