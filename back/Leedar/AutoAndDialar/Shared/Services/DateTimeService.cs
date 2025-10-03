using Shared.Interfaces.Services;
using System;

namespace Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
        public DateTime Now => DateTime.Now;
        
    }
}
