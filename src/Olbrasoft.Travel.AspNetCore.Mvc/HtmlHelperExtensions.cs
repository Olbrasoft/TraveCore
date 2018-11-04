using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attribute = Olbrasoft.Travel.Data.Transfer.Object.Attribute;

namespace Olbrasoft.Travel.AspNetCore.Mvc
{
    public static class HtmlHelperExtensions
    {
        internal class AttributeClass
        {
            public int AttributeId { get; set; }
            public string ClassName { get; set; }
        }

        private static IDictionary<int, string> BuildAttributesToClasses()
        {
            return new[]
            {
                new AttributeClass
                {
                    AttributeId = 2,
                    ClassName = "fas fa-glass-martini"
                },

                new AttributeClass
                {
                    AttributeId = 5,
                    ClassName = "fas fa-dumbbell"
                },

                new AttributeClass
                {
                    AttributeId = 6,
                    ClassName = "fas fa-car"
                },
                new AttributeClass
                {
                    AttributeId = 7,
                    ClassName = "fas fa-swimming-pool"
                },

                new AttributeClass
                {
                    AttributeId = 8,
                    ClassName = "fas fa-utensils"
                },

                new AttributeClass
                {
                    AttributeId = 10,
                    ClassName = "fas fa-swimmer"
                },

                new AttributeClass
                {
                    AttributeId = 11,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 13,
                    ClassName = "fas fa-cut"
                },

                new AttributeClass
                {
                    AttributeId = 16,
                    ClassName = "fas fa-gift"
                },

                new AttributeClass
                {
                    AttributeId = 18,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 19,
                    ClassName = "fas fa-calculator"
                },

                new AttributeClass
                {
                    AttributeId = 20,
                    ClassName = "fas fa-warehouse"
                },

                new AttributeClass
                {
                    AttributeId = 22,
                    ClassName = "fas fa-car"
                },

                new AttributeClass
                {
                    AttributeId = 26,
                    ClassName = "fab fa-accessible-icon"
                },

                new AttributeClass
                {
                    AttributeId = 27,
                    ClassName = "fas fa-newspaper"
                },

                new AttributeClass
                {
                    AttributeId = 29,
                    ClassName = "fas fa-wine-glass-alt"
                },

                new AttributeClass
                {
                    AttributeId = 30,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 33,
                    ClassName = "fas fa-phone"
                },

                new AttributeClass
                {
                    AttributeId = 34,
                    ClassName = "fas fa-phone-volume"
                },

              new AttributeClass
                {
                    AttributeId = 38,
                    ClassName = "fas fa-cut"
                },

                new AttributeClass
                {
                    AttributeId = 43,
                    ClassName = "fab fa-cc-amex"
                },

                new AttributeClass
                {
                    AttributeId = 45,
                    ClassName = "fab fa-cc-diners-club"
                },

                new AttributeClass
                {
                    AttributeId = 46,
                    ClassName = "fab fa-cc-discover"
                },
                new AttributeClass
                {
                    AttributeId = 47,
                    ClassName = "fab fa-cc-jcb"
                },
                new AttributeClass
                {
                    AttributeId = 48,
                    ClassName = "fab fa-cc-mastercard"
                },
                new AttributeClass
                {
                    AttributeId = 49,
                    ClassName = "fab fa-cc-visa"
                },

                new AttributeClass
                {
                    AttributeId = 57,
                    ClassName = "fas fa-coffee"
                },
                new AttributeClass
                {
                    AttributeId = 61,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 63,
                    ClassName = "fas fas fa-hot-tub"
                },

                new AttributeClass
                {
                    AttributeId = 67,
                    ClassName = "fas fa-book"
                },

                new AttributeClass
                {
                    AttributeId = 70,
                    ClassName = "fas fa-glass-martini-alt"
                },

                new AttributeClass
                {
                    AttributeId = 72,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 73,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 76,
                    ClassName = "fas fa-swimming-pool"
                },

                new AttributeClass
                {
                    AttributeId = 77,
                    ClassName = "fas fa-clock"
                },

                new AttributeClass
                {
                    AttributeId = 79,
                    ClassName = "fas fa-spa"
                },

                new AttributeClass
                {
                    AttributeId = 80,
                    ClassName = "fas fa-hourglass-start"
                },

                new AttributeClass
                {
                    AttributeId = 81,
                    ClassName = "fas fa-user-clock"
                },

                new AttributeClass
                {
                    AttributeId = 86,
                    ClassName = "far fa-newspaper"
                },

                new AttributeClass
                {
                    AttributeId = 88,
                    ClassName = "fas fa-people-carry"
                },

                new AttributeClass
                {
                    AttributeId = 94,
                    ClassName = "fas fa-language"
                },

                new AttributeClass
                {
                    AttributeId = 97,
                    ClassName = "fas fa-newspaper"
                },

                new AttributeClass
                {
                    AttributeId = 98,
                    ClassName = "fas fa-dumbbell"
                },

                new AttributeClass
                {
                    AttributeId = 100,
                    ClassName = "fas fa-paw"
                },
                new AttributeClass
                {
                    AttributeId = 108,
                    ClassName = "fas fa-clock"
                },

                new AttributeClass
                {
                    AttributeId = 110,
                    ClassName = "fas fa-chart-line"
                },

                new AttributeClass
                {
                    AttributeId = 112,
                    ClassName = "fas fa-stopwatch"
                },

                new AttributeClass
                {
                    AttributeId = 116,
                    ClassName = "fas fa-tv"
                },
                new AttributeClass
                {
                    AttributeId = 120,
                    ClassName = "fas fa-spa"
                },

                new AttributeClass
                {
                    AttributeId = 128,
                    ClassName ="fa fa-smoking"
                },

                new AttributeClass
                {
                    AttributeId = 129,
                    ClassName = "fas fa-swimmer"
                },

                new AttributeClass
                {
                    AttributeId = 137,
                    ClassName ="fas fa-shower"
                },

                new AttributeClass
                {
                    AttributeId = 142,
                    ClassName = "fas fa-dumbbell"
                },
                new AttributeClass
                {
                    AttributeId = 143,
                    ClassName = "fas fa-cut"
                },

                new AttributeClass
                {
                    AttributeId = 145,
                    ClassName = "fas fa-bath"
                },

                new AttributeClass
                {
                    AttributeId = 149,
                    ClassName = "fas fa-umbrella-beach"
                },

                new AttributeClass
                {
                    AttributeId = 148,
                    ClassName ="fa fa-smoking"
                },

                new AttributeClass
                {
                    AttributeId = 150,
                    ClassName = "fas fa-car"
                },
                new AttributeClass
                {
                    AttributeId = 158,
                    ClassName = "fas fa-ticket-alt"
                },

                new AttributeClass
                {
                    AttributeId = 160,
                    ClassName = "fas fa-wifi"
                },

                new AttributeClass
                {
                    AttributeId = 161,
                    ClassName = "fas fa-wifi"
                },

                new AttributeClass
                {
                    AttributeId = 164,
                    ClassName = "fas fa-tv"
                },
                new AttributeClass
                {
                    AttributeId = 165,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 168,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 169,
                    ClassName = "fas fa-wifi"
                },

                new AttributeClass
                {
                    AttributeId = 170,
                    ClassName = "fas fa-wifi"
                },

                new AttributeClass
                {
                    AttributeId = 176,
                    ClassName = "fab fa-accessible-icon"
                },

                new AttributeClass
                {
                    AttributeId = 177,
                    ClassName ="fas fa-shower"
                },

                new AttributeClass
                {
                    AttributeId = 182,
                    ClassName = "fas fa-utensils"
                },

                new AttributeClass
                {
                    AttributeId = 183,
                    ClassName = "fas fa-business-time"
                },

                new AttributeClass
                {
                    AttributeId = 186,
                    ClassName = "fas fa-bed"
                },
                new AttributeClass
                {
                    AttributeId = 188,
                    ClassName = "fas fas fa-child"
                },

                new AttributeClass
                {
                    AttributeId = 189,
                    ClassName = "fa fa-parking"
                },

                new AttributeClass
                {
                    AttributeId = 193,
                    ClassName = "fa fa-film"
                },

                new AttributeClass
                {
                    AttributeId = 201,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 202,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 209,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 210,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 216,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 219,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 223,
                    ClassName = "fas fa-swimming-pool"
                },

                new AttributeClass
                {
                    AttributeId = 224,
                    ClassName = "fas fa-swimmer"
                },

                new AttributeClass
                {
                    AttributeId = 225,
                    ClassName = "fas fas fa-hot-tub"
                },
                new AttributeClass
                {
                    AttributeId = 241,
                    ClassName ="fa fa-smoking"
                },

                new AttributeClass
                {
                    AttributeId = 250,
                    ClassName ="fas fa-shower"
                },

                new AttributeClass
                {
                    AttributeId = 251,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 257,
                    ClassName = "fas fa-hourglass-end"
                },

                new AttributeClass
                {
                    AttributeId = 258,
                    ClassName = "fas fa-cocktail"
                },

                new AttributeClass
                {
                    AttributeId = 211,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId = 256,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId = 264,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =265,
                    ClassName = "fa fa-parking"
                },

                new AttributeClass
                {
                    AttributeId =266,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =267,
                    ClassName = "fa fa-parking"
                },

                new AttributeClass
                {
                    AttributeId = 262,
                    ClassName = "fas fa-shower"
                },

                new AttributeClass
                {
                    AttributeId = 271,
                    ClassName = "fas fa-glass-martini"
                },

                new AttributeClass
                {
                    AttributeId = 272,
                    ClassName = "fas fa-glass-martini-alt"
                },

                new AttributeClass
                {
                    AttributeId = 273,
                    ClassName = "fas fa-cocktail"
                },

                new AttributeClass
                {
                    AttributeId = 277,
                    ClassName = "fas fa-coffee"
                },

                new AttributeClass
                {
                    AttributeId = 280,
                    ClassName = "fas fa-luggage-cart"
                },

                new AttributeClass
                {
                    AttributeId = 281,
                    ClassName = "fas fa-car"
                },

                new AttributeClass
                {
                    AttributeId = 282,
                    ClassName = "fas fa-car"
                },
                new AttributeClass
                {
                    AttributeId = 283,
                    ClassName = "fas fa-car"
                },
                new AttributeClass
                {
                    AttributeId = 284,
                    ClassName = "fas fa-car"
                },

                new AttributeClass
                {
                    AttributeId = 318,
                    ClassName = "fas fa-clock"
                },

                new AttributeClass
                {
                    AttributeId = 334,
                    ClassName = "fas fa-clock"
                },

                new AttributeClass
                {
                    AttributeId = 340,
                    ClassName = "fas fa-laptop"
                },

                new AttributeClass
                {
                    AttributeId = 342,
                    ClassName = "fas fa-clock"
                },
                new AttributeClass
                {
                    AttributeId = 346,
                    ClassName = "fas fa-tv"
                },

                new AttributeClass
                {
                    AttributeId = 361,
                    ClassName = "far fa-newspaper"
                },

                new AttributeClass
                {
                    AttributeId = 362,
                    ClassName = "fas fa-paw"
                },

                new AttributeClass
                {
                    AttributeId = 394,
                    ClassName = "fas fa-video"
                },

                new AttributeClass
                {
                    AttributeId = 396,
                    ClassName = "fas fa-table-tennis"
                },

                new AttributeClass
                {
                    AttributeId = 303,
                    ClassName = "fas fa-umbrella-beach"
                },

                new AttributeClass
                {
                    AttributeId =310,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =311,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =312,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =313,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =314,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =315,
                    ClassName = "fa fa-parking"
                },
                new AttributeClass
                {
                    AttributeId =316,
                    ClassName = "fa fa-parking"
                },

                new AttributeClass
                {
                    AttributeId = 349,
                    ClassName = "fas fa-dumbbell"
                },

                new AttributeClass
                {
                    AttributeId =366,
                    ClassName = "fa fa-parking"
                },

                new AttributeClass
                {
                    AttributeId = 397,
                    ClassName = "fas fa-music"
                },

                new AttributeClass
                {
                    AttributeId = 399,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 400,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 401,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 402,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 403,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 404,
                    ClassName = "fas fa-wifi"
                },
                new AttributeClass
                {
                    AttributeId = 405,
                    ClassName = "fas fa-wifi"
                },

                new AttributeClass
                {
                    AttributeId = 414,
                    ClassName = "fas fa-tv"
                },
            }.ToDictionary(key => key.AttributeId, val => val.ClassName);
        }

