﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reporter_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generate()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Admin()
        {
            

            return View();
        }
    }
}