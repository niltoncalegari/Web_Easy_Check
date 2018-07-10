using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Easy_Check.Models;

namespace Web_Easy_Check.Util
{
    
    public class GetSessionUsuario
    {
        #region ..: SINGLETON :..
        public const string USUARIO_LOGADO_SESSION = "UsuarioLogado";
        private static readonly GetSessionUsuario instance = new GetSessionUsuario();        
        public static GetSessionUsuario Instance { get { return instance; } }
        public GetSessionUsuario()
        {
        }
        #endregion

        public Usuario GetUsuario()
        {
            var usuario = (Usuario)HttpContext.Current.Session[USUARIO_LOGADO_SESSION];

            return usuario;
        }

        public bool IsUsarioLogado()
        {
            return HttpContext.Current.Session[USUARIO_LOGADO_SESSION] != null ? true : false;
        }

    }
}