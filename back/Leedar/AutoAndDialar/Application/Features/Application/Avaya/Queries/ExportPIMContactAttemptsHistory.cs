using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Extensions;
using Application.Features.Application.Avaya;
using AutoMapper;
using Domain.Entities.Log;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Shared.Extensions;
using Shared.Interfaces.Services;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall.Queries
{
    public class ExportPIMContactAttemptsHistory : IRequest<Response<string>>
    {
        public HttpRequest? HttpRequest { get; set; }
        public DateRangViewModel? SelectedDateRange { get; set; }
        public string? ContactIdentityNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
       
        public List<Guid>? UserIds { get; set; }
        public List<Guid>? TeamIds { get; set; }
        public string? CallStatus { get; set; }

        
    }
    public class ExportPIMContactAttemptsHistoryHandler : IRequestHandler<ExportPIMContactAttemptsHistory, Response<string>>
    {
        private readonly IApplicationDbContext _context;
     
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IGeneralOperation _generalOperation;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IVirtualPathService _virtualPathService;

        public ExportPIMContactAttemptsHistoryHandler(
            IApplicationDbContext context,
             IHostingEnvironment hostingEnvironment,
             IVirtualPathService virtualPathService,
            IContextCurrentUserService currentUserService,
            IGeneralOperation generalOperation
           )
        {
            _context = context;
           
            _currentUserService = currentUserService;
            _generalOperation = generalOperation;
            _hostingEnvironment = hostingEnvironment;
            _virtualPathService = virtualPathService;

        }
        public async Task<Response<string>> Handle(ExportPIMContactAttemptsHistory request, CancellationToken cancellationToken)
        {
            //new
           
            Response<string>  result = new();
            try
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (DateTime.Now.Hour == 0)
                {
                    startDate = startDate.AddDays(-1);
                }
                DateTime endDate = startDate.AddDays(1);
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateStart != null)
                {
                    var requestDateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 0, 0, 0);
                }
                if (request.SelectedDateRange != null && request.SelectedDateRange.dateEnd != null)
                {
                    var requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
                    if (request.SelectedDateRange.dateEnd == request.SelectedDateRange.dateStart)
                    {
                        requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(2);
                    }

                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 0, 0, 0);
                }


                #region filters
                List<Expression<Func<Pim_contact_attempts_historyLog, bool>>> filters = new();
                IOrderedQueryable<Pim_contact_attempts_historyLog> orderBy(IQueryable<Pim_contact_attempts_historyLog> x) => x.OrderByDescending(x => x.Call_start_time);
                filters.Add(x => x.Contact_attempt_time >= startDate && x.Contact_attempt_time <= endDate);
               
               
                if (!string.IsNullOrEmpty(request.ContactIdentityNumber))
                {
                    filters.Add(x => x.Contact.PersonalInfo.IdentityNumber.Contains(request.ContactIdentityNumber));
                }
                if (!string.IsNullOrEmpty(request.ContactName))
                {
                    filters.Add(x => x.Contact.PersonalInfo.FullNameAr.Contains(request.ContactName) );
                }
                if (!string.IsNullOrWhiteSpace(request.ContactPhone))
                {
                    filters.Add(x => x.Contact.PersonalInfo.PhoneNumber.Contains(request.ContactPhone));
                }
                if (!string.IsNullOrEmpty(request.CallStatus))
                {
                    if (request.CallStatus == "ناجحة")
                    { filters.Add(x => x.IsSuccess == true); }
                    else { filters.Add(x => x.IsSuccess == false); }
                }
                if (request.CategoryId != null)
                {
                    filters.Add(x => x.CategoryId == (request.CategoryId));
                }
                if (request.CampaignId != null)
                {
                    filters.Add(x => x.CampaignId == (request.CampaignId));
                }

                filters.Add(x => x.StateCode == 1);
                #endregion
               // DateTime ChangingTime = new DateTime(DateTime.Now.Year, 10, 29, 2, 0, 0);
                DateTime ChangingTime = new DateTime(DateTime.Now.Year, 11, 03, 2, 0, 0);
                var extra = 7;
               
                var Pim_contact_attempts_historyLog = _context.Pim_contact_attempts_historyLog.AsQueryable();
                var pagedResponse = new PagedResponse<Pim_contact_attempts_historyLog>();
              
                    pagedResponse = await Pim_contact_attempts_historyLog
                         .GetAllOnDynamicFilter(filters, orderBy);


                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                string folder = _hostingEnvironment.WebRootPath;
                string excelName = $"PIMContactAttemptsHistory-{startDate.ToString("yyyyMMdd")}-{endDate.ToString("yyyyMMdd")}.xlsx";
                if(startDate.Date == endDate.Date) { excelName = $"PIMContactAttemptsHistory-{startDate.ToString("yyyyMMdd")}.xlsx"; }
                string downloadUrl = string.Format("{0}://{1}/StaticFiles/ExportedReport/{2}", request.HttpRequest.Scheme, request.HttpRequest.Host, excelName);
                //string downloadUrl = string.Format("{0}/{2}", _hostingEnvironment.WebRootPath, excelName);
                //var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles\ExportedReport\" + excelName);
                var rootPath = _virtualPathService.GetFesicalPath("StaticFiles") + "\\" + excelName;
                FileInfo file = new FileInfo(rootPath);
                //var path = Path.Combine(@"UploadedFile\UploadCalls\", fileName);
                if (file.Exists)
                {
                    file.Delete();
                    file = new FileInfo(rootPath);
                }

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("مكالمات افايا");

                    worksheet.Cells.Style.Font.Name = "Cairo";
                    worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.DefaultRowHeight = 18;

                    int j = 1;

                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الهوية"; j++;
                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم العميل"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الموبايل"; j++;
                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم الموظف"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "حالة المكالمة"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رمز المكالمة"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم رمز المكالمة"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "بداية المكالمة"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "نهاية المكالمة"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "التصنيف"; j++;
                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الحملة"; j++;

                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(21, 149, 146));
                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Color.SetColor(Color.White);
                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Size = 14;

                    int rowNumber = 2;

                    foreach (var item in pagedResponse.Items)
                    {
                        if (item.Contact_attempt_time >= ChangingTime) { extra = 8; }
                        int columnNumber = 1;
                       // worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact?.PersonalInfo?.IdentityNumber : ""; columnNumber++;
                      //  worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact?.PersonalInfo?.FullNameAr : ""; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact?.PersonalInfo?.PhoneNumber : ""; columnNumber++;
                      //  worksheet.Cells[rowNumber, columnNumber].Value = (item.User != null) ? item.User?.PersonalInfo?.FullNameAr : ""; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Completion_Code_Name == "Default_code" || item.Completion_Code_Name == "Answer_Human" || item.Completion_Code_Name == "Answer_Machine" || item.Completion_Code_Name == "Call_Answered") ? "ناجحة" : "غير ناجحة"; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = item.Completion_Code_id.ToString(); columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = _generalOperation.GetArabicCompletationCode(item.Completion_Code_Name); columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact_attempt_time != null) ? item.Contact_attempt_time?.AddHours(extra).ToString() : ""; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Call_completion_time != null) ? item.Call_completion_time?.AddHours(extra).ToString() : ""; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.CategoryId != null) ? item.Category?.NameAr : ""; columnNumber++;
                        worksheet.Cells[rowNumber, columnNumber].Value = (item.CampaignId != null) ? item.Campaign?.NameAr : ""; columnNumber++;


                        rowNumber++;
                    }
                    package.Save();
                }

                result.Data = downloadUrl;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;

                //end

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
