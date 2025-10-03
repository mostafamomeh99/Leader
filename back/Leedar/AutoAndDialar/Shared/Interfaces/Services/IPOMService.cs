using Shared.DTOs.POM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Services
{
    public interface IPOMService
    {
        Task<bool> SaveContactToListAsync(
            Guid callId,Guid campaginId,Guid productId,Guid ContactId,
            string phoneNumber, string listName, int priority = 10, string agentID = "");
        Task<bool> DeleteContactFromListAsync(string contactId, string ListName);
        Task<SaveContactToListPOMResult> GeneralSaveContactToListAsync(SaveContactToListPOMRequest model);
    }
}
