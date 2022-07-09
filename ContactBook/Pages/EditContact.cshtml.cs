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
    public class EditContactModel : PageModel
    {
        private ContactService contactService;
        public EditContactModel()
        {
            this.contactService = new ContactService();
        }

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string MiddleName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public GenderTypes Gender { get; set; }

        public void OnGet()
        {
            Contact contact = new Contact();
            var contactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            contact = this.contactService.GetContact().Where(p => p.ID == contactID).FirstOrDefault();
            this.FirstName = contact.FirstName;
            this.MiddleName = contact.MiddleName;
            this.LastName = contact.LastName;
            this.Age = contact.Age;
            this.Email = contact.Email;
            this.Gender = contact.Gender;


        }
        public ActionResult OnPost()
        {
            var contactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);

            Contact contact = new Contact();

            contact.ID = contactID;
            contact.FirstName = this.FirstName;
            contact.MiddleName = this.MiddleName;
            contact.LastName = this.LastName;
            contact.Age = this.Age;
            contact.Email = this.Email;
            contact.Gender = this.Gender;

           
            this.contactService.AddOrUpdateContact(contact);

            return RedirectToPage("AllContacts", null, "RedirectTarget");
        }



        public ActionResult OnPostCancel()
        {
            return RedirectToPage("AllContacts", null, "RedirectTarget");

        }
    }
}
