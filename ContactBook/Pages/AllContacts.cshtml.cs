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
    public class AllContactsModel : PageModel
    {
        private ContactService contactSercices;
        public IList<Contact> Contacts { get; set; }

        public AllContactsModel()
        {
            this.contactSercices = new ContactService();
        }
        public void OnGet()
        {
            Contacts = this.contactSercices.GetContact();
        }

        public ActionResult OnGetDelete(int id)
        {
            this.contactSercices.DeleteContact(id);
            return RedirectToPage("AllContacts", null, "RedirectTarget");
        }
    }
}
