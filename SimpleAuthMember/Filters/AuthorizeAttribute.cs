using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace SimpleAuthMember.Filters
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if(!WebSecurity.IsAuthenticated){
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                 {
                     { "controller", "Account" },
                     { "action", "Login" }
                 });
                return;
            }
            
            var authRoles = this.Roles.Split(',');
            bool isInRoles = false;
            
            var userRolesProvider = (SimpleRoleProvider) System.Web.Security.Roles.Provider;
            var userName = WebSecurity.CurrentUserName;
            var currentUserRoles = userRolesProvider.GetRolesForUser(userName);
            
            //--------------
            //Lambda Expression Implementation 

            isInRoles = currentUserRoles.Any(x => (this.Roles.IndexOf(x) != -1));
            //--------------
            /* Old Implementation
            foreach(var x in authRoles){
                if (userRolesProvider.IsUserInRole(userName, x)) {
                    isInRoles = true;
                    break;
                }
            }
            ----------------------
             */
            if (!isInRoles)
            {
                filterContext.Result = new RedirectToRouteResult(
                 new RouteValueDictionary
                 {
                     { "controller", "CustomErrors" },
                     { "action", "AccessDenied" }
                 });
            }

        }
    }
}