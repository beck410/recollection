using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recollection.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}