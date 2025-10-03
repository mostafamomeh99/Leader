//namespace Application.Features.Application.Contact.Queries
//{
//    using Domain.Entities.Application;
//    using global::Application.Common.Interfaces;
//    using global::Application.Common.Models;
//    using global::Application.Extensions;
//    using AutoMapper;
//    using MediatR;
//    using Microsoft.AspNetCore.Hosting;
//    using Microsoft.AspNetCore.Http;
//    using Microsoft.EntityFrameworkCore;
//    using OfficeOpenXml;
//    using OfficeOpenXml.Style;
//    using Shared.Extensions;
//    using Shared.Globalization;
//    using Shared.ViewModels;
//    using Shared.Wrappers;
//    using System;
//    using System.Collections.Generic;
//    using System.Drawing;
//    using System.Globalization;
//    using System.IO;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using System.Text;
//    using System.Threading;
//    using System.Threading.Tasks;
//    public class ExportByFilter : IRequest<Response<string>>
//    {
//        public HttpRequest HttpRequest { get; set; }
//        public int? PageIndex { get; set; }
//        public int? PageSize { get; set; }

//        public string IdentityNumber { get; set; }
//        public string PhoneNumber { get; set; }
//        public string DisplayName { get; set; }
//        public string NetSalary { get; set; }
//        public Guid? StumbleTypeId { get; set; }

//        public Guid ArrearsOperation { get; set; }
//        public double? Arrears { get; set; }

//        public Guid NumberOfLateInstallmentsOperation { get; set; }
//        public int? NumberOfLateInstallments { get; set; }

//        public Guid? LatestCallCreatedOnOperation { get; set; }
//        //  public DateTime? LatestCallCreatedOn { get; set; }

//        public Guid? LatestCallStatusId { get; set; }
//        public string EmployerType { get; set; }

//        public DateRangViewModel LatestCallCreatedOn { get; set; }

//        public Guid HistoricalCallCountOperation { get; set; }
//        public int? HistoricalCallCount { get; set; }
//        public byte? StateCode { get; set; }
//    }
//    public class ExportByFilterHandler : IRequestHandler<ExportByFilter, Response<string>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly ICurrentUserService _currentUserService;
//        private readonly IHostingEnvironment _hostingEnvironment;
//        private readonly IVirtualPathService _virtualPathService;
//        public ExportByFilterHandler(IApplicationDbContext context,
//            IHostingEnvironment hostingEnvironment,
//             IVirtualPathService virtualPathService,
//            IMapper mapper, ICurrentUserService currentUserService)
//        {
//            _context = context;
//            _mapper = mapper;
//            _currentUserService = currentUserService;
//            _hostingEnvironment = hostingEnvironment;
//            _virtualPathService = virtualPathService;
//        }
//        public async Task<Response<string>> Handle(ExportByFilter request, CancellationToken cancellationToken)
//        {
//            Response<string> result = new();
//            try
//            {
//                #region filters
//                List<Expression<Func<Contact, bool>>> filters = new();
//                IOrderedQueryable<Contact> orderBy(IQueryable<Contact> x) => x.OrderByDescending(x => x.CreatedOn);
//                if (!string.IsNullOrEmpty(request.IdentityNumber))
//                {
//                    filters.Add(x => x.PersonalInfo.IdentityNumber.Contains(request.IdentityNumber));
//                }
//                if (!string.IsNullOrEmpty(request.PhoneNumber))
//                {
//                    filters.Add(x => x.PersonalInfo.PhoneNumber.Contains(request.PhoneNumber) ||
//                                     x.PersonalInfo.PhoneNumber2.Contains(request.PhoneNumber));
//                }
//                if (!string.IsNullOrWhiteSpace(request.DisplayName))
//                {
//                    filters.Add(x => x.PersonalInfo.FullNameAr.Contains(request.DisplayName) ||
//                                     x.PersonalInfo.FullNameEn.Contains(request.DisplayName));
//                }
//                if (!string.IsNullOrWhiteSpace(request.NetSalary))
//                {
//                    filters.Add(x => x.NetSalary.Contains(request.NetSalary));
//                }
//                if (request.StumbleTypeId != null)
//                {
//                    if (request.StumbleTypeId == Guid.Empty)
//                    {
//                        filters.Add(x => x.StumbleTypeId == null);
//                    }
//                    else
//                    {
//                        filters.Add(x => x.StumbleTypeId == request.StumbleTypeId);
//                    }
//                }
//                if (request.Arrears != null)
//                {
//                    switch (request.ArrearsOperation.ToString().ToLower())
//                    {
//                        case Shared.Struct.EntitiesString.ConditionType.Equal:
//                            filters.Add(x => x.Contracts.Any(y => y.Arrears == request.Arrears));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
//                            filters.Add(x => x.Contracts.Any(y => y.Arrears != request.Arrears));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
//                            filters.Add(x => x.Contracts.Any(y => y.Arrears > request.Arrears));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.LessThan:
//                            filters.Add(x => x.Contracts.Any(y => y.Arrears < request.Arrears));
//                            break;
//                    }
//                }



