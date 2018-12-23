using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TercihRobotumBuSonOlsun.Models;

namespace TercihRobotumBuSonOlsun.Controllers
{
    public class VerilerController : ApiController
    {
        private TercihContext db = new TercihContext();

        // GET: api/Veriler
        public IQueryable<TercihVeriModel> GetTercihVerileri()
        {
            return db.TercihVerileri;
        }

        // GET: api/Veriler/5
        [ResponseType(typeof(TercihVeriModel))]
        public IHttpActionResult GetTercihVeriModel(int id)
        {
            TercihVeriModel tercihVeriModel = db.TercihVerileri.Find(id);
            if (tercihVeriModel == null)
            {
                return NotFound();
            }

            return Ok(tercihVeriModel);
        }

        // PUT: api/Veriler/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTercihVeriModel(int id, TercihVeriModel tercihVeriModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tercihVeriModel.Id)
            {
                return BadRequest();
            }

            db.Entry(tercihVeriModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TercihVeriModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Veriler
        [ResponseType(typeof(TercihVeriModel))]
        public IHttpActionResult PostTercihVeriModel(TercihVeriModel tercihVeriModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TercihVerileri.Add(tercihVeriModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tercihVeriModel.Id }, tercihVeriModel);
        }

        // DELETE: api/Veriler/5
        [ResponseType(typeof(TercihVeriModel))]
        public IHttpActionResult DeleteTercihVeriModel(int id)
        {
            TercihVeriModel tercihVeriModel = db.TercihVerileri.Find(id);
            if (tercihVeriModel == null)
            {
                return NotFound();
            }

            db.TercihVerileri.Remove(tercihVeriModel);
            db.SaveChanges();

            return Ok(tercihVeriModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TercihVeriModelExists(int id)
        {
            return db.TercihVerileri.Count(e => e.Id == id) > 0;
        }
    }
}