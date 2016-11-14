using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetAtSchoolClient.Controllers
{
    public class UserController : Controller
    {
        ControllerHelper ch = new ControllerHelper();
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult getAllStations()
        {
            return Json(ch.getAllStationNames(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuestionView(string name)
        {
            return View(ch.getQuestions(name));
        }






    }
}