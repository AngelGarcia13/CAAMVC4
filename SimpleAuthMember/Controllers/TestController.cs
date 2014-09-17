using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleAuthMember.Controllers
{
    public class TestController : Controller
    {
        public bool Post(FormCollection form)
        {
            if (form["username"] == "angel" && form["password"] == "admin")
            {
                FormsAuthentication.SetAuthCookie(form["username"], false);
                return true;
            }

            return false;
        }

        [Authorize]
        public string GetInformation()
        {
            return "This is a top secret material that only authorized users can see";
        }

    }
}
