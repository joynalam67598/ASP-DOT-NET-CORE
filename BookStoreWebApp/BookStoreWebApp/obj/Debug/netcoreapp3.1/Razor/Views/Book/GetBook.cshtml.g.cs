#pragma checksum "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d7467788532cbe21f235df225f563bc31f5e0b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_GetBook), @"mvc.1.0.view", @"/Views/Book/GetBook.cshtml")]
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
#line 1 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\_ViewImports.cshtml"
using BookStoreWebApp.model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
using Microsoft.AspNetCore.Razor.Language.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7467788532cbe21f235df225f563bc31f5e0b2", @"/Views/Book/GetBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"580a2176eb7661edb7d929b8aaf9d465b8a79e93", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_GetBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100 h-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark mt-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Book", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetBook", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
  
    ViewData["Title"] = "Book Details - " + Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <h3 class=""display-4"">Book Details</h3>
    <div class=""row"">
        <div class=""col-sm-6"">
            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-bs-ride=""carousel"">
                <div class=""carousel-indicators"">
");
#nullable restore
#line 14 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" data-bs-target=\"#carouselExampleIndicators\" data-bs-slide-to=\"");
#nullable restore
#line 16 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class= \"", 663, "\"", 695, 1);
#nullable restore
#line 16 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
WriteAttributeValue("", 672, i==0 ? "active" : "", 672, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-current=\"true\" aria-label=\"Slide 1\"></button>\r\n");
#nullable restore
#line 17 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <div class=\"carousel-inner\">\r\n                    \r\n");
#nullable restore
#line 22 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 987, "\"", 1032, 2);
            WriteAttributeValue("", 995, "carousel-item", 995, 13, true);
#nullable restore
#line 24 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
WriteAttributeValue(" ", 1008, i==0 ? "active" : "", 1009, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d7467788532cbe21f235df225f563bc31f5e0b27953", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                          WriteLiteral(Model.Gallery[i].Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 25 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 25 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
AddHtmlAttributeValue("", 1156, Model.Gallery[i].Name, 1156, 22, false);

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
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 27 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""visually-hidden"">Previous</span>
                </button>
                <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""visually-hidden"">Next</span>
                </button>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <h1>");
#nullable restore
#line 43 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12 text-primary\">\r\n                    <span class=\"label label-primary\">By: </span>\r\n                    <span class=\"monospaced\">");
#nullable restore
#line 50 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                        Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <p class=\"description\">\r\n                        ");
#nullable restore
#line 57 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-md-4"">
                    <button type=""button"" data-toggle=""modal"" data-target=""#exampleModal"" class=""btn btn-outline-primary"">
                        Read now
                    </button>
                </div>
            </div>
            
            <!-- Modal -->
            <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h5 class=""modal-title"" id=""exampleModalLabel"">");
#nullable restore
#line 75 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                                                      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                        <div class=""modal-body"">
                            <embed");
            BeginWriteAttribute("src", " src=\"", 3696, "\"", 3719, 1);
#nullable restore
#line 81 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
WriteAttributeValue("", 3702, Model.BookPdfUrl, 3702, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""w-100""/>
                        </div>
                        <div class=""modal-footer"">
                            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                            <button type=""button"" class=""btn btn-primary"">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>

            <hr />

            <ul class=""list-group"">
                <li class=""list-group-item""><span class=""font-weight-bold"">Category - </span> ");
#nullable restore
#line 94 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                                                                         Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Total pages - </span> ");
#nullable restore
#line 95 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                                                                            Write(Model.TotalPages);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Language Id - </span> ");
#nullable restore
#line 96 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
                                                                                            Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
            </ul>
        </div>
    </div>

   
    

    <div class=""container px-4 px-lg-5 mt-5"" id=""similarBook"">
        <h1>Similar Books</h1>
        <hr />
        <div class=""row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center"">
");
#nullable restore
#line 108 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"
             for (int i = 0; i < 5; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col mb-5"">
                    <div class=""card h-100"">
                        <!-- Product image-->
                        <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                        <!-- Product details-->
                        <div class=""card-body p-4"">
                            <div class=""text-center"">
                                <!-- Product name-->
                                <h5 class=""fw-bolder"">""Title""</h5>
                                <!-- Product price-->
                                ""Author""
                            </div>
                        </div>
                        <!-- Product actions-->
                        <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                            <div class=""text-center"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d7467788532cbe21f235df225f563bc31f5e0b218299", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 129 "C:\Users\DELL\Desktop\DOT NET\dot net core 04-07-2021\BookStoreWebApp\BookStoreWebApp\Views\Book\GetBook.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
