using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Easy_Check.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string LogoEmpresa { get; set; }
        public string Erro { get; set; }
    }
}