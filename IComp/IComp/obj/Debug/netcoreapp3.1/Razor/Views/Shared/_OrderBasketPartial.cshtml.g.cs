#pragma checksum "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ba27e7591e519fea13dc8960e899f3e17930d08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__OrderBasketPartial), @"mvc.1.0.view", @"/Views/Shared/_OrderBasketPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba27e7591e519fea13dc8960e899f3e17930d08", @"/Views/Shared/_OrderBasketPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f0b1916e23bf383ca432bf3823fc5036b2dd16b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__OrderBasketPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommonBasketViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 80%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "deletebasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "catalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("remove-product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
  
    var counter = 0;
    decimal productTotalPrice = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"shopping-cart\" style=\"margin-top: 20px;\">\r\n\r\n");
#nullable restore
#line 10 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
             foreach (var item in Model.BasketItems)
            {
                {
                    counter += item.Count;
                    productTotalPrice = item.Count * (item.Product.DiscountPercent > 0 ? item.Product.SalePrice * (1 - item.Product.DiscountPercent / 100) : item.Product.SalePrice);
                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"product\">\r\n                    <div class=\"product-image-basket\" style=\"width: 10%;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8ba27e7591e519fea13dc8960e899f3e17930d088363", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 661, "~/uploads/products/", 661, 19, true);
#nullable restore
#line 19 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
AddHtmlAttributeValue("", 680, item.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image, 680, 78, false);

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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"product-details\">\r\n                        <div class=\"product-title\">");
#nullable restore
#line 22 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
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
                    <div class=""product-price-basket"">price:  $");
#nullable restore
#line 29 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
                                                           Write((item.Product.DiscountPercent > 0 ?item.Product.SalePrice*(1-item.Product.DiscountPercent/100):item.Product.SalePrice).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"product-quantity\">\r\n                        <input type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 1561, "\"", 1580, 1);
#nullable restore
#line 31 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
WriteAttributeValue("", 1569, item.Count, 1569, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" min=\"1\" class=\"change-val-order\">\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1661, "\"", 1680, 1);
#nullable restore
#line 32 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
WriteAttributeValue("", 1669, item.Count, 1669, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"current-val\">\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1748, "\"", 1772, 1);
#nullable restore
#line 33 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
WriteAttributeValue("", 1756, item.Product.Id, 1756, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-Id\">\r\n\r\n                    </div>\r\n                    <div class=\"product-removal\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ba27e7591e519fea13dc8960e899f3e17930d0812818", async() => {
                WriteLiteral("\r\n                            Remove\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
                                                                                WriteLiteral(item.Product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"product-line-price\">");
#nullable restore
#line 41 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
                                               Write(productTotalPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n");
#nullable restore
#line 43 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2273, "\"", 2289, 1);
#nullable restore
#line 45 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
WriteAttributeValue("", 2281, counter, 2281, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"basket-count\" />\r\n\r\n\r\n            <div class=\"totals\">\r\n                <div class=\"totals-item totals-item-total\">\r\n                    <label>Total</label>\r\n                    <div class=\"totals-value\" id=\"cart-total\">");
#nullable restore
#line 51 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Shared\_OrderBasketPartial.cshtml"
                                                          Write(Model.TotalPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>");
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