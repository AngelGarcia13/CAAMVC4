using SimpleAuthMember.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace SimpleAuthMember.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                Response.Redirect("~/account/login");
            }

            var userId = WebSecurity.CurrentUserId;

            using (var db = new DataModel())
            {
                var userInfo = db.Users.FirstOrDefault(x => x.ID == userId);
                ViewBag.displayName = userInfo;
            }
            
            return View();
        }

    }
}
