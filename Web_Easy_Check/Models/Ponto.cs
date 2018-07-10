using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Easy_Check.Models
{
    public class Ponto
    {
        public Empresa Empresa { get; set; }
        public IList<Batidas> Batidas { get; set; }
    }
}