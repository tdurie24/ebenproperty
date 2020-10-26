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

        public IActionResult propertyinvestments()
        {
            return View();
        }

        public IActionResult rentalmanagement()
        {
            return View();
        }

        public IActionResult propertymaintenance()
        {
            return View();
        }

        public IActionResult architecture()
        {
            return View();
        }
    }
}