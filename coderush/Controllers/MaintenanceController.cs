﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class MaintenanceController : Controller
    {
        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult Page404()
        {
            return View();
        }

        public ActionResult Page500()
        {
            return View();
        }
    }
}