using SimpleAuthMember.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
namespace SimpleAuthMember.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        //[CustomAuthorize(Roles = "Admin,User")]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


    }
}
