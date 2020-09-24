using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelArama.Models;

namespace OtelArama.Controllers
{
    public class HomeController : Controller
    {
        OtelAramaModel oa = new OtelAramaModel();

        // GET: Home
        public ActionResult Index()
        {
            List<Oteller> oteller = oa.Oteller.ToList();
            return View(oteller);
        }
    }
}