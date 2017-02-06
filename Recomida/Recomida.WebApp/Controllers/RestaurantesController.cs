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
    public class RestaurantesController : Controller
    {
        private RecomidaModel db = new RecomidaModel();

        // GET: Restaurantes
        public ActionResult Index()
        {
            var restaurantes = db.Restaurantes.Include(r => r.TipoComida).Include(r => r.TipoRestaurante);
            return View(restaurantes.ToList());
        }

        // GET: Restaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            return View(restaurantes);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            ViewBag.TipoComidaID = new SelectList(db.TipoComida, "TipoComidaID", "Descripcion");
            ViewBag.TipoRestauranteID = new SelectList(db.TipoRestaurante, "TipoRestauranteID", "Descripcion");
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestauranteID,TipoRestauranteID,TipoComidaID,Nombre,Telefono")] Restaurantes restaurantes)
        {
            if (ModelState.IsValid)
            {
                db.Restaurantes.Add(restaurantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoComidaID = new SelectList(db.TipoComida, "TipoComidaID", "Descripcion", restaurantes.TipoComidaID);
            ViewBag.TipoRestauranteID = new SelectList(db.TipoRestaurante, "TipoRestauranteID", "Descripcion", restaurantes.TipoRestauranteID);
            return View(restaurantes);
        }

        // GET: Restaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoComidaID = new SelectList(db.TipoComida, "TipoComidaID", "Descripcion", restaurantes.TipoComidaID);
            ViewBag.TipoRestauranteID = new SelectList(db.TipoRestaurante, "TipoRestauranteID", "Descripcion", restaurantes.TipoRestauranteID);
            return View(restaurantes);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestauranteID,TipoRestauranteID,TipoComidaID,Nombre,Telefono")] Restaurantes restaurantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoComidaID = new SelectList(db.TipoComida, "TipoComidaID", "Descripcion", restaurantes.TipoComidaID);
            ViewBag.TipoRestauranteID = new SelectList(db.TipoRestaurante, "TipoRestauranteID", "Descripcion", restaurantes.TipoRestauranteID);
            return View(restaurantes);
        }

        // GET: Restaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            return View(restaurantes);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurantes restaurantes = db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurantes);
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
