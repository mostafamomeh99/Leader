using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialerSystem.Areas.CP.Controllers
{
    [Area("CP")]
    public class HomeController : BaseController
    {

        public HomeController()
        {
        }
        public IActionResult Main(string Urlhash)
        {
            if (!string.IsNullOrEmpty(Urlhash))
            {
                ViewBag.Urlhash = Urlhash.Replace("#!", "");
            }

            return View();
        }
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}
