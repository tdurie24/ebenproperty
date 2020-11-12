using System.Collections.Generic;
using System.Web.Mvc;

namespace Eben.Business.Models
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
       

        public string Service { get; set; }


        //public string ServiceType { get; set; }
        // public string Option { get; set; }

        //public List<SelectListItem> Options { get; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "US", Text = "Would you like to"  },
        //    new SelectListItem { Value = "MX", Text = "consultation (15 mins)" },
        //    new SelectListItem { Value = "CA", Text = "Online consultation R500/hour with our director" },
        //};
    }

}
