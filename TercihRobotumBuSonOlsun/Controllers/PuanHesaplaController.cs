using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TercihRobotumBuSonOlsun.Models;

namespace TercihRobotumBuSonOlsun.Controllers
{
    public class PuanHesaplaController : Controller
    {
        // GET: PuanHesapla
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Index(PuanHesaplaModel model)
        {

            
            if (ModelState.IsValid)
            {
                double turkceNet = (double)model.turkceDogru-((double)model.turkceYanlis/4);
                double sosyalNet = (double)model.sosyalDogru - ((double)model.sosyalYanlis/4);
                double matematikNet = (double)model.matematikDogru - ((double)model.matematikYanlis/4);
                double fenNet = (double)model.fenDogru - ((double)model.fenYanlis/4);

                ViewBag.turkceNet = turkceNet;
                ViewBag.sosyalNet = sosyalNet;
                ViewBag.matematikNet = matematikNet;
                ViewBag.fenNet = fenNet;

               ViewBag.tytPuan= PuanHesapla(turkceNet, sosyalNet, matematikNet, fenNet, model.diplomaNotu);

            }
            return View();
        }
        public double PuanHesapla(double turkceNet,double sosyalNet,double matematikNet,double fenNet,double diplomaNotu)
        {
            double sonuc = 100 + ((turkceNet * 3.3) + (sosyalNet * 3.4) + (matematikNet * 3.3) + (fenNet * 3.4) + (diplomaNotu * 0.6));

            return sonuc;
        }
    }
}