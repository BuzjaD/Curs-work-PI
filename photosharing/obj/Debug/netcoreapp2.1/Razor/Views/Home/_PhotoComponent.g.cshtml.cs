#pragma checksum "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea430b1039fa9a65cfd754ec5d6f7744acfea8f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__PhotoComponent), @"mvc.1.0.view", @"/Views/Home/_PhotoComponent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_PhotoComponent.cshtml", typeof(AspNetCore.Views_Home__PhotoComponent))]
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
#line 1 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\_ViewImports.cshtml"
using photosharing;

#line default
#line hidden
#line 2 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\_ViewImports.cshtml"
using photosharing.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea430b1039fa9a65cfd754ec5d6f7744acfea8f9", @"/Views/Home/_PhotoComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b135bec0f837cc95822492f9854142213ae8fb91", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__PhotoComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<photosharing.ViewModels.PhotoModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("zoom_icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/zoom.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Zoom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
  
    string commentId = "comment" + Model.Photo.id.ToString();

#line default
#line hidden
            BeginContext(112, 25, true);
            WriteLiteral("<div class=\"gallery-item\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 137, "\"", 196, 3);
            WriteAttributeValue("", 145, "background-image:url(", 145, 21, true);
#line 5 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
WriteAttributeValue("", 166, Url.Content(Model.Photo.url), 166, 29, false);

#line default
#line hidden
            WriteAttributeValue("", 195, ")", 195, 1, true);
            EndWriteAttribute();
            BeginContext(197, 189, true);
            WriteLiteral(">\r\n    <div class=\"active_photo_zone\">\r\n        <div class=\"active_user_photo\">\r\n            <div class=\"user_photo_info\">\r\n                <div class=\"user_username\">\r\n                    ");
            EndContext();
            BeginContext(387, 19, false);
#line 10 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
               Write(Model.User.username);

#line default
#line hidden
            EndContext();
            BeginContext(406, 97, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"photo_creation_date\">\r\n                    ");
            EndContext();
            BeginContext(504, 25, false);
#line 13 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
               Write(Model.Photo.creation_date);

#line default
#line hidden
            EndContext();
            BeginContext(529, 60, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 589, "\"", 625, 2);
            WriteAttributeValue("", 596, "/UserPhotos?id=", 596, 15, true);
#line 16 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
WriteAttributeValue("", 611, Model.User.id, 611, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(626, 23, true);
            WriteLiteral(" class=\"user_photo_img\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 649, "\"", 767, 9);
            WriteAttributeValue("", 657, "background:", 657, 11, true);
            WriteAttributeValue(" ", 668, "url(", 669, 5, true);
#line 16 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
WriteAttributeValue("", 673, Url.Content(Model.User.avatar), 673, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 704, ");", 704, 2, true);
            WriteAttributeValue(" ", 706, "background-size:", 707, 17, true);
            WriteAttributeValue(" ", 723, "cover;", 724, 7, true);
            WriteAttributeValue("\r\n", 730, "background-position:", 732, 22, true);
            WriteAttributeValue(" ", 752, "center", 753, 7, true);
            WriteAttributeValue(" ", 759, "center;", 760, 8, true);
            EndWriteAttribute();
            BeginContext(768, 95, true);
            WriteLiteral(">\r\n            </a>\r\n        </div>\r\n        <div class=\"action_group_section\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 863, "\'", 930, 1);
#line 21 "C:\Курсовые\Курсач ПВИ\photosharing2\photosharing\photosharing\Views\Home\_PhotoComponent.cshtml"
WriteAttributeValue("", 870, Url.Action("Details", "Home", new { id =  Model.Photo.id }), 870, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(931, 55, true);
            WriteLiteral(" class=\"photoItem zoom_icon_wrapper\">\r\n                ");
            EndContext();
            BeginContext(986, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a0e5faa6ed7a45e5bd2f9d599ca37f51", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1046, 56, true);
            WriteLiteral("\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(1105, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<photosharing.ViewModels.PhotoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
