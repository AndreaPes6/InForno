using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InForno.Models;

namespace InForno.Controllers
{
    public class UtentiController : Controller
    {
        DBContext db = new DBContext();

        [Authorize(Roles = "Admin")]
        public ActionResult PaginaAdmin()
        {
            var user = User;
            var utenti = db.Utenti.ToList();
            return View(utenti);
        }

        [Authorize(Roles = "Utente")]
        public ActionResult PaginaUtenti()
        {
            var user = User;
            var utenti = db.Utenti.ToList();
            return View(utenti);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Utenti utenti)
        {
            if (ModelState.IsValid)
            {

                if (db.Utenti.Any(u => u.Username == utenti.Username || u.Email == utenti.Email))
                {
                    ModelState.AddModelError("", "L'utente con lo stesso nome utente o email esiste già.");
                    return View(utenti);
                }

                db.Utenti.Add(utenti);
                db.SaveChanges();

                Session["UserID"] = utenti.ID;

                return RedirectToAction("Index", "Prodotto");
            }

            return View(utenti);
        }


    }
}