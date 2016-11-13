using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            Console.WriteLine(username);
            return View("KidIndex");
        }
    }
}