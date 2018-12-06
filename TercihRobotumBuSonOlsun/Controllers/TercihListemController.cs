using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TercihRobotumBuSonOlsun.Models;

namespace TercihRobotumBuSonOlsun.Controllers
{
    public class TercihListemController : Controller
    {
        private TercihContext db = new TercihContext();

        // GET: TercihListem
        public ActionResult Index()
        {
            return View(db.TercihListesi.ToList());
        }

        // GET: TercihListem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercihListemModel tercihListemModel = db.TercihListesi.Find(id);
            if (tercihListemModel == null)
            {
                return HttpNotFound();
            }
            return View(tercihListemModel);
        }

        // GET: TercihListem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TercihListem/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] TercihListemModel tercihListemModel)
        {
            if (ModelState.IsValid)
            {
                db.TercihListesi.Add(tercihListemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tercihListemModel);
        }

        // GET: TercihListem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercihListemModel tercihListemModel = db.TercihListesi.Find(id);
            if (tercihListemModel == null)
            {
                return HttpNotFound();
            }
            return View(tercihListemModel);
        }

        // POST: TercihListem/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] TercihListemModel tercihListemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tercihListemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tercihListemModel);
        }

        // GET: TercihListem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercihListemModel tercihListemModel = db.TercihListesi.Find(id);
            if (tercihListemModel == null)
            {
                return HttpNotFound();
            }
            return View(tercihListemModel);
        }

        // POST: TercihListem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TercihListemModel tercihListemModel = db.TercihListesi.Find(id);
            db.TercihListesi.Remove(tercihListemModel);
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
