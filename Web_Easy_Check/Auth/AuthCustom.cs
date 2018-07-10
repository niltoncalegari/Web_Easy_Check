using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Easy_Check.Auth
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthCustom : AuthorizeAttribute
    {
        public string UserPermission { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
                return false;
            return true;
        }
    }
}