using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SimpleAuthMember.Controllers
{
    public class CustomErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
            //return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Page Not Found");
        }

        public ActionResult AccessDenied()
        {
            return View();
            //return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Access Denied");
        }

    }
}
