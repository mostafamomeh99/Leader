using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall
{
   public class ScheduledCallByCallStatusVM
    {
        public Guid Id { set; get; }
        public int Assigned { get; set; }
        public int QueuedInSystem { get; set; }
        public int ScheduledInSystem { get; set; }
        public int QueuedInDialer { get; set; }
        public int ScheduledInDialer { get; set; }
        public int NotSuccessByDialer { get; set; }
        public int Completed { get; set; }


    }
}
