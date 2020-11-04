using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EbenWeb.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ServiceType { get; set; }

        public string Service { get; set; }

        public List<SelectListItem> Services { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "SE", Text = "What services do you require"  },
            new SelectListItem { Value = "AX", Text = "Accounting and Tax returns" },
            new SelectListItem { Value = "RM", Text = "Rental management" },
             new SelectListItem { Value = "PM", Text = "Property maintenance" },
        };

        public string Option { get; set; }

        public List<SelectListItem> Options { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "US", Text = "Would you like to"  },
            new SelectListItem { Value = "MX", Text = "consultation (15 mins)" },
            new SelectListItem { Value = "CA", Text = "Online consultation R500/hour with our director" },  
        };
    }
}
