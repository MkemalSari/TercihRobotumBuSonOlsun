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
    [Authorize]
    public class MyListController : Controller
    {
        private TercihContext db = new TercihContext();

        // GET: MyList
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var list = db.Tercihler.Where(a => a.UserlId == userId).OrderByDescending(a=> a.EnBuyukPuan);
            
            return View(list.ToList());
        }

        // GET: MyList/Details/5
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

        // GET: MyList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyList/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProgramKodu,ProgramAdi,PuanTuru,Kontenjan,Yerlesen,EnKucukPuan,EnBuyukPuan,UserlId")] MyViewModel myViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Tercihler.Add(myViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myViewModel);
        }

        // GET: MyList/Edit/5
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
            return View(myViewModel);
        }

        // POST: MyList/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProgramKodu,ProgramAdi,PuanTuru,Kontenjan,Yerlesen,EnKucukPuan,EnBuyukPuan,UserlId")] MyViewModel myViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myViewModel);
        }

        // GET: MyList/Delete/5
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
        public ActionResult Sil(int? id)
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
            db.Tercihler.Remove(myViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PdfCikart(int? id)
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
            db.Tercihler.Remove(myViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: MyList/Delete/5
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
