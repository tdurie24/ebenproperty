using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EbenWeb.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PropertyInvestments()
        {
            return View();
        }

        public IActionResult RentalManagement()
        {
            return View();
        }

        public IActionResult PropertyMaintenance()
        {
            return View();
        }

        public IActionResult Architecture()
        {
            return View();
        }
    }
}