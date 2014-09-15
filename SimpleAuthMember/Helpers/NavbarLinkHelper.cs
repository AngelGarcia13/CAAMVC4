using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SimpleAuthMember.Helpers
{
    public static class NavbarLinkHelper
    {
        public static MvcHtmlString NavbarLink(this HtmlHelper helper, string name, string actionName, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];
            
            string isActiveClass = "";
            if(currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase)){
                isActiveClass = " class=\"active\"";
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<li {0}>", isActiveClass);
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            sb.AppendFormat("<a href=\"{0}\">{1}</a>", url.Action(actionName, controllerName), name);
            sb.Append("</li>");
            return new MvcHtmlString(sb.ToString());
}
    }
}