//                if (request.LatestCallCreatedOnOperation != null &&
//                    request.LatestCallCreatedOn.dateStart != null &&
//                    request.LatestCallCreatedOn.dateEnd != null)

//                {
//                    if (!request.LatestCallCreatedOn.dateStart.IsNullOrDefault<DateTime>())
//                    {
//                        filters.Add(x =>
//                           x.HistoricalCalls.Count() > 0
//                           && x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date >= request.LatestCallCreatedOn.dateStart.Value.Date.AddDays(1));
//                    }
//                    if (!request.LatestCallCreatedOn.dateEnd.IsNullOrDefault<DateTime>())
//                    {
//                        filters.Add(x =>
//                            x.HistoricalCalls.Count() > 0 &&
//                            x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date <= request.LatestCallCreatedOn.dateEnd.Value.Date.AddDays(1));
//                    }
//                }
//                else
//                {
//                    if (request.StumbleTypeId == null)
//                    {
//                        request.LatestCallCreatedOn = new DateRangViewModel
//                        {
//                            dateStart = DateTime.Now,
//                            dateEnd = DateTime.Now,
//                        };
//                        // request.LatestCallCreatedOn.dateEnd = DateTime.Now;
//                        filters.Add(x =>
//                                x.HistoricalCalls.Count() > 0 &&
//                                x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date == request.LatestCallCreatedOn.dateStart.Value.Date);


//                    }
//                }





//                if (request.NumberOfLateInstallments != null)
//                {
//                    switch (request.NumberOfLateInstallmentsOperation.ToString().ToLower())
//                    {
//                        case Shared.Struct.EntitiesString.ConditionType.Equal:
//                            filters.Add(x => x.Contracts.Any(y => y.NumberOfLateInstallments == request.NumberOfLateInstallments));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
//                            filters.Add(x => x.Contracts.Any(y => y.NumberOfLateInstallments != request.NumberOfLateInstallments));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
//                            filters.Add(x => x.Contracts.Any(y => y.NumberOfLateInstallments > request.NumberOfLateInstallments));
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.LessThan:
//                            filters.Add(x => x.Contracts.Any(y => y.NumberOfLateInstallments < request.NumberOfLateInstallments));
//                            break;
//                    }
//                }

//                //if (request.LatestCallCreatedOn != null)
//                //{
//                //    switch (request.LatestCallCreatedOnOperation.ToString().ToLower())
//                //    {
//                //        case Shared.Struct.EntitiesString.ConditionType.Equal:
//                //            filters.Add(x =>
//                //            x.HistoricalCalls.Count() > 0 &&
//                //            x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date == request.LatestCallCreatedOn.Value.Date);
//                //            break;
//                //        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
//                //            filters.Add(x =>
//                //         x.HistoricalCalls.Count() > 0 &&
//                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date != request.LatestCallCreatedOn.Value.Date);
//                //            break;
//                //        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
//                //            filters.Add(x =>
//                //         x.HistoricalCalls.Count() > 0 &&
//                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date > request.LatestCallCreatedOn.Value.Date);
//                //            break;
//                //        case Shared.Struct.EntitiesString.ConditionType.LessThan:
//                //            filters.Add(x =>
//                //         x.HistoricalCalls.Count() > 0 &&
//                //         x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CreatedOn.Date < request.LatestCallCreatedOn.Value.Date);
//                //            break;
//                //    }
//                //}

