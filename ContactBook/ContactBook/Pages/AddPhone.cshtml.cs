using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Models.Enums;
using ContactBook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactBook.Pages
{
    public class AddPhoneModel : PageModel
    {
        private PhoneService phoneServices;
        [BindProperty]
        
        public string Number { get; set; }
        [BindProperty]
        public TypePhones Type { get; set; }
      
        public ActionResult OnPost()
        {
            Phone phone = new Phone();
            phone.Number = this.Number;
            phone.Type = this.Type;
            phone.ContactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            if (phoneServices == null)
            {
                this.phoneServices = new PhoneService();
            }
            this.phoneServices.AddOrUpdatePhone(phone);
            return RedirectToPage("AllContacts", null, "RedirectTarget");
        }
    
    }
}
