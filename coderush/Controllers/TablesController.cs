using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class TablesController : Controller
    {
        public ActionResult BasicTable()
        {
            return View();
        }

        public ActionResult DataTable()
        {
            return View();
        }
    }
}