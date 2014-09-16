using SimpleAuthMember.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SimpleAuthMember.Helpers
{
    public static class NavbarLinkHelper
    {
        public static MvcHtmlString NavbarLink(this HtmlHelper helper, string name, string actionName, string controllerName)
        {
            var sb = new StringBuilder();
            var routeElement = new RouteElement { Action = actionName, Controller = controllerName };
            var currentUserRoles = new string[] { "Unregister" };
            if (WebSecurity.IsAuthenticated)
            {
                var userRolesProvider = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
                var userName = WebSecurity.CurrentUserName;
                currentUserRoles = userRolesProvider.GetRolesForUser(userName);
            }

            if (!SecurityStuffs.GetInstance().HasPermmisions(currentUserRoles, routeElement))
            {
                return new MvcHtmlString(sb.ToString());
            }

            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            string isActiveClass = "";
            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            {
                isActiveClass = " class=\"active\"";
            }

            sb.AppendFormat("<li {0}>", isActiveClass);
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            sb.AppendFormat("<a href=\"{0}\">{1}</a>", url.Action(actionName, controllerName), name);
            sb.Append("</li>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}