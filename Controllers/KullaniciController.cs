using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelArama.Models;

namespace OtelArama.Controllers
{
    public class KullaniciController : Controller
    {
        OtelAramaModel ot = new OtelAramaModel();
        // GET: 


        public ActionResult Index(Musteri m)
        {
            return View(m);
        }
        [Authorize(Roles = "M")]
        public ActionResult Profilim()
        {
            string kullaniciadi = HttpContext.User.Identity.Name;
            //ViewBag.müsteri = ot.Musteri.ToList();
            Kullanici kullanici = ot.Kullanici.FirstOrDefault(x => x.kullanici_adi == kullaniciadi);
            Musteri musteri = ot.Musteri.FirstOrDefault(x => x.kullanici_id == kullanici.kullanici_id);


            return View("Index",musteri);
        }
        [HttpPost]
        public ActionResult Profilim(Musteri m)
        {
            
            ot.Musteri.AddOrUpdate(m);
            ot.SaveChangesAsync();
            ViewBag.mesaj = "Bilgileriniz Güncellendi";
            return RedirectToAction("Index", m);
           
        }
        




    }
}