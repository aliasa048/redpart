#pragma checksum "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34e5ca550e178a2c4f7891d95bfab704e23e0d5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_Index), @"mvc.1.0.view", @"/Views/Basket/Index.cshtml")]
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
#line 1 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project.ViewModels.Page;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\_ViewImports.cshtml"
using Final_Project.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
using Final_Project.ViewModels.Basket;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34e5ca550e178a2c4f7891d95bfab704e23e0d5c", @"/Views/Basket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16864b769c1d1330867e4003ab79b6b2c1854bc0", @"/Views/_ViewImports.cshtml")]
    public class Views_Basket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BasketIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Assets/css/basket/basket.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:170px; height:170px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Assets/js/basket/basket.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
  
    ViewData["Title"] = "Index";

    decimal endTotal = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Css", async() => {
                WriteLiteral(@"
    
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">

    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet"">

    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/11.6.15/sweetalert2.css"" />

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "34e5ca550e178a2c4f7891d95bfab704e23e0d5c6809", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral(@"
<!-- Start Main Area -->
<main>
    
    <section id=""heart-area"">
        <div class=""container"">
            <div class=""row"">
                <h1>Basket products</h1>
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Name</th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Total</th>
                            <th>Settings</th>
                        </tr>
                    </thead>
                    <tbody class=""tb-body"">
");
#nullable restore
#line 49 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                         foreach (var basketProducts in Model.BasketProducts)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"basket-product\"");
            BeginWriteAttribute("id", " id=\"", 1411, "\"", 1434, 1);
#nullable restore
#line 51 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
WriteAttributeValue("", 1416, basketProducts.Id, 1416, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34e5ca550e178a2c4f7891d95bfab704e23e0d5c9499", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1518, "~/assets/img/product/", 1518, 21, true);
#nullable restore
#line 52 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
AddHtmlAttributeValue("", 1539, basketProducts.Image, 1539, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 53 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                               Write(Html.Raw(basketProducts.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 54 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                               Write(basketProducts.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 55 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                               Write(basketProducts.Price.ToString("##.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</td>\r\n                                <td>");
#nullable restore
#line 56 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                               Write(basketProducts.Total.ToString("##.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</td>\r\n                                <td class=\"basket-delete\">\r\n                                    <button data-id=\"");
#nullable restore
#line 58 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                                                Write(basketProducts.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-quantity=\"");
#nullable restore
#line 58 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                                                                                   Write(basketProducts.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" id=\"deleteBtn\" class=\"btn btn-danger\">Delete</button>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 61 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"


                            endTotal = endTotal + basketProducts.Total;


                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
                <div style=""background-color: #4D5357 !important; padding:30px; width:250px !important; height:80px !important;"">
                    <span style=""color:white; margin-top:20px !important"">Total price:</span>

                    <span style=""color:white"">");
#nullable restore
#line 72 "C:\Users\FX516PM\Desktop\final-project\aliasa\RedParts\Final-Project\Views\Basket\Index.cshtml"
                                         Write(endTotal.ToString("##.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</span>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </section>\r\n</main>\r\n<!-- end Main Area -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/11.4.30/sweetalert2.all.min.js""></script>

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.1/jquery.min.js""></script>

    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js""></script>

    <script src=""https://kit.fontawesome.com/0622708fc2.js"" crossorigin=""anonymous""></script>


    <script src=""https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/11.6.15/sweetalert2.min.js""></script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e5ca550e178a2c4f7891d95bfab704e23e0d5c15118", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BasketIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591