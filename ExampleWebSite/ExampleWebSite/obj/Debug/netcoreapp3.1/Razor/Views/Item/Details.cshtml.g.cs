#pragma checksum "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "925b0d0723fa862c639c4cb3b9e0a5adb868f0ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_Details), @"mvc.1.0.view", @"/Views/Item/Details.cshtml")]
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
#line 5 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using ExampleWebSite.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"925b0d0723fa862c639c4cb3b9e0a5adb868f0ed", @"/Views/Item/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ac91f125f01ec1be8c8df689801b46ac4bcf2d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ItemDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
Write(Model.Item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n");
#nullable restore
#line 6 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
 if (Model.Properties != null) {
    foreach (var item in Model.Properties)
    {
        if (item.Type == "number"|| item.Type == "date")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p><b>");
#nullable restore
#line 11 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                 Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> ");
#nullable restore
#line 11 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                 Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 12 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
        }
        if(item.Type == "bool")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><b>");
#nullable restore
#line 15 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
             Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n");
#nullable restore
#line 16 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
            if (item.Value == "on")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<input type=\"checkbox\" checked disabled />");
#nullable restore
#line 17 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                                       }
            else {

#line default
#line hidden
#nullable disable
            WriteLiteral("<input type=\"checkbox\" disabled />");
#nullable restore
#line 18 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                                    }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr size=\"3\" class=\"hr_custom\"/>\r\n");
#nullable restore
#line 21 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 25 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
 if (User.Identity.IsAuthenticated)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
Write(await Html.PartialAsync("Partials/_WriteCommentPartial.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                                                    ;
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>you are is not autentiacted</h3>\r\n");
#nullable restore
#line 32 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"renderScope\">\r\n    ");
#nullable restore
#line 34 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
Write(await Html.PartialAsync("_WriteMoreComments.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<button onclick=""LoadComments()"">load Mode</button>

<script>
    var page = 0;
    var _inCallback = false;
    window.addEventListener('scroll', function () {
      
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;
            $('div#loading').show();
            console.log(page);
            $.ajax({
                type: 'GET',
                url: """);
#nullable restore
#line 51 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                 Write(Url.Action("Details","Item"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                data: { id: ");
#nullable restore
#line 52 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                       Write(Model.Item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", p: page },
                success: function (data, textstatus) {
                    if (data != '') {
                        $(""#renderScope"").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $(""div#loading"").hide();
                }
            });
        }
    });

    var page = 0;
    var _inCallback = false;
    function LoadComments() {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;
            $('div#loading').show();
            console.log(page);
            $.ajax({
                type: 'GET',
                url: """);
#nullable restore
#line 77 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                 Write(Url.Action("Details","Item"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                data: { id: ");
#nullable restore
#line 78 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                       Write(Model.Item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",p:page },
                success: function (data, textstatus) {
                    if (data != '') {
                        $(""#renderScope"").append(data);
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

</script>

<script>
   function SentComment() {
        $.ajax({
            type: ""POST"",
            url: """);
#nullable restore
#line 99 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
             Write(Url.Action("CreateComent", "Comment"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            data: { message: $(\"#message\").val(), itemId:");
#nullable restore
#line 100 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                                    Write(Model.Item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" },
            dataType: ""text"",
            success: function () {
                location.reload();
            },
            error: function () {
                 alert(""error"");
                // document.getElementById(""status_w"").innerHTML = ""error"";
            }
        })
    }
</script>

<div>
    <input id=""id""");
            BeginWriteAttribute("value", " value=\"", 3138, "\"", 3160, 1);
#nullable restore
#line 114 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
WriteAttributeValue("", 3146, Model.Item.Id, 3146, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <textarea type=\"text\" id=\"message\" maxlength=\"500\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 3220, "\"", 3276, 1);
#nullable restore
#line 115 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
WriteAttributeValue("", 3234, ViewResourcesModel["MaxCommentLenght500"], 3234, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></textarea>\r\n    <button onclick=\"SentComment()\" class=\"btn\">");
#nullable restore
#line 116 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Details.cshtml"
                                           Write(ViewResourcesModel["Enter"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ItemDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
