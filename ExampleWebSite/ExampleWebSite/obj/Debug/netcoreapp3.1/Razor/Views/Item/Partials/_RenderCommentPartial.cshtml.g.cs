#pragma checksum "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91c8238a28f629a84a939bd2294413a8404f225d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_Partials__RenderCommentPartial), @"mvc.1.0.view", @"/Views/Item/Partials/_RenderCommentPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91c8238a28f629a84a939bd2294413a8404f225d", @"/Views/Item/Partials/_RenderCommentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ac91f125f01ec1be8c8df689801b46ac4bcf2d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_Partials__RenderCommentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CommentModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>");
#nullable restore
#line 7 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
       Write(item.AvtorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h2>");
#nullable restore
#line 8 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
       Write(item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\проекты\ExampleWebSite\ExampleWebSite\Views\Item\Partials\_RenderCommentPartial.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CommentModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
