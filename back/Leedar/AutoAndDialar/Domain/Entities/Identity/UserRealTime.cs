using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class UserRealTime : AuditableEntityNoID
    {
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public string? SignalRId { get; set; }
    }
}
