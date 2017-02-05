using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recomida.WebApp.Models.Context;

namespace Recomida.WebApp.Controllers
{
    public class TipoComidasController : Controller
    {
        private RecomidaModel db = new RecomidaModel();

        // GET: TipoComidas
        public ActionResult Index()
        {
            return View(db.TipoComida.ToList());
        }

        // GET: TipoComidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComida tipoComida = db.TipoComida.Find(id);
            if (tipoComida == null)
            {
                return HttpNotFound();
            }
            return View(tipoComida);
        }

        // GET: TipoComidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoComidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoComidaID,Descripcion")] TipoComida tipoComida)
        {
            if (ModelState.IsValid)
            {
                db.TipoComida.Add(tipoComida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoComida);
        }

        // GET: TipoComidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComida tipoComida = db.TipoComida.Find(id);
            if (tipoComida == null)
            {
                return HttpNotFound();
            }
            return View(tipoComida);
        }

        // POST: TipoComidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoComidaID,Descripcion")] TipoComida tipoComida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoComida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoComida);
        }

        // GET: TipoComidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComida tipoComida = db.TipoComida.Find(id);
            if (tipoComida == null)
            {
                return HttpNotFound();
            }
            return View(tipoComida);
        }

        // POST: TipoComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoComida tipoComida = db.TipoComida.Find(id);
            db.TipoComida.Remove(tipoComida);
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
