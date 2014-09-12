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
            Response.StatusCode = 400;
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
            
        }

        public ActionResult AccessDenied()
        {
            Response.SuppressFormsAuthenticationRedirect = true;
            Response.StatusCode = 401;
            
            return View();
            
        }

    }
}
