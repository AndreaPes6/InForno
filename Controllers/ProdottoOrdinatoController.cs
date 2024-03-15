using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using InForno.Models;

namespace InForno.Controllers
{
    public class ProdottoOrdinatoController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            int utenteID = (int)Session["UserID"];

            var prodottiCarrello = db.ProdottiOrdinati
                   .Where(c => c.ID == utenteID)
                   .Include(c => c.Prodotto)
                   .ToList();

            return View(prodottiCarrello);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiAlCarrello(int prodottoID)
        {
            try
            {
                int utenteID = (int)Session["UserID"];

                ProdottoOrdinato nuovoProdottoCarrello = new ProdottoOrdinato
                {
                    ID = utenteID,
                    ProdottiID = prodottoID,
                    Quantità = 1
                };

                db.ProdottiOrdinati.Add(nuovoProdottoCarrello);
                db.SaveChanges();

                return RedirectToAction("Index", "ProdottoOrdinato");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                throw;
            }
        }

        private int GeneraNumeroOrdine()
        {
            var ultimoOrdine = db.Storico.OrderByDescending(h => h.ID).FirstOrDefault();

            if (ultimoOrdine == null)
            {
                return 1;
            }

            return ultimoOrdine.NumeroOrdine + 1;
        }
    }
}
