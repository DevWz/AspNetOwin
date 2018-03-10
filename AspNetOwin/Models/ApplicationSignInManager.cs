using AspNetOwin.Core.Models;
using AspNetOwin.Core.Models.DB;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AspNetOwin.Models
{
    public class ApplicationSignInManager
    {

        IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public void Register(RegisterViewModel model)
        {
            using (AspNetOwinDbContext data = new AspNetOwinDbContext())
            {
                Cliente cliente = new Cliente()
                {
                    Email = model.Email,
                    Senha = model.Senha,
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };

                data.Clientes.Add(cliente);
                data.SaveChanges();
            }
        }

        public bool IsRegistered(string email)
        {
            using (AspNetOwinDbContext data = new AspNetOwinDbContext())
            {
                return data.Clientes.Where(x => x.Email.Equals(email)).Any();
            }
        }

        public bool PasswordCompare(LoginViewModel model)
        {
            using (AspNetOwinDbContext data = new AspNetOwinDbContext())
            {
                if (IsRegistered(model.Email))
                {
                    Cliente cliente = data.Clientes.Where(x => x.Email.Equals(model.Email)).First();
                    return cliente.Senha == model.Senha ? true : false;
                }
                else
                {
                    return false;
                }
            }
        }

        public void SignIn(string email)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, email));

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            }, new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie));
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

    }
}