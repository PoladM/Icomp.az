#pragma checksum "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17713f56c091756e60df77d80a0d488ee2191a02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BasketPartial), @"mvc.1.0.view", @"/Views/Shared/_BasketPartial.cshtml")]
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
using IComp.Service.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Service.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\_ViewImports.cshtml"
using IComp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17713f56c091756e60df77d80a0d488ee2191a02", @"/Views/Shared/_BasketPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f0b1916e23bf383ca432bf3823fc5036b2dd16b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__BasketPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommonBasketViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 80%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
  
    var counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""shopping-cart"">

    <div class=""column-labels"">
        <label class=""product-image"">Image</label>
        <label class=""product-details"">Product</label>
        <label class=""product-price"">Price</label>
        <label class=""product-quantity"">Quantity</label>
        <label class=""product-removal"">Remove</label>
        <label class=""product-line-price"">Total</label>
    </div>

");
#nullable restore
#line 16 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
     foreach (var item in Model.BasketItems)
    {
        {
            counter += item.Count;
        }


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"product\">\r\n            <div class=\"product-image-basket\" style=\"width: 10%;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "17713f56c091756e60df77d80a0d488ee2191a027267", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 725, "~/uploads/products/", 725, 19, true);
#nullable restore
#line 24 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
AddHtmlAttributeValue("", 744, item.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image, 744, 78, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"product-details\">\r\n                <div class=\"product-title\">");
#nullable restore
#line 27 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
                                      Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                <p class=""product-description"">
                    The best dog bones of all time. Holy crap. Your dog
                    will be begging for these things! I got curious once and ate one myself. I'm a
                    fan.
                </p>
            </div>
            <div class=""product-price-basket"">");
#nullable restore
#line 34 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
                                          Write((item.Product.DiscountPercent > 0 ?item.Product.SalePrice*(1-item.Product.DiscountPercent/100):item.Product.SalePrice).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"product-quantity\">\r\n                <input type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 1520, "\"", 1539, 1);
#nullable restore
#line 36 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
WriteAttributeValue("", 1528, item.Count, 1528, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" min=""1"">
            </div>
            <div class=""product-removal"">
                <button class=""remove-product"">
                    Remove
                </button>
            </div>
            <div class=""product-line-price"">25.98</div>
        </div>
");
#nullable restore
#line 45 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1844, "\"", 1860, 1);
#nullable restore
#line 47 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_BasketPartial.cshtml"
WriteAttributeValue("", 1852, counter, 1852, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""basket-count"" />


    <div class=""totals"">
        <div class=""totals-item"">
            <label>Subtotal</label>
            <div class=""totals-value"" id=""cart-subtotal"">71.97</div>
        </div>
        <div class=""totals-item"">
            <label>Tax (5%)</label>
            <div class=""totals-value"" id=""cart-tax"">3.60</div>
        </div>
        <div class=""totals-item"">
            <label>Shipping</label>
            <div class=""totals-value"" id=""cart-shipping"">15.00</div>
        </div>
        <div class=""totals-item totals-item-total"">
            <label>Grand Total</label>
            <div class=""totals-value"" id=""cart-total"">90.57</div>
        </div>
    </div>

    <button class=""checkout"">Checkout</button>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommonBasketViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591