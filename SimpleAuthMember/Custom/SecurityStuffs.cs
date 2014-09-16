using SimpleAuthMember.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAuthMember.Custom
{
    //Singleton Pattern
    public class SecurityStuffs
    {
        
        private static SecurityStuffs instance = null;

        private SecurityStuffs()
        {

        }

        public static SecurityStuffs GetInstance()
        {
            if (instance == null)
                instance = new SecurityStuffs();

            return instance;
        }

        public static List<RouteElement> RoutesListByRole(string role)
        {
            var list = new List<RouteElement>();
            using (var db = new DataModel())
            {
                var queryRoutes = db.webpages_Roles.Where(x => x.RoleName.Equals(role, StringComparison.InvariantCultureIgnoreCase)).SelectMany(x => x.routes).ToList();
                foreach (var item in queryRoutes)
                {
                    list.Add(new RouteElement { Action = item.Action, Controller = item.Controller });
                }
            }
            return list;
        }


        public bool HasPermmisions(string[] roles, RouteElement route)
        {
            bool isRoleAuthorized = false;
            foreach (string role in roles)
            {
                var views = RoutesListByRole(role);

                if (views.Exists(x => x.Action == route.Action && x.Controller == route.Controller))
                {
                    isRoleAuthorized = true;
                    break;
                }
            }

            return isRoleAuthorized;

        }
    }
}