        private static IDictionary<int, string> _attributesClasses;

        private static IDictionary<int, string> AttributesToClasses =>
            _attributesClasses ?? (_attributesClasses = BuildAttributesToClasses());

        public static string AccommodationStarRating(this IHtmlHelper helper, decimal starRating)
        {
            if (starRating == 0) return string.Empty;

            var ul = new StringBuilder();

            ul.AppendLine($"<ul class=\"list-inline\">");

            for (var i = 0; i < (int)starRating; i++)
            {
                ul.AppendLine($"<li><i title=\"*\" class=\"glyphicon glyphicon-star\"></i></li>");
            }

            if (starRating.IsInteger()) ul.AppendLine("<li><i class=\"glyphicon glyphicon-star-empty\"></i></li>");

            ul.AppendLine("</ul>");

            return ul.ToString();
        }

        public static string GetPaymentClassContent(this IHtmlHelper helper, Attribute attribute)
        {
            if (!AttributesToClasses.TryGetValue(attribute.Id, out var cssClass))
            {
                cssClass = "fab fa-credit-card";
            }

            return cssClass;
        }

        public static string GetClassContent(this IHtmlHelper helper, Attribute attribute)
        {
            if (!AttributesToClasses.TryGetValue(attribute.Id, out var cssClass))
            {
                cssClass = "far fa-dot-circle";
            }

            return cssClass;
        }

