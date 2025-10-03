using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User
{
    public class UserStatisticsVM
    {
        public Guid Id { set; get; }
        public int RecallHistoricalCall { get; set; }
        public int SuccessHistoricalCall { get; set; }
        public int NotsuccessHistoricalCall { get; set; }
        public int CallBillsCount { get; set; }
        public int PaidBillsCount { get; set; }
        public double CallBillsAmount { get; set; }



    }
}
