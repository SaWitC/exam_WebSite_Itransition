<<<<<<< HEAD
#pragma checksum "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fa362887c88a6e99c0d559e53ad3d7efe35a422"
=======
#pragma checksum "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1036b026eed3db5debcc4c413084a607f31bd56d"
>>>>>>> parent of 636540e (added tagCloud,updated interface; sql requests; fixed bugs)
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_Details), @"mvc.1.0.view", @"/Views/Collection/Details.cshtml")]
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
#line 1 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ResourcesModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ViewModels.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ViewModels.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ViewModels.Comments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa362887c88a6e99c0d559e53ad3d7efe35a422", @"/Views/Collection/Details.cshtml")]
=======
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1036b026eed3db5debcc4c413084a607f31bd56d", @"/Views/Collection/Details.cshtml")]
>>>>>>> parent of 636540e (added tagCloud,updated interface; sql requests; fixed bugs)
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6122fc4dd63fd57d875fd09fc5da9841c6eccd7", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExampleWebSite.ViewModels.Collections.CollectionDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ml-auto mr-auto btn bg_Green"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Collection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<script src=\"https://cdn.rawgit.com/showdownjs/showdown/1.0.1/dist/showdown.min.js\"></script>\r\n<div>\r\n    <div class=\"w-100\">\r\n");
#nullable restore
#line 6 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
         if (Model.collection.AvtorName == User.Identity.Name || User.IsInRole("admin"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1036b026eed3db5debcc4c413084a607f31bd56d6766", async() => {
                WriteLiteral("create Item");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-collectionid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                                          WriteLiteral(Model.collection.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["collectionid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-collectionid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["collectionid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1036b026eed3db5debcc4c413084a607f31bd56d9332", async() => {
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                                                                           Write(ViewResourcesModel["Edit"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-collectionid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                                              WriteLiteral(Model.collection.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["collectionid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-collectionid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["collectionid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1036b026eed3db5debcc4c413084a607f31bd56d12184", async() => {
#nullable restore
#line 10 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                                                                   Write(ViewResourcesModel["Delete"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 10 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                                      WriteLiteral(Model.collection.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n");
#nullable restore
#line 14 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
     if (Model.ImageUrl != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 904, "\"", 925, 1);
#nullable restore
#line 16 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
WriteAttributeValue("", 910, Model.ImageUrl, 910, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 17 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 18 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
   Write(Model.collection.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h6>");
#nullable restore
#line 19 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
   Write(Model.collection.Thema);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n    <textarea hidden id=\"markdownText\">");
#nullable restore
#line 21 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                  Write(Model.collection.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n    <div id=\"ShortDesk\">\r\n\r\n    <hr class=\"hr_custom\" />\r\n\r\n    </div>\r\n");
#nullable restore
#line 27 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
     if (Model.items != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"RenderItem\" class=\"row\">\r\n            ");
#nullable restore
#line 30 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
       Write(await Html.PartialAsync("_writeMoreItems.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <button class=\"text-center btn bg_Green\" onclick=\"LoadItems()\">load Mode</button>\r\n");
#nullable restore
<<<<<<< HEAD
#line 32 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
   Write(await Html.PartialAsync("Partials/_controlSidebar.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr class=\"hr_custom\"/>\r\n        <h4 class=\" text-center\">");
#nullable restore
#line 34 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                            Write(ViewResourcesModel["filtration"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 35 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
   Write(await Html.PartialAsync("Partials/_FiltrationPartial.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                      

    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
   Write(await Html.PartialAsync("../Shared/Partials/_SidebarPartial.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                             
=======
#line 33 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
>>>>>>> parent of 636540e (added tagCloud,updated interface; sql requests; fixed bugs)
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>



<script type=""text/javascript"">
    $(document).ready(() => {
        var text = $(""#markdownText"").val();
        target = document.getElementById('ShortDesk'),
            converter = new showdown.Converter(),
            html = converter.makeHtml(text);
        target.innerHTML = html;
    })
</script>


<script>
//load more item
$('div#loading').hide();
var page = 0;
var _inCallback = false;
    function LoadItems() {
    if (page > -1 && !_inCallback) {
        _inCallback = true;
        page++;
        $('div#loading').show();
        console.log(page);
        $.ajax({
            type: 'GET',
            url: """);
#nullable restore
<<<<<<< HEAD
#line 69 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
=======
#line 62 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
>>>>>>> parent of 636540e (added tagCloud,updated interface; sql requests; fixed bugs)
             Write(Url.Action("Details","Collection"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            data: { id: ");
#nullable restore
<<<<<<< HEAD
#line 70 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
=======
#line 63 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
>>>>>>> parent of 636540e (added tagCloud,updated interface; sql requests; fixed bugs)
                   Write(Model.collection.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",p:page },
            success: function (data, textstatus) {
                if (data != '') {
                    $(""#RenderItem"").append(data);
                }
                else {
                    page = -1;
                }
                _inCallback = false;
                $(""div#loading"").hide();
            }
        });
    }
}
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<ViewResourcesModel> ViewResourcesModel { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExampleWebSite.ViewModels.Collections.CollectionDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
