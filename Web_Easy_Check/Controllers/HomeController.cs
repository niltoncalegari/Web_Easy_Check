using Web_Easy_Check.Models;
using System.Web.Mvc;
using Web_Easy_Check.Service;

namespace Web_Easy_Check.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var _request = new Request();

            if (!_request.IsLogado())
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            
            ViewBag.IMG = "data:image/gif;base64," + _request.GetUsuarioParaImg().LogoEmpresa;
            return View();
        }

        public ActionResult PostPonto(RequestValuesPonto requestValues)
        {
            var _request = new Request();
            if (!_request.IsLogado())
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var result = _request.PostPonto(requestValues);
            return Json(new
            {
                sucess = true,
                msg = "Trouxe essa M****",
                result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostFolha(RequestValuesFolha requestValues)
        {
            var _request = new Request();
            if (!_request.IsLogado())
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var result = _request.PostFolha(requestValues);
            return Json(new
            {
                sucess = true,
                msg = "Trouxe essa M****",
                result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}