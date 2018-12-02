﻿using ClosedXML.Excel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TercihimNihaiProje.Models;
using TercihRobotumBuSonOlsun.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        TercihListemModel tercihListem = new TercihListemModel();
        
        List<MyViewModel> localList = new List<MyViewModel>();
        [HttpGet]
        public ActionResult Index(string sortOrder, string aramaMetni, string currentFilter, int? page)
        {
            tercihListem.Id = 1;
            tercihListem.ad = "Yks Liste 1";

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


            string fileName = Server.MapPath("~/veri/Tablo2LisansYKS2018.xlsx");


            using (var excelWorkbook = new XLWorkbook(fileName))
            {
                var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();


                foreach (var dataRow in nonEmptyDataRows)
                {
                    MyViewModel model = new MyViewModel();
                    //for row number check

                    if (dataRow.RowNumber() > 1 && dataRow.Cell(1).Value.ToString() != "Program Kodu"
                        && dataRow.Cell(1).Value.ToString() != "TABLO-4 Merkezi Yerleştirme İle Öğrenci Alan Yükseköğretim Lisans Programları"
                        && dataRow.Cell(1).Value.ToString() != ""
                        )
                    {   //TAblo verileribi Gönderdiğim Yer
                        model.ProgramKodu = dataRow.Cell(1).Value.ToString();
                        model.ProgramAdi = dataRow.Cell(2).Value.ToString();
                        model.PuanTuru = dataRow.Cell(3).Value.ToString();
                        model.Kontenjan = dataRow.Cell(4).Value.ToString();
                        model.Yerlesen = dataRow.Cell(5).Value.ToString();
                        if (dataRow.Cell(6).Value.ToString() == "--")
                        {
                            model.EnKucukPuan = "0";
                        }
                        else
                        {
                            model.EnKucukPuan = dataRow.Cell(6).Value.ToString();
                        }
                        if (dataRow.Cell(7).Value.ToString() == "--")
                        {
                            model.EnBuyukPuan = "0";
                        }
                        else
                        {
                            model.EnBuyukPuan = dataRow.Cell(7).Value.ToString();
                        }


                        localList.Add(model);
                    }

                }


            }
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
        public ActionResult Index(MyViewModel model) {

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
      
        public ActionResult Ekle(string myModel)
        {

            string test = localList.Where(a => a.ProgramKodu == myModel).ToString();

            return RedirectToAction("Index", "Home");
            
           
             // return View();
        }
        public void EkleDeneme(string myModel)
        {
            // your code           
        }
    }
}
