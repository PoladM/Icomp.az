#pragma checksum "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06e4f67c38dbe3256775146e04ca40f69e5f3ddb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProcessorSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.VideoCardDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.MemoryCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.VCSerieDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.HardDiscCapacityDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.BrandDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.CategoryDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.AppUserDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs.ProductPartsDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06e4f67c38dbe3256775146e04ca40f69e5f3ddb", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed6c226668045b45b02f9c0ef35dde9d93ef766", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
        <li class=""nav-item"" role=""presentation"">
            <button class=""nav-link active"" id=""home-tab"" data-bs-toggle=""tab"" data-bs-target=""#home"" type=""button"" role=""tab"" aria-controls=""home"" aria-selected=""true"">Profil</button>
        </li>
        <li class=""nav-item"" role=""presentation"">
            <button class=""nav-link"" id=""profile-tab"" data-bs-toggle=""tab"" data-bs-target=""#profile"" type=""button"" role=""tab"" aria-controls=""profile"" aria-selected=""false"">Sifarişlər</button>
        </li>
    </ul>

    <!-- Tab panes -->
    <div class=""tab-content"">
        <div class=""tab-pane active"" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
            <div class=""form-row"">
                <h5>Account Details</h5>
                ");
#nullable restore
#line 21 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
           Write(Html.Partial("_ProfileFormPartial",Model.UserUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""tab-pane"" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
            <table class=""rwd-table"">
                <tr>
                    <th>Order</th>
                    <th>Date</th>
                    <th>Status</th>
                    <th>Total</th>
                </tr>
");
#nullable restore
#line 32 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
                 foreach (var item in Model.Orders)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td data-th=\"Movie Title\"> </td>\r\n                        <td data-th=\"Genre\">");
#nullable restore
#line 36 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
                                       Write(item.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td data-th=\"Year\">");
#nullable restore
#line 37 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
                                      Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td data-th=\"Gross\">");
#nullable restore
#line 38 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
                                       Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 40 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Account\Profile.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591