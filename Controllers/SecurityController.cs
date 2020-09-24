using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelArama.Models;

namespace OtelArama.Controllers
{
    public class SecurityController : Controller
    {
        OtelAramaModel ot = new OtelAramaModel();
        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici k)
        {
            Kullanici kullanici = ot.Kullanici.FirstOrDefault(x => x.kullanici_adi == k.kullanici_adi && x.kullanici_sifre == k.kullanici_sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullanici_adi, false); //false beni hatırla
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }
      

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(Kullanici k)
        {

            List<Kullanici> kullanicilar = ot.Kullanici.ToList();
           
           
                if (kullanicilar.Any(x=>x.kullanici_adi==k.kullanici_adi ))
                {
                    ViewBag.mesaj1 = "bu isimde bir kullanıcı var!";//burayı ve
                return PartialView("Login");//burayı js kısmına taşı 
                }
                else
                {

                          k.kullanici_turu = "M";
                          ot.Kullanici.Add(k);
                          ot.SaveChangesAsync();
                          return RedirectToAction("Index", "Home");
                }

        }


    }
}