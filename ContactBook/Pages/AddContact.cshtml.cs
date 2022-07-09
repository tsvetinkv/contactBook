using ContactBook.Models;
using ContactBook.Models.Enums;
using ContactBook.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace contactbook.Pages
{
    public class AddContactModel : PageModel
    {
        private ContactService contactServices;
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

        public ActionResult OnPost()
        {
            Contact contact = new Contact();
            contact.FirstName = this.FirstName;
            contact.MiddleName = this.MiddleName;
            contact.LastName = this.LastName;
            contact.Age = this.Age;
            contact.Email = this.Email;
            contact.Gender = this.Gender;
            if (contactServices == null)
            {
                this.contactServices = new ContactService();
            }
            this.contactServices.AddOrUpdateContact(contact);
            return RedirectToPage("AllContacts", null, "RedirectTarget");
        }
    }
}

