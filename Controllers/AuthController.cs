using System;
using System.Linq;
using System.Web.Mvc;
using InForno.Models;
using System.Web.Security;

namespace InForno.Controllers
{
    public class AuthController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti utenti)
        {
            var loggedUser = db.Utenti.FirstOrDefault(u => u.Username == utenti.Username && u.Password == utenti.Password);
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = true;
                return RedirectToAction("Login");
            }

            if (loggedUser.Ruolo == "Admin")
            {
                FormsAuthentication.SetAuthCookie(loggedUser.ID.ToString(), true);
                Session["AdminID"] = loggedUser.ID;
                return RedirectToAction("PaginaAdmin", "Utenti");
            }
            else if (loggedUser.Ruolo == "Utente")
            {
                FormsAuthentication.SetAuthCookie(loggedUser.ID.ToString(), true);
                Session["UserID"] = loggedUser.ID;
                return RedirectToAction("PaginaUtenti", "Utenti");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