        public static string GetAmenityOfAccommodationClassContent(this IHtmlHelper helper, Attribute attribute)
        {
            if (!AttributesToClasses.TryGetValue(attribute.Id, out var cssClass))
            {
                cssClass = "fas fa-info-circle";
            }

            return cssClass;
        }

        public static string GetAmenityOfRoomClassContent(this IHtmlHelper helper, Attribute attribute)
        {
            if (!AttributesToClasses.TryGetValue(attribute.Id, out var cssClass))
            {
                cssClass = "fas fa-check-circle";
            }

            return cssClass;
        }

        public static string AccommodationPaymentTypes(this IHtmlHelper helper,
            IEnumerable<Attribute> creditCards)
        {
            var attributes = creditCards as Attribute[] ?? creditCards.ToArray();
            if (!attributes.Any()) return string.Empty;

            var ul = new StringBuilder();
            ul.AppendLine("<ul class=\"list-inline\">");

            foreach (var creditCard in attributes)
            {
                if (!AttributesToClasses.TryGetValue(creditCard.Id, out var cssClass))
                {
                    cssClass = "fa-credit-card";
                }

                ul.AppendLine($"<li><i title=\"{creditCard.Description}\" class=\"fab {cssClass} payment\"></i></li>");
            }

            ul.AppendLine("</ul>");

            return ul.ToString();
        }
    }
}