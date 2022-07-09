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
    public class AddAddressModel : PageModel
    {
        private AddressService addressService;
        [BindProperty]
        public string Country { get; set; }
        [BindProperty]
        public string PostCode { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string StreetName { get; set; }
        [BindProperty]
        public string StreetNumber { get; set; }
    
        public ActionResult OnPost()
        {
            Address address = new Address();
            address.Country = this.Country;
            address.PostCode = this.PostCode;
            address.City = this.City;
            address.StreetName = this.StreetName;
            address.StreetNumber = this.StreetNumber;
            address.ContactID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
           
            if (addressService == null)
            {
                this.addressService = new AddressService();
            }
            this.addressService.AddOrUpdateAdress(address);
            return RedirectToPage("AllContacts", null, "RedirectTarget");
        }
    }
}
