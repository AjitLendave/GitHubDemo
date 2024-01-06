using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Common
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string src)
        {
            TagBuilder image = new TagBuilder("img");

            image.Attributes.Add("src", src);

            return new MvcHtmlString(image.ToString());
        }

    }
}