//                if (request.LatestCallStatusId != null)
//                {
//                    filters.Add(x =>
//                    x.HistoricalCalls.Count() > 0 &&
//                    x.HistoricalCalls.OrderByDescending(y => y.CreatedOn).FirstOrDefault().CallStatusId == request.LatestCallStatusId);
//                }

//                if (!string.IsNullOrWhiteSpace(request.EmployerType))
//                {
//                    filters.Add(x => x.EmployerType.NameAr.Contains(request.EmployerType) ||
//                                     x.EmployerType.NameEn.Contains(request.EmployerType));
//                }
//                if (request.HistoricalCallCount != null)
//                {
//                    switch (request.HistoricalCallCountOperation.ToString().ToLower())
//                    {
//                        case Shared.Struct.EntitiesString.ConditionType.Equal:
//                            filters.Add(x => x.HistoricalCalls.Count() == request.HistoricalCallCount);
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.NotEqual:
//                            filters.Add(x => x.HistoricalCalls.Count() != request.HistoricalCallCount);
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.MoreThan:
//                            filters.Add(x => x.HistoricalCalls.Count() > request.HistoricalCallCount);
//                            break;
//                        case Shared.Struct.EntitiesString.ConditionType.LessThan:
//                            filters.Add(x => x.HistoricalCalls.Count() < request.HistoricalCallCount);
//                            break;
//                    }


//                }

//                //if (request.AssignToUserAtDateRange != null)
//                //{
//                //    if (request.AssignToUserAtDateRange.DateStart != null &&
//                //          request.AssignToUserAtDateRange.DateEnd != null)
//                //    {
//                //        filters.Add(x =>
//                //           x.AssignToUserAt.Value.Date >= request.AssignToUserAtDateRange.DateStart &&
//                //           x.AssignToUserAt.Value.Date <= request.AssignToUserAtDateRange.DateStart
//                //           );
//                //    }
//                //}

//                //filters.Add(x => x.IsStatic != true);
//                if (request.StateCode != null)
//                {
//                    filters.Add(x => x.StateCode == request.StateCode);
//                }
//                else
//                {
//                    filters.Add(x => x.StateCode == 1);
//                }

//                #endregion

//                var Contact = _context.Contact.AsQueryable();
//                //.Include(x => x.PersonalInfo)
//                //.Include(x => x.StumbleType)
//                //.Include(x => x.EmployerType)
//                //.Include(x => x.LatestSatisfaction);
//                var pagedResponse = new PagedResponse<Contact>();
//                //if (!request.PageIndex.IsNullOrDefault<int>() && !request.PageSize.IsNullOrDefault<int>())
//                //{
//                //    pagedResponse = await Contact
//                //          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
//                //}
//                //else
//                //{
//                //    pagedResponse = await Contact
//                //         .GetAllOnDynamicFilter(filters, orderBy);
//                //}
//                pagedResponse = await Contact
//                    .GetAllOnDynamicFilter(filters, orderBy);
//                // result.Data = new PagedResponse<ByFilterVM>
//                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

//                //var ContactReport = new ByFilterVM
//                //{
//                //    Items =
//                //    //  Items = CultureHelper.IsArabic ?
//                //    pagedResponse.Items.Select(x => new ByFilterVM


//                //    {
//                //        Id = x.Id,
//                //        IdentityNumber = x.PersonalInfo.IdentityNumber,
//                //        DisplayName = x.PersonalInfo.FullNameAr,
//                //        PhoneNumber = x.PersonalInfo.PhoneNumber,
//                //        PhoneNumber2 = x.PersonalInfo.PhoneNumber2,
//                //        StumbleTypeId = x.StumbleTypeId,
//                //        StumbleType = x.StumbleType?.NameAr,
//                //        Arrears = x.Contracts.Sum(y => y.Arrears).ToString("C", new CultureInfo("ar-SA")),
//                //        NumberOfLateInstallments = x.Contracts.Sum(y => y.NumberOfLateInstallments).ToString(),
//                //        LatestCallCreatedOn = x.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"),
//                //        LatestCallStatus = x.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.CallStatus.NameAr,
//                //        HistoricalCallCount = x.HistoricalCalls.Count(),

