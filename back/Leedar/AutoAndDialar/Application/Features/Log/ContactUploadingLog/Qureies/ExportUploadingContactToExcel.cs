
//using Application.Common.Interfaces;
//using Application.Common.Models;
//using AutoMapper;
//using Domain.Entities.Log;
//using MediatR;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using Shared.Extensions;
//using Shared.Interfaces.Services;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Log
//{
//    public class ExportUploadingContactToExcel : IRequest<Response<string>>
//    {
//        //public DateTime? StartDate { get; set; }
//        //public DateTime? EndDate { get; set; }
//        public HttpRequest HttpRequest { get; set; }
//        public int? PageIndex { get; set; }
//        public int? PageSize { get; set; }
//        public DateRangViewModel SelectedDateRange { get; set; }
//        public string ContactIdentityNumber { get; set; }
//        public string ContactName { get; set; }
//        public string ContactPhone { get; set; }
//        public Guid? CategoryId { get; set; }
//        public Guid? CampaignId { get; set; }


//        public string IsUploadedSuccessfully { get; set; }
//    }
//    public class ExportUploadingContactToExcelHandler : IRequestHandler<ExportUploadingContactToExcel, Response<string>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly AutoMapper.IMapper _mapper;
//        private readonly IHostingEnvironment _hostingEnvironment;
//        private readonly IVirtualPathService _virtualPathService;
//        private readonly ICurrentUserService _currentUserService;
//        private readonly IMailService _mailService;
//        private readonly IGeneralOperation _generalOperation;
//        public ExportUploadingContactToExcelHandler(IApplicationDbContext context, IMapper mapper, IHostingEnvironment hostingEnvironment,
//            IVirtualPathService virtualPathService,
//            ICurrentUserService currentUserService,
//            IMailService mailService,
//            IGeneralOperation generalOperation)
//        {
//            _context = context;
//            _mapper = mapper;
//            _hostingEnvironment = hostingEnvironment;
//            _virtualPathService = virtualPathService;
//            _currentUserService = currentUserService;
//            _mailService = mailService;
//            _generalOperation = generalOperation;
//        }
//        public async Task<Response<string>> Handle(ExportUploadingContactToExcel request, CancellationToken cancellationToken)
//        {
//            Response<string> result = new();
//            try
//            {

//                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
//                if (DateTime.Now.Hour == 0)
//                {
//                    startDate = startDate.AddDays(-1);
//                }
//                DateTime endDate = startDate.AddDays(1);
//                if (request.SelectedDateRange != null && !request.SelectedDateRange.dateStart.IsNullOrDefault<DateTime>())
//                {
//                    var requestDateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
//                    startDate = new DateTime(requestDateStart.Year, requestDateStart.Month, requestDateStart.Day, 2, 0, 0);
//                }
//                if (request.SelectedDateRange != null && !request.SelectedDateRange.dateEnd.IsNullOrDefault<DateTime>())
//                {
//                    var requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
//                    if (request.SelectedDateRange.dateEnd == request.SelectedDateRange.dateStart)
//                    {
//                        requestDateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(2);
//                    }

//                    endDate = new DateTime(requestDateEnd.Year, requestDateEnd.Month, requestDateEnd.Day, 2, 0, 0);
//                }
//                var ContactUploadingLog =  _context.ContactUploadingLog.Where(x => x.CategoryId != Guid.Parse("AD1F2CB4-F26F-4040-B276-AF0600F82A28")).AsQueryable();
//                ContactUploadingLog = ContactUploadingLog
//                   .Where(x =>
//               x.CreatedOn >= startDate &&
//               x.CreatedOn <= endDate);
//                #region filters
              


//                if (!string.IsNullOrEmpty(request.ContactIdentityNumber))
//                {
//                    ContactUploadingLog = ContactUploadingLog.Where(x => x.Contact.PersonalInfo.IdentityNumber.Contains(request.ContactIdentityNumber));
//                }
//                if (!string.IsNullOrEmpty(request.ContactName))
//                {
//                    ContactUploadingLog = ContactUploadingLog.Where(x => x.Contact.PersonalInfo.FullNameAr.Contains(request.ContactName) ||
//                                     x.Contact.PersonalInfo.FullNameEn.Contains(request.ContactName));
//                }
//                if (!string.IsNullOrWhiteSpace(request.ContactPhone))
//                {
//                    ContactUploadingLog = ContactUploadingLog.Where(x => x.Contact.PersonalInfo.PhoneNumber.Contains(request.ContactPhone) ||
//                                     x.Contact.PersonalInfo.PhoneNumber2.Contains(request.ContactPhone));
//                }
//                //if (!string.IsNullOrEmpty(request.IsUploadedSuccessfully))
//                //{
//                //    if (request.IsUploadedSuccessfully == "yes")
//                //    { filters.Add(x => x.IsUploadedSuccessfully == true); }
//                //    else { filters.Add(x => x.IsUploadedSuccessfully == false); }
//                //}
//                if (!request.CategoryId.IsNullOrDefault<Guid>())
//                {
//                    ContactUploadingLog = ContactUploadingLog.Where(x => x.CategoryId == (request.CategoryId));
//                }
//                if (!request.CampaignId.IsNullOrDefault<Guid>())
//                {
//                    ContactUploadingLog = ContactUploadingLog.Where(x => x.CampaignId == (request.CampaignId));
//                }

