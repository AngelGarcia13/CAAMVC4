using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SimpleAuthMember.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            WebSecurity.CreateUserAndAccount(form["username"], form["password"], new { DisplayName = form["displayname"], Country = form["country"] }, false);
            Response.Redirect("~/account/login");
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection form) {
            bool success = WebSecurity.Login(form["username"], form["password"], false);
            if (success) {
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)
                {
                    Response.Redirect("~/home/index");
                }
                else
                {
                    Response.Redirect(returnUrl);
                }
            }
            return View();
        }

        public ActionResult Logout() {
            WebSecurity.Logout();
            Response.Redirect("~/account/login");
            return View();
        }
    }
}
