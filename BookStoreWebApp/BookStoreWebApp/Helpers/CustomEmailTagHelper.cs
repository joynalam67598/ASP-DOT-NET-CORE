using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStoreWebApp.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string Email { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:joynalam67598@gmail.com");
            output.Attributes.Add("id","my-email-id");
            output.Content.SetContent("my-email");
        }
    }
}
