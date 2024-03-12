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
    }
}