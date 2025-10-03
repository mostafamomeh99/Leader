//using Application.Common.Interfaces;
//using Application.Common.Models;
//using AutoMapper;
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
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Log.pim_contact_attempts_history.Queries
//{
//    public class ExportHistoricalCallReport : IRequest<Response<string>>
//    {
//        public HttpRequest HttpRequest { get; set; }
//        public DateRangViewModel SelectedDateRange { get; set; }
//        public string ContactIdentityNumber { get; set; }
//        public string ContactName { get; set; }
//        public string ContactPhone { get; set; }
//        public List<Guid> CategoryIds { get; set; }
//        public List<Guid> CampaignIds { get; set; }
//        public bool? IsBillCreatedInCall { get; set; }
//        public List<Guid> UserIds { get; set; }
//        public List<Guid> TeamIds { get; set; }
//        //public List<Guid> CallStatusIds { get; set; }

//        public List<string> EmailsList { get; set; }
//    }
//    public class ExportHistoricalCallReportHandler : IRequestHandler<ExportHistoricalCallReport, Response<string>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly AutoMapper.IMapper _mapper;
//        private readonly IHostingEnvironment _hostingEnvironment;
//        private readonly IVirtualPathService _virtualPathService;
//        private readonly ICurrentUserService _currentUserService;
//        private readonly IMailService _mailService;

//        public ExportHistoricalCallReportHandler(IApplicationDbContext context, IMapper mapper, IHostingEnvironment hostingEnvironment,
//            IVirtualPathService virtualPathService,
//            ICurrentUserService currentUserService,
//            IMailService mailService)
//        {
//            _context = context;
//            _mapper = mapper;
//            _hostingEnvironment = hostingEnvironment;
//            _virtualPathService = virtualPathService;
//            _currentUserService = currentUserService;
//            _mailService = mailService;
//        }
//        public async Task<Response<string>> Handle(ExportHistoricalCallReport request, CancellationToken cancellationToken)
//        {
//            Response<string> result = new();
//            try
//            {
//                var currantUser = await _context.GetCurrentUser();
//                var isTeamLeader = currantUser.RoleIds.Contains(Shared.Struct.Roles.Leader);
//                if (isTeamLeader)
//                {
//                    request.TeamIds = await _context.Team.Where(x => x.LeaderId == _currentUserService.UserId.Value).Select(x => x.Id).ToListAsync();
//                }
//                var Pim_contact_attempts_history = _context.Pim_contact_attempts_history.AsQueryable();
//                if (!request.SelectedDateRange.dateStart.IsNullOrDefault<Guid>())
//                {
//                    request.SelectedDateRange.dateStart = request.SelectedDateRange.dateStart.Value.AddDays(1);
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => x.CreatedOn.Date >= request.SelectedDateRange.dateStart.Value.Date);
//                }
//                if (!request.SelectedDateRange.dateEnd.IsNullOrDefault<Guid>())
//                {
//                    request.SelectedDateRange.dateEnd = request.SelectedDateRange.dateEnd.Value.AddDays(1);
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => x.CreatedOn.Date <= request.SelectedDateRange.dateEnd.Value.Date);
//                }
//                if (request.TeamIds.Any())
//                {
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => x.User.UserTeams.Any(y => request.TeamIds.Contains(y.TeamId)));
//                }
//                if (request.UserIds != null && request.UserIds.Any())
//                {
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => request.UserIds.Contains(x.UserId.Value));
//                }
//                //if (request.CallStatusIds != null && request.CallStatusIds.Any())
//                //{
//                //    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => request.CallStatusIds.Contains(x.CallStatusId));
//                //}
//                if (request.CategoryIds != null && request.CategoryIds.Any())
//                {
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => request.CategoryIds.Contains(x.CategoryId.Value));
//                }
//                if (request.CampaignIds != null && request.CampaignIds.Any())
//                {
//                    Pim_contact_attempts_history = Pim_contact_attempts_history.Where(x => request.CampaignIds.Contains(x.CampaignId.Value));
//                }

//                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
//                string folder = _hostingEnvironment.WebRootPath;
//                string excelName = $"HistoricalCallAVAYAGeneralReport-{request.SelectedDateRange.dateStart.Value.ToString("yyyyMMdd")}-{request.SelectedDateRange.dateEnd.Value.ToString("yyyyMMdd")}.xlsx";
//                string downloadUrl = string.Format("{0}://{1}/StaticFiles/ExportedReport/{2}", request.HttpRequest.Scheme, request.HttpRequest.Host, excelName);
//                var rootPath = _virtualPathService.GetFesicalPath("StaticFiles") + "\\" + excelName;
//                FileInfo file = new FileInfo(rootPath);
//                if (file.Exists)
//                {
//                    file.Delete();
//                    file = new FileInfo(rootPath);
//                }

//                using (ExcelPackage package = new ExcelPackage(file))
//                {
//                    var allCategoryPathIds = Pim_contact_attempts_history.GroupBy(x => x.Category.CategoryPathId).Select(x => x.Key);
//                    if (allCategoryPathIds.Any())
//                    {
//                        foreach (var categoryPathId in allCategoryPathIds)
//                        {
//                            var categoryPath = await _context.CategoryPath.Where(x => x.Id == categoryPathId).FirstOrDefaultAsync();
//                            var allCategoryPathFields = _context.EntityField.Where(x =>
//                                x.EntityFieldGroup.Entity.EntityTypeId == Shared.Struct.Entities.Lookup.CategoryPath &&
//                                x.EntityFieldGroup.Entity.RelatedEntityPK == categoryPathId &&
//                                x.FieldTypeId != Shared.Struct.FieldType.Label &&
//                                x.FieldTypeId != Shared.Struct.FieldType.Button &&
//                                x.StateCode != 0
//                                ).OrderBy(x => x.EntityFieldGroup.ViewOrder).ThenBy(x => x.ViewOrder);

