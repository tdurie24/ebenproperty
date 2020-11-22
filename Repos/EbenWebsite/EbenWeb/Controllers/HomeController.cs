using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EbenWeb.Models;
using Eben.Business.Contracts;
using Eben.Business.Models;
using Eben.Business.Services;
using System.Text;

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
            // model.Option = "US";
            model.Service = "SE";
            return View(model);
        }

        [HttpPost]
        public virtual JsonResult contact(Contact co)
        {
            StringBuilder body = new StringBuilder();
            body.Append("Name: " + co.Name);
            body.Append(Environment.NewLine + "Mobile Number: " + co.Phone);
            body.Append(Environment.NewLine + "Email: " + co.Email);
            body.Append(Environment.NewLine + "Message: " + co.Message);
            //public string Service { get; set; }
            var contact = new ContactModel()
            {
                Name = co.Name,
                Email = co.Email,
                Phone = co.Phone,
                Message = body.ToString()
                };

            switch (co.Service)
            {
                case "IA":
                    contact.Service = "Investment Advice";
                    break;
                case "AX":
                    contact.Service = "Accounting and Tax returns";
                    break;
                case "RM":
                    contact.Service = "Rental management";
                    break;
                case "PM":
                    contact.Service = "Property maintenance";
                    break;
                default:
                    contact.Service = "No particular service";
                    break;
            }
            var emailServ = new EmailService();
            emailServ.SendEmail(contact);
            
            return Json(true);
        }

        [HttpPost]
        public virtual JsonResult subscribe(Contact co)
        {
            var contact = new ContactModel()
            {
                Name = co.Email,
                Email = co.Email,
                Message = "Email for new subscriber: " + co.Email
            };
            var emailServ = new EmailService();
            emailServ.SendEmail(contact);
            return Json(true);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
