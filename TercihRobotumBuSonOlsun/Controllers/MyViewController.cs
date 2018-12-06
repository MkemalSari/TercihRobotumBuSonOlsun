using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TercihRobotumBuSonOlsun.Models;
using TercihimNihaiProje.Models;
using Microsoft.AspNet.Identity;

namespace TercihRobotumBuSonOlsun.Controllers
{
    public class MyViewController : Controller
    {
        private TercihContext db = new TercihContext();

        // GET: MyView
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            

            var tercihler = db.Tercihler.Where(m => m.TercihListemModel.UserId==userId);
            return View(tercihler.ToList());
        }

        // GET: MyView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyViewModel myViewModel = db.Tercihler.Find(id);
            if (myViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myViewModel);
        }

        // GET: MyView/Create
        public ActionResult Create()
        {
            ViewBag.TercihListemModelId = new SelectList(db.TercihListesi, "Id", "UserId");
            return View();
        }

        // POST: MyView/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProgramKodu,ProgramAdi,PuanTuru,Kontenjan,Yerlesen,EnKucukPuan,EnBuyukPuan,TercihListemModelId")] MyViewModel myViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Tercihler.Add(myViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TercihListemModelId = new SelectList(db.TercihListesi, "Id", "UserId", myViewModel.TercihListemModelId);
            return View(myViewModel);
        }

        // GET: MyView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyViewModel myViewModel = db.Tercihler.Find(id);
            if (myViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TercihListemModelId = new SelectList(db.TercihListesi, "Id", "UserId", myViewModel.TercihListemModelId);
            return View(myViewModel);
        }

        // POST: MyView/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProgramKodu,ProgramAdi,PuanTuru,Kontenjan,Yerlesen,EnKucukPuan,EnBuyukPuan,TercihListemModelId")] MyViewModel myViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TercihListemModelId = new SelectList(db.TercihListesi, "Id", "UserId", myViewModel.TercihListemModelId);
            return View(myViewModel);
        }

        // GET: MyView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyViewModel myViewModel = db.Tercihler.Find(id);
            if (myViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myViewModel);
        }

        // POST: MyView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyViewModel myViewModel = db.Tercihler.Find(id);
            db.Tercihler.Remove(myViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
