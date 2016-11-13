using BetAtSchoolClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetAtSchoolClient.Controllers
{
    public class LoginController : Controller
    {
        ControllerHelper ch = new ControllerHelper();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult returnUser(string username, string password)
        {
            //UserGuide u = ch.getUser();
            string s = null;
            if(s == null)
            {
                s = "../User/NotFound";
            } else
            {
                s = "../User/Index";
            }

            Session["currentGuide"] = "asdf";

            return RedirectToAction("../User/Index");
        }
    }
}