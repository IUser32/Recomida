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
    public class ValoracionsController : Controller
    {
        private RecomidaModel db = new RecomidaModel();

        // GET: Valoracions
        public ActionResult Index()
        {
            var valoracion = db.Valoracion.Include(v => v.Restaurantes).Include(v => v.UserProfile);
            return View(valoracion.ToList());
        }

        // GET: Valoracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoracion.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // GET: Valoracions/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "Username");
            return View();
        }

        // POST: Valoracions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoracionID,UserId,RestauranteID,Puntuaje,Fecha")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Valoracion.Add(valoracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", valoracion.RestauranteID);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "Username", valoracion.UserId);
            return View(valoracion);
        }

        // GET: Valoracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoracion.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", valoracion.RestauranteID);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "Username", valoracion.UserId);
            return View(valoracion);
        }

        // POST: Valoracions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoracionID,UserId,RestauranteID,Puntuaje,Fecha")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Nombre", valoracion.RestauranteID);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "Username", valoracion.UserId);
            return View(valoracion);
        }

        // GET: Valoracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoracion.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // POST: Valoracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valoracion valoracion = db.Valoracion.Find(id);
            db.Valoracion.Remove(valoracion);
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
