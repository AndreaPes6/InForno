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

        // GET: Prodotto
        public ActionResult Index()
        {
            var prodotti = db.Prodotto.ToList();
            return View(prodotti);
        }

        // GET: Prodotto/Details/5
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

        // GET: Prodotto/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Utenti, "ID", "Username");
            return View();
        }

        // POST: Prodotto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Foto,Nome,Descrizione,Prezzo,TempoDiConsegna")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                db.Prodotto.Add(prodotto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Utenti, "ID", "Username", prodotto.ID);
            return View(prodotto);
        }

        // GET: Prodotto/Edit/5
        public ActionResult Edit(int? id)
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

            ViewBag.UserId = new SelectList(db.Utenti, "ID", "Username", prodotto.ID);
            return View(prodotto);
        }

        // POST: Prodotto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Foto,Nome,Descrizione,Prezzo,TempoDiConsegna")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodotto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Utenti, "ID", "Username", prodotto.ID);
            return View(prodotto);
        }

        // GET: Prodotto/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Prodotto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
