#pragma checksum "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b6d3e8a3c1cc766008424c0d394cb6ff8cca7c8"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b6d3e8a3c1cc766008424c0d394cb6ff8cca7c8", @"/Views/Collection/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6122fc4dd63fd57d875fd09fc5da9841c6eccd7", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExampleWebSite.ViewModels.Collections.CollectionDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<script src=\"https://cdn.rawgit.com/showdownjs/showdown/1.0.1/dist/showdown.min.js\"></script>\r\n<div class=\"col-md-9\">\r\n    <div>\r\n\r\n");
#nullable restore
#line 7 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
         if (Model.ImageUrl != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 290, "\"", 311, 1);
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
WriteAttributeValue("", 296, Model.ImageUrl, 296, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 10 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 class=\"text-wrap\">");
#nullable restore
#line 11 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                         Write(Model.collection.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <h6>");
#nullable restore
#line 12 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
       Write(Model.collection.Thema);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n        <textarea hidden id=\"markdownText\">");
#nullable restore
#line 14 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                      Write(Model.collection.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n\r\n        <div style=\"overflow:auto;\" class=\"h-auto w-100\" id=\"ShortDesk\">\r\n            <hr class=\"hr_custom\" />\r\n        </div>\r\n\r\n");
#nullable restore
#line 20 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
         if (Model.items != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div id=\"RenderItem\" class=\"row\">\r\n                ");
#nullable restore
#line 23 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
           Write(await Html.PartialAsync("_writeMoreItems.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <button id=\"loadBtn\" class=\"text-center btn bg_Green\" onclick=\"LoadItems()\">");
#nullable restore
#line 25 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
                                                                                   Write(ViewResourcesModel["load_Mode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 26 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<div class=\"col-3\">\r\n");
#nullable restore
#line 30 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
     if (Model.collection.AvtorName == User.Identity.Name || User.IsInRole("admin"))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
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
#line 69 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
             Write(Url.Action("Details","Collection"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            data: { id: ");
#nullable restore
#line 70 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Collection\Details.cshtml"
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
                    $(""#loadBtn"").hide();
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
