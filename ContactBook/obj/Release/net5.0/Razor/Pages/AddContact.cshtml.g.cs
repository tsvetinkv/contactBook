#pragma checksum "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df2610ac965465fbb799b04218d948a23d657545"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContactBook.Pages.Pages_AddContact), @"mvc.1.0.razor-page", @"/Pages/AddContact.cshtml")]
namespace ContactBook.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\_ViewImports.cshtml"
using ContactBook;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
using ContactBook.Models.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df2610ac965465fbb799b04218d948a23d657545", @"/Pages/AddContact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e947b2b37126f8bfbcba286e9fe9f4a549c6a318", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AddContact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
  
    ViewData["Title"] = "AddContact";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
 using (Html.BeginForm("Save", "Contacts"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("Firstname", "First Name"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.TextBoxFor(c => c.FirstName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("Middlename", "Middle Name"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.TextBoxFor(c => c.MiddleName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("Lastname", "Last Name"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.TextBoxFor(c => c.LastName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("Age", "Age"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.TextBoxFor(c => c.Age, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("Email", "Email"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.TextBoxFor(c => c.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.Label("GenderTypes", "Gender Type"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"
Write(Html.DropDownListFor(c => c.Gender, new SelectList(Enum.GetValues(typeof(GenderTypes))), new
    {
    @class = "form-control"
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"Submit\">\r\n");
#nullable restore
#line 30 "C:\Users\PC\source\repos\ContactBook\ContactBook\Pages\AddContact.cshtml"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<contactbook.Pages.AddContactModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<contactbook.Pages.AddContactModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<contactbook.Pages.AddContactModel>)PageContext?.ViewData;
        public contactbook.Pages.AddContactModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
