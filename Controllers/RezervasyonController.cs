using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelArama.Models;

namespace OtelArama.Controllers
{
    public class RezervasyonController : Controller
    {
        OtelAramaModel ot = new OtelAramaModel();
        // GET: Rezervasyon
        public ActionResult Index(int id)
        {
            Odalar o = ot.Odalar.FirstOrDefault(x => x.oda_id == id);
            return View(o);
        }
        public ActionResult RezervasyonEkle(int id)
        {
            Odalar o = ot.Odalar.FirstOrDefault(x => x.oda_id == id);
            return View(o);
        }

        [HttpPost]
        [Authorize(Roles = "Y,A,M")]
        public ActionResult RezervasyonEkle(Rezervasyon r)
        {

            string kullaniciadi = HttpContext.User.Identity.Name;
            //ViewBag.müsteri = ot.Musteri.ToList();
            Kullanici kullanici = ot.Kullanici.FirstOrDefault(x => x.kullanici_adi == kullaniciadi);
            Musteri musteri = ot.Musteri.FirstOrDefault(x => x.kullanici_id == kullanici.kullanici_id);
            r.musteri_id = musteri.musteri_id;
            r.rezdurum_id = 1;
            Odalar o = ot.Odalar.FirstOrDefault(x => x.oda_id == r.oda_id);
            o.odadurumu = "dolu"; //rezerve edildi 
            ot.Rezervasyon.Add(r);
            ot.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            


            
        }
        [Authorize(Roles = "Y,A,M")]
        public ActionResult RezervasyonGoruntule(int id)
        {
            List<Rezervasyon> rezervasyonlar = ot.Rezervasyon.ToList();
            List<Rezervasyon> kullanicininRezervasyonlari = new List<Rezervasyon>();
           
            
            foreach (Rezervasyon item in rezervasyonlar)
            {
                if (item.musteri_id == id)
                {
                    kullanicininRezervasyonlari.Add(item);
                }
            }
            return View(kullanicininRezervasyonlari);


        }






    }
}