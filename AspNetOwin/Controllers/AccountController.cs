using AspNetOwin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetOwin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Implementar autenticação Owin aqui

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Preencha corretamente os campos solicitados.");
                    return View(model);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

    }
}