//                //    }).ToList()


//                //:
//                //pagedResponse.Items.Select(x => new ByFilterVM
//                //{
//                //    Id = x.Id,
//                //    IdentityNumber = x.PersonalInfo.IdentityNumber,

//                //    DisplayName = x.PersonalInfo.FullNameEn,
//                //    PhoneNumber = x.PersonalInfo.PhoneNumber,
//                //    Notes = x.Notes,
//                //    PhoneNumber2 = x.PersonalInfo.PhoneNumber2,
//                //    Age = x.PersonalInfo.Age,
//                //    NetSalary = x.NetSalary,
//                //    StumbleTypeId = x.StumbleTypeId,
//                //    StumbleType = x.StumbleType?.NameEn,
//                //    Arrears = x.Contracts.Sum(y => y.Arrears).ToString("C", new CultureInfo("ar-SA")),
//                //    NumberOfLateInstallments = x.Contracts.Sum(y => y.NumberOfLateInstallments).ToString(),
//                //    LatestCallCreatedOn = x.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"),
//                //    LatestCallStatus = x.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault()?.CallStatus.NameAr,
//                //    HistoricalCallCount = x.HistoricalCalls.Count(),
//                //}).ToList()

//                //PageIndex = pagedResponse.PageIndex,
//                //PageItemsEnd = pagedResponse.PageItemsEnd,
//                //PageItemsStart = pagedResponse.PageItemsStart,
//                //PageSize = pagedResponse.PageSize,
//                //Succeeded = true,
//                //TotalItems = pagedResponse.TotalItems,
//                //TotalPages = pagedResponse.TotalPages,
//                //HttpStatusCode = System.Net.HttpStatusCode.OK,




//                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
//                string folder = _hostingEnvironment.WebRootPath;
//                string excelName = $"ContactReport-{request.LatestCallCreatedOn.dateStart?.ToString("yyyyMMdd") ?? "C_Filter"}-{request.LatestCallCreatedOn.dateEnd?.ToString("yyyyMMdd") ?? "C_Filter"}.xlsx";
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

//                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ContactReport");

//                    worksheet.Cells.Style.Font.Name = "Cairo";
//                    worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                    worksheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    worksheet.DefaultRowHeight = 18;

//                    int j = 1;

//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الهوية"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "اسم المستفيد"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "رقم الموبايل"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "حالة التعثر"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "المتاخرات"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "الأقساط المتأخرة"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "تاريخ آخر مكالمة	"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "حالة آخر مكالمة	"; j++;
//                    worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "عدد المكالمات السابقة"; j++;
//                    // worksheet.Column(j).Width = 20; worksheet.Cells[1, j].Value = "حالة الدفع"; j++;

//                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(21, 149, 146));
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Color.SetColor(Color.White);
//                    worksheet.Cells[1, 1, 1, j - 1].Style.Font.Size = 14;

//                    int rowNumber = 2;




//                    foreach (var item in pagedResponse.Items)
//                    {
//                        var LatestCal = item.HistoricalCalls.OrderByDescending(x => x.CreatedOn).FirstOrDefault();





//                        int columnNumber = 1;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.PersonalInfo.IdentityNumber; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.PersonalInfo.FullNameAr; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.PersonalInfo.PhoneNumber; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.StumbleType?.NameAr; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.Contracts.Sum(y => y.Arrears).ToString("C", new CultureInfo("ar-SA")); columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.Contracts.Sum(y => y.NumberOfLateInstallments).ToString(); columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = LatestCal?.CreatedOn.ToString("yyyy/MM/dd hh:mm:ss"); columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = LatestCal?.CallStatus.NameAr; columnNumber++;
//                        worksheet.Cells[rowNumber, columnNumber].Value = item.HistoricalCalls.Count; columnNumber++;
//                        //worksheet.Cells[rowNumber, columnNumber].Value = item.IsPaidString; columnNumber++;
//                        //worksheet.Cells[rowNumber, columnNumber].Value = item.HistoricalCallId; columnNumber++;

//                        rowNumber++;

//                    }




//                    package.Save();
//                }

//                result.Data = downloadUrl;
//                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                result.Succeeded = true;


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