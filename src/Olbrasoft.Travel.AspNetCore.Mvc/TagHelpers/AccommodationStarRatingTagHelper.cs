using Microsoft.AspNetCore.Razor.TagHelpers;
using Olbrasoft.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.TagHelpers
{
    public class AccommodationStarRatingTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            var starRating = decimal.Parse(content.GetContent());
            
            output.TagName = string.Empty;

            if (starRating == 0)
            {
                output.Content.SetHtmlContent(string.Empty);
                return;
            }

            var ul = new StringBuilder("<ul class=\"list-inline\">");
            
            for (var i = 0; i < (int)starRating; i++)
            {
                ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            }

            if (!starRating.IsInteger()) ul.AppendLine("<li><i class=\"glyphicon glyphicon-star-empty\"></i></li>");

            ul.AppendLine("</ul>");

            output.Content.SetHtmlContent(ul.ToString());
        }
    }
}