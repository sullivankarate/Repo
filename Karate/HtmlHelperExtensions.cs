using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Karate
{
    public static class HtmlHelperExtensions
    {

        public static string Image(this HtmlHelper helper,
                                    string url,
                                    string altText,
                                    string click,
                                    object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.Attributes.Add("onClick", click);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}