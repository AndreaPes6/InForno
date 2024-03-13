using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InForno.Models;

namespace InForno.Controllers
{
    public class ProdottoController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.Prodotto.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotto prodotto = db.Prodotto.Find(id);
            if (prodotto == null)
            {
                return HttpNotFound();
            }
            return View(prodotto);
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Create([Bind(Include = "ID,Foto,Nome,Descrizione,Prezzo,TempoDiConsegna")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                db.Prodotto.Add(prodotto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodotto);
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotto prodotti = db.Prodotto.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Foto,Nome,Descrizione,Prezzo,TempoDiConsegna")] Prodotto prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodotti);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotto prodotti = db.Prodotto.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodotto prodotto = db.Prodotto.Find(id);
            db.Prodotto.Remove(prodotto);
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
