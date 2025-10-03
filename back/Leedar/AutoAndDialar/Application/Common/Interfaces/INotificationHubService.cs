using Shared.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface INotificationHubService
    {
        Task OpenLink(List<string> userRealTimeUserIds, string link);
        Task FireNotification(List<string> userRealTimeUserIds, string message, string title, string type, int durationMilliSeconds);
        Task UpdatingOnCallsNumber(List<string> userRealTimeUserIds, Guid? fromStatusId, Guid? toStatusId, int count);
        Task UpdatingOnCallsNumberToday(List<string> userRealTimeUserIds, string knopName, int count);
        Task UpdatingSystemProgress(List<string> userRealTimeUserIds, Guid SystemProgressId, int value);

    }
}
