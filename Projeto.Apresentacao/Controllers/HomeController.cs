using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Web.Security;
using Projeto.Aplicacao.Contratos;
using Projeto.Entidades;
using Projeto.Apresentacao.Models;

namespace Projeto.Apresentacao.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsuarioAplicacao appUsuario;

        public HomeController(IUsuarioAplicacao appUsuario)
        {
            this.appUsuario = appUsuario;
        }


        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Home/AcessoNegado
        public ActionResult AcessoNegado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HomeViewModelLogin model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Usuario u = appUsuario.Autenticar(model.EmailAcesso, model.SenhaAcesso);

                    if (u != null)
                    {
                        //ticket de acesso do usuario 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(u.IdUsuario.ToString(), false, 5);

                        //criando um cookie para gravar o tiket do usuario
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                        Response.Cookies.Add(cookie);

                        Session.Add("usuario", u);

                        return RedirectToAction("Index", "Usuario", new { area = "AreaRestrita" });

                    }

                }
                catch (Exception e)
                {
                    ViewBag.MsgErro = e.Message;
                }

            }

            return View();
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            //destruir o ticket do usuario..
            FormsAuthentication.SignOut();

            //redirecionar para a página de login..
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        // GET : Home/EsqueceuSenha
        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EsqueceuSenha(HomeViewModelEsqueceuSenha model)
        {
            return View();
        }
    }
}