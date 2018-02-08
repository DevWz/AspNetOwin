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
                    // Autenticação
                    if (true)
                    {
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return RedirectToAction(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Preencha corretamente os campos solicitados.");
                        return View(model);
                    }
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

        // GET: Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Autenticação
                    if (true)
                    {
                        // ADD
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Uma conta já está cadastrada com este email.");
                        return View(model);
                    }
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

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }

    }
}