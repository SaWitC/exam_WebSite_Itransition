using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Components.HTMLHelpers
{
    public static class DataIsNotNull
    {
        public static HtmlString Generate(this IHtmlHelper html, string name, string Values,string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(Values))
            {
                string result = $"<p><b>{name}</b>: {Values}</p>";
                return new HtmlString(result);
            }
            else
            {
                string result = $"<p><b>{name}</b>: {ErrorMessage}</p>";
                return new HtmlString(result);
            }
            
        }
    }
}
