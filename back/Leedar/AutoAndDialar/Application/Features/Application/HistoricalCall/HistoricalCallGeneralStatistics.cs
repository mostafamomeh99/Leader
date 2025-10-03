using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall
{
    public class HistoricalCallGeneralStatistics
    {
        public int SuccessCall { get; set; }
        public int SuccessCallNormal { get; set; }
        public int SuccessCallFollowup { get; set; }
        public int SuccessCallInterested { get; set; }
        public int SuccessCallNotInterested { get; set; }
        public int SuccessCallInProgress { get; set; }
        
        public int NotSuccessCall { get; set; }
        public int NotSuccessCallNormal { get; set; }
        public int NotSuccessCallFollowup { get; set; }

        public double CallDurationNumber { get; set; }
        public string CallDuration { get; set; }

        public int ReCall { get; set; }
        public int ReCallNormal { get; set; }
        public int ReCallFollowup { get; set; }

        public int BillCount { get; set; }
        public double BillValue { get; set; }
        public string BillValueString { get; set; }

        public int BillPaidCount { get; set; }
        public double BillPaidValue { get; set; }
        public string BillPaidValueString { get; set; }

        public int PaymentCount { get; set; }
        public double PaymentValue { get; set; }
        public string PaymentValueString { get; set; }
    }
}
