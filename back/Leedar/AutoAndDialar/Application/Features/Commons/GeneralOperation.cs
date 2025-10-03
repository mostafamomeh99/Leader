using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Extensions;
using Application.Features.Identity.User;
using Application.Features.Identity.User.Queries;
using AutoMapper;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Lookup;
using Infrastructure.Interfaces;
//using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
//using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using Shared.Extensions;
using Shared.Globalization;
using Shared.Settings;
using Shared.Struct;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Shared.Struct.Permission;

namespace Application.Features.Commons
{
    public class GeneralOperation : IGeneralOperation
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly AVAYAPOMSettings _AVAYAPOMSettings;
        private CurrantUserViewModel currantUser;

        public GeneralOperation(IApplicationDbContext context, IContextCurrentUserService currentUserService, IMapper mapper, AVAYAPOMSettings aVAYAPOMSettings)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _AVAYAPOMSettings = aVAYAPOMSettings;
        }
        public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
        public async Task<CurrantUserViewModel> GetCurrentUser()
        {
            if (currantUser != null)
            {
                return currantUser;
            }
            else
            {
                if (_currentUserService.UserId != null)
                {
                    CurrantUserViewModel result = new();

                    var user = await _context.User.Where(x => x.Id == _currentUserService.UserId)
                       
                        .Include(x => x.UserPermissions)
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync();
                    if(user!= null) {
                        result = new CurrantUserViewModel
                        {

                            FullName = user?.PersonalInfo?.FullNameAr ?? "",

                            Id = user.Id,
                            IdentityNumber = user?.PersonalInfo?.IdentityNumber,
                            PhoneNumber = user.PersonalInfo?.PhoneNumber,
                            Email = user.UserName,
                           
                            Permissions = user.UserPermissions?.Select(x => x.PermissionId).ToList(),
                            RoleIds = user.Roles?.Select(x => x.RoleId).ToList(),
                        };
                        //var roles = await _userManager.GetRolesAsync(user);
                        foreach (var item in user.Roles)
                        {
                            //var role = await _roleManager.Roles.Where(x => x.Name == item).FirstOrDefaultAsync();
                            var rolePermesionIds = _context.RolePermission.Where(x => x.RoleId == item.RoleId).Select(x => x.PermissionId).ToList();
                            result.Permissions = result.Permissions.Concat(rolePermesionIds).Distinct().ToList();
                        }
                        currantUser = result;
                        return result;
                    }
                   
                }
            }

            return null;
        }



        public async Task<PagedResponse<SelectListItem>> GetEntityValueAsSelectedLsitItem(Guid entityTypeId, byte? stateCode, Guid? ProjectId = null, Guid? ticketTypeId = null)
        {
            var stringEntityTypeId = entityTypeId.ToString().ToLower();
            PagedResponse<SelectListItem> result = new();
            switch (stringEntityTypeId)
            {

                case Shared.Struct.EntitiesString.Lookup.Category:
                    break;
                default:
                    break;
            }

            return result;
        }
        public async Task<string> GetStringValueForGuidOption(Guid FeildId, string Value)
        {
            var Feild = await _context.EntityField.FindAsync(FeildId);
            var entityOfCategoryPath_EntityField_Option = Feild?.EntityFieldOptions?
       .FirstOrDefault(x => x.Id.ToString().ToLower() == Value.ToLower());
            if (entityOfCategoryPath_EntityField_Option != null)
            {
                return entityOfCategoryPath_EntityField_Option.NameAr;
            }
            else
            {
                return Value;
            }
        }
        public bool CompareTwoString(string oldstr, string newstr)
        {
            // StringBuilder sb = new StringBuilder();
            //foreach (char c in str)
            //{
            //    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= 'ا' && c <= 'ي'))
            //    {
            //        sb.Append(c);
            //    }
            //}
            string group_String = Regex.Replace(oldstr, @"[^\u0621-\u064A]+", "");
            string ques_String = Regex.Replace(newstr, @"[^\u0621-\u064A]+", "");

            int _diffCount = 0;

            if (group_String.Length == ques_String.Length)
            {
                for (int i = 0; i < group_String.Length; i++)
                {
                    if (group_String[i] != ques_String[i])
                    {
                        _diffCount++;
                    }
                }

                if (_diffCount <= 1)
                {
                    return true;
                }
            }
            return false;

        }
        public bool CalculateCondition(string firstValue, string secondValue, Guid conditionTypeId)
        {
            bool conditionResult = false;
            if (conditionTypeId == Shared.Struct.ConditionType.Equal)
            {
                conditionResult = (firstValue == secondValue);
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.NotEqual)
            {
                conditionResult = (firstValue != secondValue);
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.NotNull)
            {
                conditionResult = !string.IsNullOrEmpty(secondValue) || !string.IsNullOrEmpty(firstValue);
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.Null)
            {
                conditionResult = string.IsNullOrEmpty(secondValue);
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.Contain)
            {
                // TODO Check
                conditionResult = (firstValue.Contains(secondValue));
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.LessThan)
            {
                try
                {
                    var doubleValue = double.Parse(firstValue);
                    var doubleConditionValue = double.Parse(secondValue);
                    conditionResult = (doubleValue < doubleConditionValue);
                }
                catch (Exception)
                {
                }

            }
            else if (conditionTypeId == Shared.Struct.ConditionType.LessThanOrEqual)
            {
                try
                {
                    var doubleValue = double.Parse(firstValue);
                    var doubleConditionValue = double.Parse(secondValue);
                    conditionResult = (doubleValue <= doubleConditionValue);
                }
                catch (Exception)
                {
                }
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.MoreThan)
            {
                try
                {
                    var doubleValue = double.Parse(firstValue);
                    var doubleConditionValue = double.Parse(secondValue);
                    conditionResult = (doubleValue > doubleConditionValue);
                }
                catch (Exception)
                {
                }
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.MoreThanOrEqual)
            {
                try
                {
                    var doubleValue = double.Parse(firstValue);
                    var doubleConditionValue = double.Parse(secondValue);
                    conditionResult = (doubleValue >= doubleConditionValue);
                }
                catch (Exception)
                {
                }
            }
            else if (conditionTypeId == Shared.Struct.ConditionType.In)
            {
                try
                {
                    List<string> splittedSecondValue = secondValue.Split(',').ToList();
                    conditionResult = splittedSecondValue.Contains(firstValue);
                }
                catch (Exception)
                {
                }
            }
            return conditionResult;
        }

        public string GetWorkSheetDataByCellAndColumn(ExcelWorksheet workSheet, int row, int column)
        {
            string result = workSheet.Cells[row, column].Value != null ? workSheet.Cells[row, column].Value.ToString() : "";
            return result;
        }

        public List<string> GetRealTimeID(Guid userId)
        {
            List<string> result = new List<string>();
            var user = _context.User.Where(x => x.Id == userId).FirstOrDefault();
            result = user.UserRealTimes.Select(x => x.SignalRId).ToList();
            return result;
        }
        public List<string> GetAllRelatedRealTimeID(Guid userId, bool includeAllSystemManagers = true)
        {
            List<string> result = new List<string>();
            var user = _context.User.Where(x => x.Id == userId).FirstOrDefault();

            result = user.UserRealTimes.Select(x => x.SignalRId).ToList();

            if (includeAllSystemManagers)
            {

                var managersrealTimeIds = user.UserRealTimes
                    .Where(x => x.User.Roles.Any(
                     y =>
                     y.RoleId == Shared.Struct.Roles.SuperAdmin ||
                     y.RoleId == Shared.Struct.Roles.Admin ||
                     y.RoleId == Shared.Struct.Roles.Supervisor
                     )).Select(x => x.SignalRId).ToList();
                result = result.Concat(managersrealTimeIds).Distinct().ToList();
            }

          
                return result.Distinct().ToList();
            
        }
        public List<string> GetDirectLeaderRealTimeId(Guid userId)
        {
            List<string> result = new List<string>();
            var user = _context.User.Where(x => x.Id == userId).FirstOrDefault();
          
            return result;
        }

        public DateTime? GetDateByHijryInfo(int year, int month, int day)
        {
            DateTime? dateResult = null;
            try
            {
                string dayString = (day < 10) ? "0" + day : day.ToString();
                string monthString = (month < 10) ? "0" + month : month.ToString();

                string dateString = dayString + "/" + monthString + "/" + year;
                CultureInfo arSA = new CultureInfo("ar-SA");
                arSA.DateTimeFormat.Calendar = new HijriCalendar();
                //var latestPaidInstallmentDate = new DateTime(year, month, day, arSA.DateTimeFormat.Calendar);
                dateResult = DateTime.ParseExact(dateString, "dd/MM/yyyy", arSA);

                return dateResult;
            }
            catch (Exception ex)
            {
                var _day = day - 1;
                string dayString = (_day < 10) ? "0" + _day : _day.ToString();
                string monthString = (month < 10) ? "0" + month : month.ToString();

                string dateString = dayString + "/" + monthString + "/" + year;
                CultureInfo arSA = new CultureInfo("ar-SA");
                arSA.DateTimeFormat.Calendar = new HijriCalendar();
                //var latestPaidInstallmentDate = new DateTime(year, month, day, arSA.DateTimeFormat.Calendar);
                dateResult = DateTime.ParseExact(dateString, "dd/MM/yyyy", arSA);

                return dateResult;
            }

        }

        public string GetGoodPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length > 9)
            {
                phoneNumber = phoneNumber.Substring(phoneNumber.Length - 9);
            }
            return phoneNumber;
        }

        public string GetArabicCompletationCode(string codeName)
        {
            if (codeName == "Default_code")
            {
                return "تم الرد";
            }
            else if (codeName == "Answer_Human")
            {
                return "تم الرد";
            }
            else if (codeName == "Call_Answered")
            {
                return "تم الرد";
            }
            else if (codeName == "Answer_Machine")
            {
                return "رد الي ";
            }
            else if (codeName == "Call_Busy")
            {
                return "الخط مشغول";
            }
            else if (codeName == "Desktop_Error")
            {
                return "مشكلة لدى الايجنت";
            }
            else if (codeName == "Disconnected_By_System_NuisanceApp")
            {
                return "تم الاغلاق من النظام بسبب نغمة غير واضحة للنظام";
            }
            else if (codeName == "Disconnected_By_User_CCA")
            {
                return "الخط مغلق";
            }
            else if (codeName == "Disconnected_By_User_NuisanceApp")
            {
                return "بعد فتح الخط تم الاغلاق مباشرة من قبل العميل";
            }
            else if (codeName == "Disconnected_By_User")
            {
                return " تم الاغلاق مباشرة من قبل العميل";
            }
            else if (codeName == "Invalid_Number")
            {
                return "رقم غير صالح";
            }
            else if (codeName == "Network_Refusal")
            {
                return "رفض الشبكة";
            }
            else if (codeName == "No_Answer")
            {
                return "لم يتم الرد";
            }
            else if (codeName == "Ring_No_Answer")
            {
                return "لم يتم الرد";
            }

            else if (codeName == "Attempt_Timeout")
            {
                return "";
            }
            else if (codeName == "Restricted_Other")
            {
                return "";
            }
            else
            {
                return "";
            }

            //            Answer_Human
            //Desktop_Error
            //Invalid_Number
            //Default_code
            //Disconnected_By_User_NuisanceApp
            //Answer_Machine
            //Ring_No_Answer
            //Disconnected_By_System_NuisanceApp
            //Disconnected_By_User_CCA
            //Attempt_Timeout
            //No_Answer
            //Restricted_Other
            //Network_Refusal
            //Call_Busy
            //Call_Answered
        }
        public string GetArabicCompletationCodeByCodeId(int codeId)
        {
           
            if (codeId == 12 || codeId==13)
            {
                return "تم الرد";
            }
            else if (codeId == 55 ||codeId== 45 || codeId == 69 || codeId == 18 || codeId == 9 || codeId == 8 || codeId == 5 || codeId == 15 || codeId == 17 || codeId == 7 || codeId == 54 || codeId == 43 || codeId == 4)
            {
                return "لم يتم الرد";
            }
            else if (codeId == 16)
            {
                return "لم يتم الوصول";
            }
            else if (codeId == 10)
            {
                return "الرقم مشغول ";
            }
            else if (codeId == 11)
            {
                return "رنين و لم يتم الرد";
            }
            else if (codeId == 14)
            {
                return "رد آلي";
            }
          
            else
            {
                return "غير معروف";
            }

          
        }
        public string GetStructuredQuary(
           string quaryFields,
           string quaryTableName,
           string quaryDateCondetion,
           string quaryWhereClose,
           string quaryGroupBy,
           string quaryOrderby)
        {
            string Quary = " select " + quaryFields + " from " + quaryTableName + " " + quaryDateCondetion;
            if (!string.IsNullOrEmpty(quaryWhereClose))
            {
                if (!string.IsNullOrWhiteSpace(quaryDateCondetion))
                {
                    Quary += " and " + quaryWhereClose;
                }
                else
                {
                    Quary += quaryWhereClose;
                }
            }
            if (!string.IsNullOrEmpty(quaryGroupBy))
            {
                Quary += " GROUP BY " + quaryGroupBy;
            }
            if (!string.IsNullOrEmpty(quaryOrderby))
            {
                Quary += " Order by " + quaryOrderby;
            }
            return Quary;
        }
        public List<List<string>> AURAPOMGetQuaryResult(string quary, int fieldCount)
        {
            List<List<string>> result = new List<List<string>>();
            OdbcConnection AURAPOMConn = new OdbcConnection("DSN=" + _AVAYAPOMSettings.POM_ODBCDSN);
            try
            {
                OdbcCommand cmd = new OdbcCommand(quary, AURAPOMConn);
                AURAPOMConn.Open();
                OdbcDataReader OldReader = cmd.ExecuteReader();

                result = new List<List<string>>();
                while (OldReader.Read())
                {
                    List<string> OldResult = new List<string>();
                    for (int i = 0; i < fieldCount; i++)
                    {
                        var temp = OldReader.GetValue(i);
                        if (temp == null)
                            OldResult.Add("");
                        else
                            OldResult.Add(temp.ToString());
                    }
                    result.Add(OldResult);
                }
                OldReader.Close();
                AURAPOMConn.Close();
                return result;
            }
            catch (Exception ex)
            {
                AURAPOMConn.Close();
                throw new Exception(ex.Message + " ---");
            }
        }
        //public Guid GetTypeOfAttachment(string extension)
        //{
        //    string pattern = "^.*(jpg|jpeg|png|gif)$";
        //    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        //    if (regex.IsMatch(extension))
        //    {
        //        return Shared.Struct.AttachmentType.Image;
        //    }
        //    return Shared.Struct.AttachmentType.File;


        //}


    }
}