//                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(categoryPath.NameAr);

//                            worksheet.Cells.Style.Font.Name = "Cairo";
//                            worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                            worksheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                            worksheet.DefaultRowHeight = 18;

//                            int j = 1;

//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "رقم الهوية"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "اسم المستفيد"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "رقم الجوال"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "رقم الجوال 2"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "قيمة الأقساط المتأخرة"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "عدد الأقساط المتأخرة"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "حالة التعثر"; j++;
//                            worksheet.Cells[1, 1, 1, j - 1].Merge = true;
//                            worksheet.Cells[1, 1].Value = "معلومات المستفيد";
//                            worksheet.Cells[1, 1, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                            worksheet.Cells[1, 1, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(161, 171, 174));
//                            worksheet.Cells[1, 1, 1, j - 1].Style.Font.Color.SetColor(Color.White);
//                            worksheet.Cells[1, 1, 1, j - 1].Style.Font.Size = 14;
//                            int jAfterMearg = j;
//                            foreach (var item in allCategoryPathFields)
//                            {
//                                worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = item.NameAr; j++;
//                            }
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "اسم التصنيف"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "اسم الحملة"; j++;


//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Merge = true;
//                            worksheet.Cells[1, jAfterMearg].Value = "معلومات مسار المكالمة";

//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(211, 186, 141));
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Font.Color.SetColor(Color.White);
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Font.Size = 14;

//                            jAfterMearg = j;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "اسم الموظف"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "اسم قائد الفريق"; j++;
//                            worksheet.Column(j).Width = 20; worksheet.Cells[2, j].Value = "تاريخ الاتصال"; j++;


//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Merge = true;
//                            worksheet.Cells[1, jAfterMearg].Value = "معلومات الموظف";

//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(12, 136, 173));
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Font.Color.SetColor(Color.White);
//                            worksheet.Cells[1, jAfterMearg, 1, j - 1].Style.Font.Size = 14;


//                            worksheet.Cells[2, 1, 2, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                            worksheet.Cells[2, 1, 2, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(21, 149, 146));
//                            worksheet.Cells[2, 1, 2, j - 1].Style.Font.Color.SetColor(Color.White);
//                            worksheet.Cells[2, 1, 2, j - 1].Style.Font.Size = 14;


//                            int rowNumber = 3;
//                            int columnNumber = 1;
//                            var historicalCalls = Pim_contact_attempts_history.Where(x => x.Category.CategoryPathId == categoryPathId);
//                            foreach (var historicalCallItem in historicalCalls)
//                            {
//                                //var historicalCallItem = await _context.HistoricalCall.FindAsync(historicalCallItemId);
//                                columnNumber = 1;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.PersonalInfo?.IdentityNumber; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.PersonalInfo?.FullNameAr; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.PersonalInfo?.PhoneNumber; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.PersonalInfo?.PhoneNumber2; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.Contracts.Sum(x => x.AmountOfLateInstallments); columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.Contracts.Sum(x => x.NumberOfLateInstallments); columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Contact?.StumbleType?.NameAr; columnNumber++;

                               
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Category.NameAr; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.Campaign.NameAr; columnNumber++;


//                                //worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.AssignToUser?.PersonalInfo.FullNameAr; columnNumber++;
//                                //worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.AssignToUser?.DirectLeader?.PersonalInfo.FullNameAr; columnNumber++;
//                                worksheet.Cells[rowNumber, columnNumber].Value = historicalCallItem?.CreatedOn; columnNumber++;

//                                rowNumber++;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("report");
//                    }
//                    package.Save();
//                }

//                try
//                {
//                    string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\" + "GeneralReport.html";
//                    StreamReader str = new StreamReader(FilePath);
//                    string MailText = str.ReadToEnd();
//                    str.Close();
//                    MailText = MailText.Replace("[URLLink]", downloadUrl);
//                    MailText = MailText.Replace("[ReportStartDate]", request.SelectedDateRange.dateStart.Value.ToString("yyyy-MM-dd"));
//                    MailText = MailText.Replace("[ReportEndDate]", request.SelectedDateRange.dateEnd.Value.ToString("yyyy-MM-dd"));

//                    if (request.EmailsList != null && request.EmailsList.Any())
//                    {
//                        await _mailService.SendEmail(new Shared.DTOs.Email.EmailRequest
//                        {
//                            ToEmails = request.EmailsList,
//                            Subject = "تقرير عن نتائج المكالمات",
//                            Body = MailText,
//                        });
//                    }
//                }
//                catch (Exception)
//                {
//                }



//                result.Data = downloadUrl;
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                result.Succeeded = true;




//                //package.Save();

//                //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=CallsDetails"+DateTime.Now.ToString("yyyy_MM_dd")+".xlsx");

//                //memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
//                //HttpContext.Current.Response.Flush();
//                //HttpContext.Current.Response.End();
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
