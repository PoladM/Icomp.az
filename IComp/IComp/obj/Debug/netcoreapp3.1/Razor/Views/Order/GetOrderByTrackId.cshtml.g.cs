#pragma checksum "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99989fca82af864b4a7df29be64fdf5a6e18e72a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_GetOrderByTrackId), @"mvc.1.0.view", @"/Views/Order/GetOrderByTrackId.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99989fca82af864b4a7df29be64fdf5a6e18e72a", @"/Views/Order/GetOrderByTrackId.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f0b1916e23bf383ca432bf3823fc5036b2dd16b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_GetOrderByTrackId : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "contactus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration:none;color:#fcbe00"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
  
    ViewData["Title"] = "GetOrderByTrackId";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<main>
    <section id=""track-section-1"" style=""background-color:#f2f2f2;height:500px"">
        <div class=""container"">
            <div class=""col-md-12"">
                <div class=""panel panel-default"">
                    <div class=""panel-body"">
                        <table class=""table table-condensed table-striped"" style=""margin-top:100px"">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Name</th>
                                    <th>Order Total Price</th>
                                    <th>Created At</th>
                                    <th>Status</th>
                                </tr>
                            </thead>

                            <tbody>
                                <tr data-toggle=""collapse"" data-target=""#demo1"" class=""accordion-toggle"">
                                    <td><button class=""btn btn-default btn-xs""><span class");
            WriteLiteral("=\"glyphicon glyphicon-eye-open\"></span></button></td>\r\n                                    <td>");
#nullable restore
#line 28 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                   Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>$");
#nullable restore
#line 29 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                    Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                   Write(Model.CreatedAt.ToString("g"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 31 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                   Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                                <tr>
                                    <td colspan=""12"" class=""hiddenRow"">
                                        <div style=""margin-top:20px"" class=""accordian-body collapse"" id=""demo1"">
                                            <p style=""text-align:center"">
                                                Hello <span style=""color:#fcbe00"">");
#nullable restore
#line 37 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                                                             Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span> Your Order Status Is <span style=\"color:#fcbe00\">");
#nullable restore
#line 37 "C:\Users\memme\OneDrive\Masaüstü\Final-Back\IComp\IComp\Views\Order\GetOrderByTrackId.cshtml"
                                                                                                                                                      Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> . If you have any question about your order please ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99989fca82af864b4a7df29be64fdf5a6e18e72a10704", async() => {
                WriteLiteral("contact with us");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" 
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>


    </section>
</main>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
