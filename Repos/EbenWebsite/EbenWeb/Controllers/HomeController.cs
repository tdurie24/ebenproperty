﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EbenWeb.Models;

namespace EbenWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult privacy()
        {
            return View();
        }
        public IActionResult pricing()
        {
            return View();
        }

        public IActionResult contact()
        {
            var model = new Contact();
            model.Option = "US";
            model.Service = "SE";
            return View(model);
        }

        [HttpPost]
        public IActionResult contact([FromForm] Contact contact)
        {
            return View();
        }

        [HttpPost]
        public IActionResult contacts()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
