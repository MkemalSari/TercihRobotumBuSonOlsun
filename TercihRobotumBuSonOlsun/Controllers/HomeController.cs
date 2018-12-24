using ClosedXML.Excel;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using TercihimNihaiProje.Models;
using TercihRobotumBuSonOlsun.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {

        TercihContext tercihContext = new TercihContext();
        List<TercihVeriModel> localList = new List<TercihVeriModel>();

        [HttpGet]
        public ActionResult Index(string sortOrder, string aramaMetni, string currentFilter, int? page, bool universiteDevlet = false)
        {



            bool test = universiteDevlet;

            ViewBag.SortingKodaGore = String.IsNullOrEmpty(sortOrder) ? "Koda_Gore" : "";
            ViewBag.SortingAdaGore = String.IsNullOrEmpty(sortOrder) ? "Ada_Gore" : "";
            ViewBag.SortingPuanTuruneGore = String.IsNullOrEmpty(sortOrder) ? "Puan_Turune_Gore" : "";
            ViewBag.SortingKontenjanaGore = String.IsNullOrEmpty(sortOrder) ? "Kontenjana_Gore" : "";
            ViewBag.SortingYerleseneGore = String.IsNullOrEmpty(sortOrder) ? "Yerlesene_Gore" : "";
            ViewBag.SortingEnKucukPuanaGore = String.IsNullOrEmpty(sortOrder) ? "En_Kucuk_Puana_Gore" : "";
            ViewBag.SortingEnBuyukPuanaGore = String.IsNullOrEmpty(sortOrder) ? "En_Buyuk_Puana_Gore" : "";
            
            ViewBag.CurrentSort = sortOrder;
            if (aramaMetni != null)
            { page = 1; }
            else
            { aramaMetni = currentFilter; }
            ViewBag.CurrentFilter = aramaMetni;

            localList = tercihContext.TercihVerileri.ToList();

          
            if (!String.IsNullOrEmpty(aramaMetni))
            {
                localList = localList.Where(s => s.ProgramAdi.ToLower().Contains(aramaMetni.ToLower()) ||
                s.ProgramKodu.ToLower().Contains(aramaMetni.ToLower())).ToList();

            }
            // Tablodaki Sıralamaları Yapıyoruz
            switch (sortOrder)
            {
                case "Koda_Gore":
                    localList = localList.OrderByDescending(sayfalar_logtut => sayfalar_logtut.ProgramKodu).ToList();
                    break;
                case "Ada_Gore":
                    localList = localList.OrderBy(sayfalar_logtut => sayfalar_logtut.ProgramAdi).ToList();
                    break;
                case "Puan_Turune_Gore":
                    localList = localList.OrderBy(sayfalar_logtut => sayfalar_logtut.PuanTuru).ToList();
                    break;
                case "Kontenjana_Gore":
                    localList = localList.OrderByDescending(sayfalar_logtut => int.Parse(sayfalar_logtut.Kontenjan)).ToList();
                    break;
                case "Yerlesene_Gore":
                    localList = localList.OrderByDescending(sayfalar_logtut => int.Parse(sayfalar_logtut.Yerlesen)).ToList();
                    break;
                case "En_Kucuk_Puana_Gore":
                    localList = localList.OrderByDescending(sayfalar_logtut => sayfalar_logtut.EnKucukPuan).ToList();
                    break;
                case "En_Buyuk_Puana_Gore":
                    localList = localList.OrderByDescending(sayfalar_logtut => sayfalar_logtut.EnBuyukPuan).ToList();
                    break;
                default:
                    localList = localList.OrderBy(sayfalar_logtut => sayfalar_logtut.ProgramKodu).ToList();
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return View(localList.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        [Authorize]
        public ActionResult Index(TercihVeriModel model) {

            ViewBag.data = model;
            
           string test = model.ProgramKodu;
            return View();

            
        }
        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Giris()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Uyelik()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
      
        // Kişinin Id sine göre Listesine ekleme Yapıyoruz
        public ActionResult Ekle(string ProgramKodu, string ProgramAdi, string PuanTuru, string Kontenjan, string Yerlesen, string EnKucukPuan, string EnBuyukPuan)
        {
          var userId=  User.Identity.GetUserId();
            MyViewModel model = new MyViewModel();

            model.ProgramKodu = ProgramKodu;
            model.ProgramAdi = ProgramAdi;
            model.PuanTuru = PuanTuru;
            model.Kontenjan = Kontenjan;
            model.Yerlesen = Yerlesen;
            model.EnKucukPuan = EnKucukPuan;
            model.EnBuyukPuan = EnBuyukPuan;
            model.UserlId = userId;
            tercihContext.Tercihler.Add(model);
            tercihContext.SaveChanges();

            return RedirectToAction("Index", "Home");
            
           
             // return View();
        }
        public void EkleDeneme(string myModel)
        {
            // your code           
        }
       
        public ActionResult TercihListem()
        {

            return View();
        }
    }
}
