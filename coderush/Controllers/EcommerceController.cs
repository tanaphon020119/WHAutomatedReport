using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class EcommerceController : Controller
    {
        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult PricingTable()
        {
            return View();
        }
    }
}