﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using System.Web;
using System.Web.Mvc;

namespace MVC_Template.Controllers
{
    public class HomeController : Controller
    {
        private OMMBCEntities db = new OMMBCEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}