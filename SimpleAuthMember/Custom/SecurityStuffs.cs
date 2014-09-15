using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAuthMember.Custom
{
    public static class SecurityStuffs
    {
        //private static Dictionary<string, List<object>> d = new Dictionary<string, List<object>>();
        public static List<RouteElement> AdminList()
        {
            var list = new List<RouteElement> { 
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""}
            };
            return list;
        }
        public static List<RouteElement> UserList()
        {
            var list = new List<RouteElement> { 
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""},
            new RouteElement{Action="",Controller=""}
            };
            return list;
        }

        public static List<RouteElement> UnregisterList()
        {
            var list = new List<RouteElement> { 
            new RouteElement{Action="Index",Controller="Home"},
            new RouteElement{Action="Register",Controller="Account"},
            new RouteElement{Action="Login",Controller="Account"}
            };
            return list;
        }
        public static Dictionary<string, List<RouteElement>> GetDictionary()
        {
            var d = new Dictionary<string, List<RouteElement>>();
            d.Add("unregister", UnregisterList());
            d.Add("admin", AdminList());
            d.Add("user", UserList());
            return d;
        }
        public static bool HasPermmisions(string[] roles, RouteElement route){
            var d = GetDictionary();
            bool isRoleAuthorized = false;
            foreach(string role in roles){
                if (d.ContainsKey(role))
                {
                    var views = d[role];

                    if (views.Exists(x=> x.Action == route.Action && x.Controller == route.Controller)) {
                        isRoleAuthorized =  true;
                        break;
                    }
                }
            }
            return isRoleAuthorized;
 
        }
    }
}