using BetAtSchoolClient.Models;
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
            return Json(ch.getAllStationNames(ch.getAll()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuestionView()
        {
            Player p = HttpContext.Session["currentPlayer"] as Player;

            if(p.name == null)
            {
                p = new Player();
                HttpContext.Session.Add("currentPlayer", p);
            }

            string s = HttpContext.Session["currentQuestion"] as string;
            if (s != null)
            {
                HttpContext.Session["currentQuestion"] = (int.Parse(s) + 1).ToString();
            }
            else { HttpContext.Session.Add("currentQuestion", "0"); }


            string currStation = HttpContext.Session["currentStation"] as string;

            return View(ch.getStationByName(currStation, ch.getAll()));
        }

        public ActionResult setStation(string name, string player)
        {
            Player p = new Player(player, 100);
            HttpContext.Session.Add("currentPlayer", p);
            HttpContext.Session.Add("currentStation", name);
            bool b = ch.checkIfUserExists(player); 
            
            return RedirectToAction("QuestionView", "User");
        }

        public ActionResult setScore(string score)
        {

            return Content("");
        }

        public ActionResult skipQuestion()
        {
            int s = int.Parse(HttpContext.Session["currentQuestion"] as string) + 1;
            HttpContext.Session["currentQuestion"] = s.ToString();
            return RedirectToAction("QuestionView", "User");
        }

        public ActionResult exitQuestion()
        {
            HttpContext.Session["currentQuestion"] = "0";
            return RedirectToAction("Index", "User");

        }
    }
}