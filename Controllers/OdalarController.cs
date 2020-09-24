using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelArama.Models;

namespace OtelArama.Controllers
{
    public class OdalarController : Controller
    {
        OtelAramaModel ot = new OtelAramaModel();
        // GET: Odalar

   
        public ActionResult Index(int id)
        {

            List<Odalar> odalar = ot.Odalar.ToList();
            List<Odalar> odalarAynıOtel = new List<Odalar>();
            foreach (Odalar item in odalar)
            {
               if(item.otel_id == id)
                {
                    odalarAynıOtel.Add(item);
                }
            }
            return View(odalarAynıOtel);
                
        }
        [Authorize(Roles = "Y,A")]
        public ActionResult OdaEkle()
        {
            ViewBag.oteller = ot.Oteller.ToList();

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Y,A")]
        public ActionResult OdaEkle(Odalar o)
        {
            //if (User.Identity.Name == o.Oteller.OtelYonetimi.Kullanici.kullanici_adi)
            //{
                ot.Odalar.Add(o);
                int k = o.otel_id;
                ot.SaveChangesAsync();
                return RedirectToAction("Index", new { id = k }); //ındex, otel idsi ile otelin odalarına git
            //}
            //else return RedirectToAction("Index");
        }

        [Authorize(Roles = "Y,A")]
        public ActionResult OdaSil(int id)
        {
            Odalar o = ot.Odalar.FirstOrDefault(x => x.oda_id == id);

            return View(o);
        }
        [HttpPost]

        [Authorize(Roles = "Y,A")]
        public ActionResult OdaSil(Odalar o)
        {
            o = ot.Odalar.FirstOrDefault(x => x.oda_id == o.oda_id);
            ot.Odalar.Remove(o);
            ot.SaveChanges();

            return RedirectToAction("Index", new { id = o.otel_id });
        }


    }
}