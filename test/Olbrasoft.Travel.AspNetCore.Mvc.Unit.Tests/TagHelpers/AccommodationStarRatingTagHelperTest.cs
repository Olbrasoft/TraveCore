using Microsoft.AspNetCore.Razor.TagHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Travel.AspNetCore.Mvc.TagHelpers;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Unit.Tests.TagHelpers
{
    [TestFixture]
    internal class AccommodationStarRatingTagHelperTest
    {
        [Test]
        public void Instance_Is_TagHelper()
        {
            //Arrange
            var type = typeof(TagHelper);

            //Act
            var helper = new AccommodationStarRatingTagHelper();

            //Assert
            Assert.IsInstanceOf(type, helper);
        }

        [Test]
        public async Task ProcessAsync_For_Zero_Stars()
        {
            //Arrange
            var helper = new AccommodationStarRatingTagHelper();
            
            var tagHelperContext = TagHelperContext();

            var tagHelperOutput = TagHelperOutput(new decimal(0).ToString());

            //Act
            await helper.ProcessAsync(tagHelperContext, tagHelperOutput);

            //Assert
            Assert.AreEqual(string.Empty, tagHelperOutput.Content.GetContent());

        }


        [Test]
        public async Task ProcessAsync_For_Two_dot_Five_Zero_Stars()
        {
            //Arrange
            var helper = new AccommodationStarRatingTagHelper();

            var ul = new StringBuilder("<ul class=\"list-inline\">");
            ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            ul.AppendLine("<li><i class=\"glyphicon glyphicon-star-empty\"></i></li>");
            ul.AppendLine("</ul>");

            var html = ul.ToString();

            var tagHelperContext = TagHelperContext();

            var tagHelperOutput = TagHelperOutput(new decimal(2.5).ToString());

            //Act
            await helper.ProcessAsync(tagHelperContext, tagHelperOutput);

            //Assert
            Assert.AreEqual(html, tagHelperOutput.Content.GetContent());

        }
        

        [Test]
        public async Task ProcessAsync_For_Three_Stars()
        {
            var helper = new AccommodationStarRatingTagHelper();

            var ul = new StringBuilder("<ul class=\"list-inline\">");
            ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            ul.AppendLine("<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            ul.AppendLine("</ul>");

            var html = ul.ToString();

            var tagHelperContext = TagHelperContext();

            var tagHelperOutput = TagHelperOutput("3");

            //Act
            await helper.ProcessAsync(tagHelperContext, tagHelperOutput);

            //Assert

            Assert.AreEqual(html, tagHelperOutput.Content.GetContent());
        }

        private static TagHelperOutput TagHelperOutput(string content)
        {
            return new TagHelperOutput("AccommodationStarRating",
                new TagHelperAttributeList(),
                (result, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent().SetHtmlContent(content);
                    return Task.FromResult(tagHelperContent);
                });
        }


        private static TagHelperContext TagHelperContext()
        {
            return new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));
        }
    }
}