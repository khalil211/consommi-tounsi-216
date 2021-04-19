using ConsommiTounsi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //if (Session["user"] == null || ((User)Session["user"]).type != UserType.ADMIN)
            //    return RedirectToAction("Index", "Home");
            
            return View();
        }
    }
}