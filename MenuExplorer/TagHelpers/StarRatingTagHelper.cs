using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MenuExplorer.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("star-rating")]
    public class StarRatingTagHelper : TagHelper
    {
        public int Value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var stars = "";
            for (int i = 0; i < 5; i++)
            {
                if (i < Value)
                {
                    stars += "<span>&#9733</span>";

                }
                else
                {
                    stars += "<span class=\"empty-star\">&#9733</span>";
                }
            }
            output.Content.SetHtmlContent(stars);
        }
    }
}
