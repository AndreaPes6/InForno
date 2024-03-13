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
    public class ProdottoOrdinatoController : Controller
    {
        private DBContext db = new DBContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var ordiniConProdotti = db.ProdottoOrdinato.Include(po => po.Prodotto).Include(po => po.Checkout);
            return View(ordiniConProdotti.ToList());
        }

        [Authorize(Roles = "Admin,Utente")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ordineConProdotti = db.ProdottoOrdinato
                .Include(po => po.Checkout)
                .Include(po => po.Prodotto)
                .Where(po => po.CheckoutID == id)
                .ToList();

            var ordineDettagliato = db.Checkout.FirstOrDefault(o => o.ID == id);
            TempData["orderDetails"] = ordineDettagliato;

            if (ordineConProdotti == null)
            {
                return HttpNotFound();
            }

            return View(ordineConProdotti);
        }

        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult Create()
        {
            ViewBag.ProdottiID = new SelectList(db.Prodotto, "ID", "Nome");
            ViewBag.CheckoutID = new SelectList(db.Checkout, "ID", "IndirizzoSpedizione");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult Create([Bind(Include = "ProdottiID,CheckoutID,Quantità")] ProdottoOrdinato prodottoOrdinato)
        {
            if (ModelState.IsValid)
            {
                db.ProdottoOrdinato.Add(prodottoOrdinato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdottiID = new SelectList(db.Prodotto, "ID", "Nome", prodottoOrdinato.ProdottiID);
            ViewBag.CheckoutID = new SelectList(db.Checkout, "ID", "IndirizzoSpedizione", prodottoOrdinato.CheckoutID);
            return View(prodottoOrdinato);
        }

        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult Edit(int? prodottoId, int? checkoutId)
        {
            if (prodottoId == null || checkoutId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var prodottoOrdinato = db.ProdottoOrdinato
                .Include(po => po.Prodotto)
                .FirstOrDefault(po => po.ProdottiID == prodottoId && po.CheckoutID == checkoutId);

            if (prodottoOrdinato == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProdottiID = new SelectList(db.Prodotto, "ID", "Nome", prodottoOrdinato.ProdottiID);
            ViewBag.CheckoutID = new SelectList(db.Checkout, "ID", "IndirizzoSpedizione", prodottoOrdinato.CheckoutID);

            return View(prodottoOrdinato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult Edit([Bind(Include = "ProdottiID,CheckoutID,Quantità")] ProdottoOrdinato prodottoOrdinato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodottoOrdinato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdottiID = new SelectList(db.Prodotto, "ID", "Nome", prodottoOrdinato.ProdottiID);
            ViewBag.CheckoutID = new SelectList(db.Checkout, "ID", "IndirizzoSpedizione", prodottoOrdinato.CheckoutID);

            return View(prodottoOrdinato);
        }

        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProdottoOrdinato prodottoOrdinato = db.ProdottoOrdinato.Find(id);

            if (prodottoOrdinato == null)
            {
                return HttpNotFound();
            }

            return View(prodottoOrdinato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Amministratore,Cliente")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdottoOrdinato prodottoOrdinato = db.ProdottoOrdinato.Find(id);
            db.ProdottoOrdinato.Remove(prodottoOrdinato);
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
