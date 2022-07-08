using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactBook.Pages
{
    public class AllPhonesModel : PageModel
    {
        private PhoneService phoneSercices;
        public IList<Phone> Phones { get; set; }

        public AllPhonesModel()
        {
            this.phoneSercices = new PhoneService();
        }
        public void OnGet()
        {
            var contactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            Phones = (this.phoneSercices.GetPhone()).Where(a => a.ContactID == contactID).ToList();
        }

        public ActionResult OnGetDelete(int id, int contactID)
        {
            this.phoneSercices.DeletePhone(id);
            var pageToRedirect = String.Format($"/AllPhones/{contactID}");
            return Redirect(pageToRedirect);
        }
    }
}
