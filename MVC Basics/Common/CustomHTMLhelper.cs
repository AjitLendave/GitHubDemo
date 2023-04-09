using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Basics.Common
{
    public static class CustomHTMLhelper
    {
        //Write Extention metod for @Html.Image()

        public static MvcHtmlString Image(this HtmlHelper html, string src)
        {
            //write a logic to create img tag to return image to browser

            TagBuilder image = new TagBuilder("img");
            image.Attributes.Add("src", src);

            return new MvcHtmlString(image.ToString());
        }
    }
}