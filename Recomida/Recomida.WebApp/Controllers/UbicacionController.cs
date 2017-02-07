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
    public class UbicacionController : Controller
    {
        private RecomidaModel db = new RecomidaModel();

        // GET: Ubicacion
        public ActionResult Index()
        {
            var ubicacion = db.Ubicacion.Include(u => u.Restaurantes);
            return View(ubicacion.ToList());
        }

        // GET: Ubicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // GET: Ubicacion/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre");
            return View();
        }

        // POST: Ubicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestauranteID,Pais,Ciudad,Direccion,Latitud,Longitud")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", ubicacion.RestauranteID);
            return View(ubicacion);
        }

        // GET: Ubicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", ubicacion.RestauranteID);
            return View(ubicacion);
        }

        // POST: Ubicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestauranteID,Pais,Ciudad,Direccion,Latitud,Longitud")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", ubicacion.RestauranteID);
            return View(ubicacion);
        }

        // GET: Ubicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // POST: Ubicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            db.Ubicacion.Remove(ubicacion);
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
