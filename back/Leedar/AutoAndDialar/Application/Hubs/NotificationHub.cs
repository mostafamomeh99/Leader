using Application.Common.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hubs
{
    public class NotificationHub : Hub, INotificationHubService
    {
        protected IHubContext<NotificationHub> _hubContext;
        private readonly IApplicationDbContext _context;
        public NotificationHub(IApplicationDbContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task SendMessage(string user, string message)
        {
            await this._hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task OpenLink(List<string> userRealTimeUserIds, string link)
        {
            if (this._hubContext.Clients == null)
            {
                return;
            }
            foreach (var userRealTimeUserId in userRealTimeUserIds)
            {
                await this._hubContext.Clients.Client(userRealTimeUserId).SendAsync("OpenLink", link);
            }
        }
        public async Task FireNotification(List<string> userRealTimeUserIds, string message, string title, string type, int durationMilliSeconds)
        {
            if (this._hubContext.Clients == null)
            {
                return;
            }
            foreach (var userRealTimeUserId in userRealTimeUserIds)
            {
                await this._hubContext.Clients.Client(userRealTimeUserId).SendAsync("FireNotification", message, title, type, durationMilliSeconds);
            }
        }
        public async Task UpdatingOnCallsNumber(List<string> userRealTimeUserIds, Guid? fromStatusId, Guid? toStatusId, int count)
        {
            if (this._hubContext.Clients == null)
            {
                return;
            }
            if (userRealTimeUserIds.Any())
            {
                foreach (var userRealTimeUserId in userRealTimeUserIds)
                {
                    await this._hubContext.Clients.Client(userRealTimeUserId).SendAsync("UpdatingOnCallsNumber", fromStatusId, toStatusId, count);
                }
            }
            else
            {
                await this._hubContext.Clients.All.SendAsync("UpdatingOnCallsNumber", fromStatusId, toStatusId, count);
            }

        }
        public async Task UpdatingOnCallsNumberToday(List<string> userRealTimeUserIds, string knopName, int count)
        {
            if (this._hubContext.Clients == null)
            {
                return;
            }
            if (userRealTimeUserIds.Any())
            {
                foreach (var userRealTimeUserId in userRealTimeUserIds)
                {
                    await this._hubContext.Clients.Client(userRealTimeUserId).SendAsync("UpdatingOnCallsNumberToday", knopName, count);
                }
            }
            else
            {
                await this._hubContext.Clients.All.SendAsync("UpdatingOnCallsNumberToday", knopName, count);
            }
        }
        public async Task UpdatingSystemProgress(List<string> userRealTimeUserIds, Guid SystemProgressId, int value)
        {
            if (this._hubContext.Clients == null)
            {
                return;
            }
            if (userRealTimeUserIds.Any())
            {
                foreach (var userRealTimeUserId in userRealTimeUserIds)
                {
                    await this._hubContext.Clients.Client(userRealTimeUserId).SendAsync("UpdatingSystemProgress", SystemProgressId, value);
                }
            }
            else
            {
                await this._hubContext.Clients.All.SendAsync("UpdatingSystemProgress", SystemProgressId, value);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            var userrealTime = _context.UserRealTime.Where(x => x.SignalRId == Context.ConnectionId).FirstOrDefault();
            if (userrealTime != null)
            {
                _context.UserRealTime.Remove(userrealTime);
                await _context.SaveChangesAsync(default);
            }

            await base.OnDisconnectedAsync(exception);
        }
        //public override Task OnDisconnectedAsync(bool stopCalled)
        //{
        //    return base.OnDisconnected(stopCalled);
        //}

        //public override  Task OnReconnectedAsync()
        //{
        //    return null;
        //}
        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
    }
}
