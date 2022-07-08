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
    public class EditPhoneModel : PageModel
    {
        private PhoneService phoneServices;
        public EditPhoneModel()
        {
            this.phoneServices = new PhoneService();
        }

        [BindProperty]
        public string Number { get; set; }
        public TypePhones TypePhones { get; private set; }
        [BindProperty]
        public TypePhones Type { get; set; }
        public void OnGet()
        {
            Phone phone = new Phone();
            var phoneID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            phone = this.phoneServices.GetPhone().Where(p => p.ID == phoneID).FirstOrDefault();
            this.Number = phone.Number;
            this.TypePhones = phone.Type;
        }
        public ActionResult OnPost()
        {
            var phoneID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);

            Phone phone = new Phone();

            phone.ID = phoneID;
            phone.Number = this.Number;
            phone.Type = this.Type;
            phone.ContactID = this.phoneServices.GetPhone().Where(p => p.ID == phoneID).FirstOrDefault().ContactID;

            this.phoneServices.AddOrUpdatePhone(phone);

            var pageToRefirect = String.Format($"/AllPhones/{phone.ContactID}");

            return Redirect(pageToRefirect);
        }

        public ActionResult OnPostCancel()
        {
            var phoneID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            var phoneContactID = this.phoneServices.GetPhone().Where(p => p.ID == phoneID).FirstOrDefault().ContactID;
            var pageToRedict = String.Format($"/AllPhones/{phoneContactID}");

            return Redirect(pageToRedict);

        }
    }
}
