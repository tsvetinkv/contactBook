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
    public class EditAddressModel : PageModel
    {
        private AddressService addressService;
        public EditAddressModel()
        {
            this.addressService = new AddressService();
        }

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

        public void OnGet()
        {
            Address address = new Address();
            var addressID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            address = this.addressService.GetAddress().Where(p => p.ID == addressID).FirstOrDefault();
            this.Country = address.Country;
            this.PostCode = address.PostCode;
            this.City = address.City;
            this.StreetName = address.StreetName;
            this.StreetNumber = address.StreetNumber;

        }
        public ActionResult OnPost()
        {
            var addressID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);

            Address address = new Address();

            address.ID = addressID;
            address.Country = this.Country;
            address.PostCode = this.PostCode;
            address.City = this.City;
            address.StreetName = this.StreetName;
            address.StreetNumber = this.StreetNumber;

            address.ContactID = this.addressService.GetAddress().Where(p => p.ID == addressID).FirstOrDefault().ContactID;

            this.addressService.AddOrUpdateAdress(address);

            var pageToRefirect = String.Format($"/AllAddresess/{address.ContactID}");

            return Redirect(pageToRefirect);



        }



        public ActionResult OnPostCancel()
        {
            var addressID = long.Parse((this.PageContext.HttpContext.Request.Path).ToString().Split("/")[2]);
            var addressContactID = this.addressService.GetAddress().Where(p => p.ID == addressID).FirstOrDefault().ContactID;
            var pageToRedict = String.Format($"/AllAddresess/{addressContactID}");

            return Redirect(pageToRedict);

        }
    }
}
