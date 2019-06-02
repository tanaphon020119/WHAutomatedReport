using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class MapsController : Controller
    {
        public ActionResult VectorMap()
        {
            return View();
        }

        public ActionResult GoogleMap()
        {
            return View();
        }
    }
}