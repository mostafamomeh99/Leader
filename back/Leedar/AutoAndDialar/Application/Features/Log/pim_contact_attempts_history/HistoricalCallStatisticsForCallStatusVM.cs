using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Log.pim_contact_attempts_history
{
    public class HistoricalCallStatisticsForCallStatusVM
    {
        public List<string> Label { get; set; }
        public List<int> SuccessCall { get; set; }
        public List<int> NotSuccessCall { get; set; }
        public List<int> Recall { get; set; }
        public List<int> BillCount { set; get; }
        public List<double> BillAmount { set; get; }
    }
}
