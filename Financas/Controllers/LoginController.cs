using System;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(String login, String senha)
        {
            if(WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha Incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
    }
}