//                ContactUploadingLog = ContactUploadingLog.Where(x=>x.IsUploadedSuccessfully==false);
//                #endregion



//                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
//                string folder = _hostingEnvironment.WebRootPath;
//                string excelName = $"ContactUploadingFailed-{request.SelectedDateRange.dateStart.Value.ToString("yyyyMMdd")}-{request.SelectedDateRange.dateEnd.Value.ToString("yyyyMMdd")}.xlsx";
//                string downloadUrl = string.Format("{0}://{1}/StaticFiles/ExportedReport/{2}", request.HttpRequest.Scheme, request.HttpRequest.Host, excelName);
//                //string downloadUrl = string.Format("{0}/{2}", _hostingEnvironment.WebRootPath, excelName);
//                //var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles\ExportedReport\" + excelName);
//                var rootPath = _virtualPathService.GetFesicalPath("StaticFiles") + "\\" + excelName;
//                FileInfo file = new FileInfo(rootPath);
//                //var path = Path.Combine(@"UploadedFile\UploadCalls\", fileName);
//                if (file.Exists)
//                {
//                    file.Delete();
//                    file = new FileInfo(rootPath);
//                }

//                using (ExcelPackage package = new ExcelPackage(file))
//                {
//                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Not Uploaded");
//                    worksheet.Cells.Style.Font.Name = "Cairo";
//                    worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                    worksheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    worksheet.DefaultRowHeight = 18;

//                    int j = 1;

//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الهوية"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم المستفيد"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الجوال"; j++;
                   
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم الملف"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم السطر"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "سبب الرفض"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الوصف"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الموظف"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "تاريخ التحميل"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "التصنيف"; j++;
//                     worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الحملة"; j++;
 

//                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "التصنيف"; j++;
//                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الحملة"; j++;
//                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم الموظف"; j++;
//                    //worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم قائد الفريق"; j++;

//                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(21, 149, 146));
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Color.SetColor(Color.White);
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Size = 14;

//                    int rowNumber = 2;
//                    int columnNumber = 1;
//                    foreach (var item in ContactUploadingLog)
//                    {
//                        columnNumber = 1;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact.PersonalInfo.IdentityNumber : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact.PersonalInfo.FullNameAr : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Contact != null) ? item.Contact.PersonalInfo.PhoneNumber : ""; columnNumber++;
                        
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.FileName != null) ? item.FileName : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.FileRow; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.Description != null) ? item.Description : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.DescriptionOthers != null) ? item.DescriptionOthers : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.CreatedByUser != null) ? item.CreatedByUser.PersonalInfo.FullNameAr : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.CreatedOn.ToString(); columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.CategoryId != null) ? item.Category.NameAr : ""; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = (item.CampaignId != null) ? item.Campaign.NameAr : ""; columnNumber++;

//                        rowNumber++;
//                    }

//                    package.Save();
//                }

//                //try
//                //{
//                //    string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\" + "GeneralReport.html";
//                //    StreamReader str = new StreamReader(FilePath);
//                //    string MailText = str.ReadToEnd();
//                //    str.Close();
//                //    MailText = MailText.Replace("[URLLink]", downloadUrl);
//                //    MailText = MailText.Replace("[ReportStartDate]", request.SelectedDateRange.dateStart.Value.ToString("yyyy-MM-dd"));
//                //    MailText = MailText.Replace("[ReportEndDate]", request.SelectedDateRange.dateEnd.Value.ToString("yyyy-MM-dd"));

//                //    if (request.EmailsList != null && request.EmailsList.Any())
//                //    {
//                //        await _mailService.SendEmail(new Shared.DTOs.Email.EmailRequest
//                //        {
//                //            ToEmails = request.EmailsList,
//                //            Subject = "تقرير عن نتائج المكالمات",
//                //            Body = MailText,
//                //        });
//                //    }
//                //}
//                //catch (Exception)
//                //{
//                //}



//                result.Data = downloadUrl;
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                result.Succeeded = true;




              
//                return result;


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

