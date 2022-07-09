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
    public class AllAddresessModel : PageModel
    {
        private AddressService addressSercices;
        public IList<Address> Address { get; set; }

        public AllAddresessModel()
        {
            this.addressSercices = new AddressService();
        }
        public void OnGet()
        {
            Address = this.addressSercices.GetAddress();
            var contactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            Address = (this.addressSercices.GetAddress()).Where(a => a.ContactID == contactID).ToList();
        }

        public ActionResult OnGetDelete(int id, int contactID)
        {
            this.addressSercices.DeleteAddress(id);
            var pageToRedirect = String.Format($"/AllAddresess/{contactID}");
            return Redirect(pageToRedirect);
        }

    }
}
