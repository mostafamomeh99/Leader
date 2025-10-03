using Application.Common.Models;
using Application.Features.Identity.User;
using Application.Features.Identity.User.Queries;
using Domain.Entities.Application;
//using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IGeneralOperation
    {
        Task<CurrantUserViewModel> GetCurrentUser();
         bool CompareTwoString(string oldstr, string newstr);
        Task<PagedResponse<SelectListItem>> GetEntityValueAsSelectedLsitItem(Guid entityTypeId, byte? stateCode, Guid? ProjectId = null, Guid? TicketTypeId = null);
        string GetWorkSheetDataByCellAndColumn(ExcelWorksheet workSheet, int row, int column);
        Task<string> GetStringValueForGuidOption(Guid FeildId, string Value);
        bool CalculateCondition(string firstValue, string secondValue, Guid conditionTypeId);
        List<string> GetRealTimeID(Guid userId);
        List<string> GetAllRelatedRealTimeID(Guid userId, bool includeAllSystemManagers = true);
        List<string> GetDirectLeaderRealTimeId(Guid userId);
        DateTime? GetDateByHijryInfo(int year, int month, int day);
        string GetGoodPhoneNumber(string phoneNumber);
        string GetArabicCompletationCodeByCodeId(int codeId);
        string GetArabicCompletationCode(string codeName); 
        string GetStructuredQuary(
          string quaryFields,
          string quaryTableName,
          string quaryDateCondetion,
          string quaryWhereClose,
          string quaryGroupBy,
          string quaryOrderby);
        List<List<string>> AURAPOMGetQuaryResult(string quary, int fieldCount);
        // Guid GetTypeOfAttachment(string extension);

    }
}

