#pragma checksum "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2534b23ab36325f0c689174d87c2d0350e7486b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__IndividualProductCard), @"mvc.1.0.view", @"/Views/Shared/_IndividualProductCard.cshtml")]
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
#line 1 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\_ViewImports.cshtml"
using MachineApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\_ViewImports.cshtml"
using MachineApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2534b23ab36325f0c689174d87c2d0350e7486b", @"/Views/Shared/_IndividualProductCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d5c8e495f0b002a56a3c3435bd60b662610189", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IndividualProductCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark form-control  p-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<div");
            BeginWriteAttribute("class", " class=\"", 8, "\"", 84, 6);
            WriteAttributeValue("", 16, "col-lg-4", 16, 8, true);
            WriteAttributeValue(" ", 24, "col-md-6", 25, 9, true);
            WriteAttributeValue(" ", 33, "pb-4", 34, 5, true);
            WriteAttributeValue(" ", 38, "filter", 39, 7, true);
#nullable restore
#line 3 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
WriteAttributeValue(" ", 45, Model.Category.Name.Replace(' ','_'), 46, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 83, "", 84, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
    <!-- Card-->
    <div class=""card bg-white rounded shadow-sm h-100"" style=""border:1px solid #222"">

        <div class=""col-12  "" data-toggle=""tooltip"" title=""Kategorinamn"" style=""cursor:help; "">
            
            <span class=""badge p-3  w-100 text-dark h1 fw-bold fs-3 "">");
#nullable restore
#line 9 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
                                                                 Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <img class=\"card-img-top img-fluid d-block mx-auto mb-3 border h-100 \"");
            BeginWriteAttribute("src", " src=\"", 499, "\"", 520, 1);
#nullable restore
#line 11 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
WriteAttributeValue("", 505, Model.ImageUrl, 505, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""Card image cap"" style=""width: 100%; height: 100%; "">


        <div class=""card-body p-1 px-3 row"">

            <div class=""card-body px-3 pt-3 pb-1 row"">
                <div class=""col-6""><label class=""float-left w-100 text-nowrap"" data-toggle=""tooltip"" title=""Produktnamn"" style=""cursor:help"">");
#nullable restore
#line 17 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
                                                                                                                                        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n                <div class=\"col-6 \"><label class=\"float-right h4 text-info w-100 text-nowrap\" data-toggle=\"tooltip\" title=\"Produktpris\" style=\"cursor:help\"><span class=\"text-info   \">");
#nullable restore
#line 18 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
                                                                                                                                                                                  Write(Model.Price.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("sv-SE")));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></label> </div>
            </div>
            <div class=""col-12 pt-2 h-auto"" style=""font-size:20px; text-align:justify;  width: 100%;  cursor:help "" data-toggle=""tooltip"" title=""Kort beskrivning om produkt"">
                <p class=""card-text mx-auto""> ");
#nullable restore
#line 21 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
                                         Write(Model.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"card-footer col-12 pt-2 mt-2 bg-dark\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2534b23ab36325f0c689174d87c2d0350e7486b8111", async() => {
                WriteLiteral("Mer Information");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\ramis\Desktop\LastProjectmvc\MachineApp\MachineApp\Views\Shared\_IndividualProductCard.cshtml"
                                          WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        $(function () {\r\n            $(\'[data-toggle=\"tooltip\"]\').tooltip()\r\n        })\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
