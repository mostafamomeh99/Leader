using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.HistoricalCall
{
    public class GeneralStatisticsVM

    {

        public Classification Contact { get; set; }

        public Classification AllCall { get; set; }
        public Classification ContactCount { get; set; }
        public Classification SuccessCall { get; set; }
        public ClassificationString SuccessCallAVG { get; set; }
        public Classification PaymentPromises { get; set; }
        public ClassificationString PaymentPromisesAVG { get; set; }
        public Classification NotSuccessCall { get; set; }
        public ClassificationString NotSuccessCallAVG { get; set; }
        public ClassificationString ReCallAVG { get; set; }
        public Classification Recall { get; set; }

        public ClassificationString SuccessArrireas { get; set; }
        public ClassificationString NotSuccessArrireas { get; set; }
        public ClassificationString RecallArrireas { get; set; }

        public Classification BillCount { get; set; }
        public ClassificationString BillAmount { get; set; }
        public Classification BillPaidCount { get; set; }
        public ClassificationString BillPaidAmount { get; set; }
    }
    public class Classification
    {
        public int RedumpMortgage { get; set; }
        public int Close { get; set; }
        public int NotRegular { get; set; }
        public int Stumbled { get; set; }
        public int Regular { get; set; }
        public int UnDefined { get; set; }
        public int Total { get; set; }


    }
    public class ClassificationString
    {
        public string RedumpMortgage { get; set; }
        public string Close { get; set; }
        public string NotRegular { get; set; }
        public string Stumbled { get; set; }
        public string Regular { get; set; }
        public string UnDefined { get; set; }
        public string Total { get; set; }

    }
}
