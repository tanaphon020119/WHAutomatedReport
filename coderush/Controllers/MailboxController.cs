using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class MailboxController : Controller
    {
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult Compose()
        {
            return View();
        }

        public ActionResult Template()
        {
            return View();
        }
    }
}