

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class StatisticsController : BaseController
    {
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult New()
        {
            return PartialView();
        }
        public IActionResult GeneralStatistics()
        {
            return PartialView();
        }
        public IActionResult HistoricalCallPerSubNot()
        {
            return PartialView();
        }

    }
}
