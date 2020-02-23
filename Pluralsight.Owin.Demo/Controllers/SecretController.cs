using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pluralsight.Owin.Demo.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        // GET: Secret
        public ActionResult Index()
        {
            return View();
        }
    }
}