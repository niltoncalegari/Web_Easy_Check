using System;
using System.Web.Mvc;
using Web_Easy_Check.Models;
using Web_Easy_Check.Service;

namespace Web_Easy_Check.Controllers
{
    public class LoginController : Controller
    {
        private LoginService _loginService = new LoginService();

        // GET: Login
        public ActionResult LoginIndex(string erro = null)
        {
            if (erro != null)
                ViewBag.Erro = erro;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login u)
        {
            try
            {
                var _loginService = new LoginService();
                // esta action trata o post (login)
                if (ModelState.IsValid) //verifica se é válido
                {
                    var usuario = _loginService.loginRequest(u);
                    if (usuario.Erro == null)
                    {
                        Session["UsuarioLogado"] = usuario;
                        if (Session["UsuarioLogado"] == null)
                            return View(u);
                        return RedirectToAction("Index");
                    }
                    Session.Remove("UsuarioLogado");
                    return RedirectToAction("LoginIndex", "Login", new { erro = usuario.Erro });
                }
                Session.Remove("UsuarioLogado");
                return RedirectToAction("LoginIndex");
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                Session.Remove("UsuarioLogado");
                return RedirectToAction("LoginIndex");
            }
        }

        public ActionResult Logout()
        {
            var use = (Usuario)Session["UsuarioLogado"];
            try
            {
                if (use != null)
                {
                    Session.Remove("UsuarioLogado");
                    return RedirectToAction("Login");
                }
                throw new Exception("Você tem que estar logado para poder se deslogar");
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Login");
            }
        }

        public ActionResult Index()
        {
            try
            {
                var usuarioSessionLogado = (Usuario)Session["UsuarioLogado"];
                if (usuarioSessionLogado == null)
                    throw new Exception("Algo errado não está certo");

                if (Session["usuarioLogado"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                throw new Exception("Algo errado não está certo");
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Login");
            }
        }
    }
}
