using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelArama.Models;
using OtelArama.Security;

namespace OtelArama.Controllers
{
    public class OtellerController : Controller
    {
        // GET: Urun
        OtelAramaModel ot = new OtelAramaModel();

        public ActionResult Index()
        {
            List<Oteller> oteller = ot.Oteller.ToList();

            return View(oteller);
        }
        [Authorize(Roles = "A")]
        public ActionResult OtelEkle()
        {
            ViewBag.otelyonetimi = ot.OtelYonetimi.ToList();
           
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult OtelEkle(Oteller o)
        {
            ot.Oteller.AddOrUpdate(o);
            ot.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

        [Authorize(Roles = "A")]
        public ActionResult OtelSil(int id)
        {
            Oteller o = ot.Oteller.FirstOrDefault(x => x.otel_id == id);

            return View(o);
        }
        [HttpPost]

        [Authorize(Roles = "A")]
        public ActionResult OtelSil(Oteller o)
        {
            o = ot.Oteller.FirstOrDefault(x => x.otel_id == o.otel_id);
            ot.Oteller.Remove(o);
            ot.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult OtelGuncelle(int id)

        {
            ViewBag.otelyonetimi = ot.OtelYonetimi.ToList();
            Oteller oteller = ot.Oteller.FirstOrDefault(x => x.otel_id == id);

            return View("OtelGuncelle", oteller);
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult OtelGuncelle(Oteller o)
        {
            ot.Oteller.AddOrUpdate(o);
            ot.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}