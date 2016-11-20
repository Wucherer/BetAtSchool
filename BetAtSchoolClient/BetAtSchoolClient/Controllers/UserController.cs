﻿using System;
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
            HttpContext.Session.Add("currentPlayer", player);
            HttpContext.Session.Add("currentStation", name);
            return RedirectToAction("QuestionView", "User");
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